-----20190702
drop procedure SA_GetExistingUserLogin --'sokimkour', '0c7a0f6860f11d8fb239dd67d4ddbc3d'
go

create procedure SA_GetExistingUserLogin --'samangchhoeun', 'f99e4f599cab06447dfd7a1d9e189415'
	@UserID nvarchar(100),
	@Pwd nvarchar(200),
	@KC nvarchar(100)
as
begin 
	set nocount on
	declare @UserNo int=0

	if(len(@UserID)>0 and len(@Pwd)>0)
	begin
		if exists(select UserNo from tblsa_set_userlog where UserID=@UserID and Pass=@Pwd and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
		begin
			select 
				--U.CardID,
				RTRIM(U.Name) as Name,
				RTRIM(U.UserID) as UserID,
				RTRIM(U.Pass) as Pass,
				DBO.DECRYPT_TEXT(@KC, U.RoleID) as RoleID,
				ISNULL(EH.DepartmentID, 0) as DepartmentID,
				ISNULL(EH.CampusID, 0) as CampusID,
				ISNULL(EH.ClinicID, 0) as ClinicID,
				U.UserNo,				
				ISNULL(U.Change_Pass_NextLog, 0) as Change_Pass_NextLog,
				ISNULL(U.User_Cannot_Change_Pass, 0) as User_Cannot_Change_Pass,
				ISNULL(U.Disabled_Acc, 0) as Disabled_Acc
				--(select top 1 VisitedAt from tblSA_ActivityLog where ID=(select UserNo from tblsa_new_userlog where UserID=@id and Pass=@id2) order by VisitedAt desc) as VisitedAt
			FROM tblsa_set_userlog U 
				LEFT JOIN tblsa_employee_cardid EID on EID.CardID=U.CardID
				LEFT JOIN tblsa_employees E on EID.StaffNo=E.StaffNo
				LEFT JOIN tblsa_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
			where U.UserID=@UserID and U.Pass=@Pwd
				and (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
		end
		begin
			set @UserNo = (select top 1 UserNo from tblsa_set_userlog where UserID=@UserID and Pass=@Pwd)
			insert into tblsa_audit_activity_log(ID, VisitedAt, Activity, Machine_Name, Instant_Name, Server_IP_Address, Client_IP_Address) 
			select @UserNo, CURRENT_TIMESTAMP, 'Logged on ID: ' + @UserID + ' IPAddress ' + CONVERT(NVARCHAR(max), CLIENT_NET_ADDRESS), SERVERPROPERTY('ComputerNamePhysicalNetBIOS'), SERVERPROPERTY('InstanceName'), LOCAL_NET_ADDRESS, CLIENT_NET_ADDRESS from SYS.DM_EXEC_CONNECTIONS where SESSION_ID = @@SPID
		end
	end
end
go


---20191024
drop procedure SA_GetMyStore
go

create procedure SA_GetMyStore
	@Code int
as 
begin 	
	select top 1 MyStore from tblsa_set_my_store where Code=@Code 
end
go

-------20191024
drop procedure SA_GetUserLogIDList
go

create procedure SA_GetUserLogIDList
	@Admin bit
as 
begin 
	if @Admin=0
	begin
		select 
			CardID
		from tblsa_set_userlog
		where Mark_Deleted=0 or Mark_Deleted is null	 
		order by right(CardID, 4) 
	end
	else
	begin
		select 
			CardID
		from tblsa_set_userlog
		where (UserNo<>1 or UserNo<>2) and (Name<>'Admin' and Name<>'Root') and (Mark_Deleted=0 or Mark_Deleted is null)	 
		order by right(CardID, 4) 
	end
end
go

--------20191024-----
--declare @IsNewVersion nvarchar(20)
--exec SA_CheckAutoUpdateApp 'MJQE Employee Management', '1.0.0.0', @IsNewVersion

drop procedure SA_CheckAutoUpdateApp 
go
create procedure SA_CheckAutoUpdateApp
	@AppName nvarchar(max),
	@Version nvarchar(10),
	@IsNewVersion nvarchar(20) output
as
begin
	declare @Latest_Version nvarchar(15)=''
	set @IsNewVersion='0'
	
	if exists(SELECT ID FROM tblSA_SysAPPLICATIONUPDATER WHERE APPLICATION=@AppName)
	begin
		set @Latest_Version=(SELECT top 1 VERSION FROM tblSA_SysAPPLICATIONUPDATER WHERE APPLICATION=@AppName)

		if @Latest_Version>@Version
		begin
			set @IsNewVersion=@Latest_Version
		end
	end

	SELECT @IsNewVersion
end
go

------------------
drop procedure SA_GetVisibleControlsToList 
go

create procedure SA_GetVisibleControlsToList --'6', ''
	@UserNo int,
	@GroupID int
as
begin
	select
		ControlName,
		Caption,
		KhmerCaption
	from tblsa_set_controls	
	where (Mark_Deleted=0 or Mark_Deleted is null)
		and (Excluded=1)
	UNION ALL
	select
		c.ControlName,
		c.Caption,
		KhmerCaption
	from tblsa_set_user_privileges u
		inner join tblsa_set_group_permissions g on u.GroupID=g.GroupID
		inner join tblsa_set_controls c on c.ID=g.ControlID 
	where u.UserNo=@UserNo
		and u.Mark_Deleted=0
		and (c.Mark_Deleted=0 or c.Mark_Deleted is null)
end
go

---------20191024---------
--declare @IsNewVersion nvarchar(20)
--declare @Msg nvarchar(50)
--exec SA_RequiredUpdateAppVer 'MJQE Employee Management', '1.0.0.0', @IsNewVersion, @Msg
drop procedure SA_RequiredUpdateAppVer
go

create procedure SA_RequiredUpdateAppVer
	@AppName nvarchar(max),
	@Version nvarchar(10),
	@IsNewVersion nvarchar(20) output,
	@Msg nvarchar(50) output
as
begin
	declare @Latest_Version nvarchar(15)=''
	set @IsNewVersion='0'
	Set @Msg='Software version is out of date.'
	
	if exists(select ID from tblSA_SysAPPLICATIONUPDATER where APPLICATION=@AppName)
	begin
		set @Latest_Version=(select top 1 VERSION from tblSA_SysAPPLICATIONUPDATER where APPLICATION=@AppName)

		if @Latest_Version<@Version
		begin
			set @IsNewVersion=@Version
			set @Msg = 'New software version is released.'
		end
		else if @Latest_Version=@Version
		begin
			set @Msg = 'Software version is up to date.'
		end
	end

	SELECT @IsNewVersion, @Msg
end
go


----------------20191024
drop procedure SA_RecordUserLogout
go
create procedure SA_RecordUserLogout
 	@ID int
as 
begin 
	set nocount on
	if(@ID>0)
	begin
		insert into tblsa_audit_activity_log(ID, VisitedAt, Activity, Machine_Name, Instant_Name, Server_IP_Address, Client_IP_Address) 
		select @ID, CURRENT_TIMESTAMP, 'Logged out ID: '+ CONVERT(NVARCHAR(20), (select UserID from tblsa_set_userlog where UserNo=@ID)) + ' IPAddress ' + CLIENT_NET_ADDRESS, SERVERPROPERTY('ComputerNamePhysicalNetBIOS'), SERVERPROPERTY('InstanceName'), LOCAL_NET_ADDRESS, CLIENT_NET_ADDRESS from SYS.DM_EXEC_CONNECTIONS where SESSION_ID = @@SPID	
		update tblsa_set_userlog set 
			LastLoggedOut=CURRENT_TIMESTAMP,
			Client_IP_Address=CLIENT_NET_ADDRESS
		from SYS.DM_EXEC_CONNECTIONS where SESSION_ID = @@SPID
		and UserNo=@ID
			
	end
end
go

----------------20191024-----------------
drop procedure SA_ResetUserLogPass
go

create procedure SA_ResetUserLogPass
	@UserNo int,
	@UserID nvarchar(100),
	@CurPass nvarchar(200),
	@NewPass nvarchar(200),
	@UserUpdate nvarchar(100),
	@IsChange int output,
	@msg nvarchar(300) output
as 
begin 
	set nocount on
	set @msg='You cannot make change your password for this user.'
	set @IsChange=0
	if exists(select UserNo from tblsa_set_userlog where UserNo=@UserNo and UserID=@UserID)
	begin
		if exists(select UserNo from tblsa_set_userlog where Pass=@CurPass and UserNo=@UserNo and UserID=@UserID)
		begin
			if (len(@NewPass)>0) 
			begin
				update tblsa_set_userlog set Pass=@NewPass, Change_Pass_NextLog='0', UserUpdate=@UserUpdate, DateUpdate=CURRENT_TIMESTAMP where UserNo=@UserNo and UserID=@UserID
				insert into tblsa_audit_activity_log(ID, VisitedAt, Activity, Machine_Name, Instant_Name, Server_IP_Address, Client_IP_Address) 
				select @UserNo, CURRENT_TIMESTAMP, 'Reset password: UserID: '+ CONVERT(NVARCHAR(20), (select UserID from tblsa_set_userlog where UserNo=@UserNo)) + ' at IPAddress ' + CLIENT_NET_ADDRESS, SERVERPROPERTY('ComputerNamePhysicalNetBIOS'), SERVERPROPERTY('InstanceName'), LOCAL_NET_ADDRESS, CLIENT_NET_ADDRESS from SYS.DM_EXEC_CONNECTIONS where SESSION_ID = @@SPID	
				set @IsChange=1
				set @msg = 'Your password has been reset. Please re-login to active.'
			end
			else
			begin
				set @msg='Please enter new password.'
			end
		end
		else
		begin
			set @msg='Invalid entry current password. '
		end
	end

	select @msg, @IsChange
end
go


-----------
--------20180816
drop procedure SA_GetFTPSettings 
go

create procedure SA_GetFTPSettings
	@ID int,
	@Flag int,
	@KC nvarchar(max)
as
begin
	if @ID<>0
	begin
		if @Flag<>0
		begin
			select top 1
				ID,
				DBO.DECRYPT_TEXT(@KC, FTPAddress) AS FTPAddress,
				DBO.DECRYPT_TEXT(@KC, FTPUsername) AS FTPUsername,
				DBO.DECRYPT_TEXT(@KC, FTPPassword) AS FTPPassword,			
				ISNULL(FTPGroup, 0) AS FTPGroup,
				Remark
			from tblsa_set_ftp_clients
			where FTPGroup=@Flag
				and (Mark_Deleted=0 OR Mark_Deleted IS NULL)
		end
		else
		begin
			select top 1
				ID,
				DBO.DECRYPT_TEXT(@KC, FTPAddress) AS FTPAddress,
				DBO.DECRYPT_TEXT(@KC, FTPUsername) AS FTPUsername,
				DBO.DECRYPT_TEXT(@KC, FTPPassword) AS FTPPassword,			
				ISNULL(FTPGroup, 0) AS FTPGroup,
				Remark
			from tblsa_set_ftp_clients
			where ID=@ID
				and (Mark_Deleted=0 OR Mark_Deleted IS NULL)
		end
	end
	else
	begin
		select
			DBO.DECRYPT_TEXT(@KC, FTPAddress) AS FTPAddress,
			DBO.DECRYPT_TEXT(@KC, FTPUsername) AS FTPUsername,
			FTPPassword,
			ISNULL(GroupType, '') AS GroupType,
			Remark,
			C.Mark_Deleted as IsRemoved,
			ID
		from tblsa_set_ftp_clients C
			left join tblsa_set_ftp_group_types T on C.FTPGroup=T.FTPGroupID
		order by DBO.DECRYPT_TEXT(@KC, FTPAddress)
	end
end
go

------------------------------
drop procedure SA_SaveFTPConfiguration
go

create procedure SA_SaveFTPConfiguration
	@ID int,
	@FTPAddress nvarchar(max),
	@FTPUser nvarchar(max),
	@FTPPass nvarchar(max),
	@Remark nvarchar(max),
	@FTPGroup int,
	@KC nvarchar(max),
	@User nvarchar(100),	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = ''
	
	if(len(@FTPUser)>0 and len(@FTPPass)>0 and len(@FTPAddress)>0)
	begin
		if @ID=0
		begin
			--if not exists(select ID from tblsa_set_ftp_clients where FTPGroup=@FTPGroup and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
			if not exists(select ID from tblsa_set_ftp_clients where FTPGroup=@FTPGroup)
			begin
				insert into tblsa_set_ftp_clients(FTPAddress, FTPUsername, FTPPassword, FTPGroup, Remark, Mark_Deleted, UserCreate, DateCreate) values(DBO.ENCRYPT_TEXT(@KC, @FTPAddress), DBO.ENCRYPT_TEXT(@KC, @FTPUser), DBO.ENCRYPT_TEXT(@KC, @FTPPass), @FTPGroup, @Remark, 0, @User, CURRENT_TIMESTAMP)
				set @Msg = 'FTP upload configuration '+ @FTPAddress +' has been created successfully.'
				set @IsAdd=1
			end
			else
			begin
				set @Msg = 'FTP upload configuration '+ @FTPAddress +' already exists on the system.'
			end
		end
		else if exists(select ID from tblsa_set_ftp_clients where ID=@ID and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
		begin
			update tblsa_set_ftp_clients set
				FTPAddress=DBO.ENCRYPT_TEXT(@KC, @FTPAddress),
				FTPUsername=DBO.ENCRYPT_TEXT(@KC, @FTPUser),
				FTPPassword=DBO.ENCRYPT_TEXT(@KC, @FTPPass),
				FTPGroup=@FTPGroup,
				Remark=@Remark,
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP
			where ID=@ID
				and (Mark_Deleted=0 OR Mark_Deleted IS NULL)
			set @Msg = 'FTP upload configuration '+ @FTPAddress +' has been updated successfully.'
			set @IsAdd=2
		end
		else
		begin
			set @Msg='Error: There is no record found for this FTP: ' + @FTPAddress +'.'
		end
	end
	else
	begin
		set @Msg = 'Cannot performance this operation while configurations are empty.'
	end

	select @IsAdd, @Msg
end
go

--------------20190910

drop procedure SA_ReadFTPGroupList
go

create procedure SA_ReadFTPGroupList
AS
begin
	select 
		FTPGroupID,
		GroupType
	from tblsa_set_ftp_group_types
	where (Mark_Deleted=0 OR Mark_Deleted IS NULL)
	order by GroupType
end
go

-----------20191024
drop procedure SA_RemoveFTPLink
go

create procedure SA_RemoveFTPLink
	@Code int,
	@FTPAddress nvarchar(max),
	@IsRemoved bit,
	@UserUpdate nvarchar(100),
	@IsDeleted int output,
	@Msg nvarchar(300) output
as
begin
	set @IsDeleted=0
	set @Msg='No department selected.'
	if(@Code>0 and len(@FTPAddress)>0)
	begin
		if exists(select ID from tblsa_set_ftp_clients where ID=@Code)
		begin
			if @IsRemoved=1
			begin
				set @Msg='FTP link ' + @FTPAddress + ' has been removed.'	
			end
			else
			begin
				set @Msg='FTP link ' + @FTPAddress + ' has been restored.'	
			end

			update tblsa_set_ftp_clients set
				Mark_Deleted=@IsRemoved,
				UserUpdate=@UserUpdate,
				DateUpdate=CURRENT_TIMESTAMP
			where ID=@Code
			set @IsDeleted=1 
		end
	end

	select @IsDeleted, @Msg
end
go

------------------------20170921---------------
drop procedure SA_GetEncryptList
go

create procedure SA_GetEncryptList
as 
begin 
	set nocount on
	select 
		Head,
		Body,
		Tail
	from tblsa_set_encrypt_list	 
	order by Body
end
go

----------------
drop procedure SA_UpdateAppVersion
go

create procedure SA_UpdateAppVersion
	@AppName nvarchar(max),
	@Version nvarchar(15),
	@IsChange int output,
	@Msg nvarchar(300) output
as
begin
	set nocount on
	set @Msg=''
	set @IsChange=0
	
	if exists(select ID from tblSA_SysAPPLICATIONUPDATER where APPLICATION=@AppName)
	begin
		SET @IsChange=1
		UPDATE tblSA_SysAPPLICATIONUPDATER SET VERSION=@Version WHERE APPLICATION=@AppName 
		SET @Msg='Latest software version is updated.'
	end
	else
	begin
		SET @IsChange=2
		INSERT INTO tblSA_SysAPPLICATIONUPDATER(APPLICATION, VERSION, Inactive) VALUES(@AppName, @Version, 0)
		SET @Msg='New software version is added.'
	end

	SELECT @IsChange, @Msg
end
go


--------20191024
----20190123
--drop procedure SA_GetPositionToListForAdmin
--go

--create procedure SA_GetPositionToListForAdmin
--	@Flag bit
--as 
--begin 
--	if @Flag=0
--	begin
--		select
--			PositionEN,
--			PositionKh,
--			DepartmentEn,
--			PositionID,
--			P.UserCreate,
--			P.DateCreate,
--			P.UserUpdate,
--			P.DateUpdate
--		from tblsa_ms_positions P
--			inner join tblsa_ms_departments D on P.DepartmentID=P.DepartmentID
--		where (P.Mark_Deleted=0 or P.Mark_Deleted is null)
--			and (D.Mark_Deleted=0 or D.Mark_Deleted is null)
--		order by DepartmentEn, PositionEN
--	end
--	else
--	begin
--		select
--			PositionEN,
--			PositionKh,
--			DepartmentEn,
--			PositionID,
--			P.Mark_Deleted as Inactive,
--			P.UserCreate,
--			P.DateCreate,
--			P.UserUpdate,
--			P.DateUpdate		
--		from tblsa_ms_positions P
--			inner join tblsa_ms_departments D on P.DepartmentID=P.DepartmentID
--		where (D.Mark_Deleted=0 or D.Mark_Deleted is null)
--		order by DepartmentEn, PositionEN
--	end
--end
--go


------20191025-------User Management
drop procedure SA_GetRoleList
go

create procedure SA_GetRoleList
	@IsAdmin bit
as 
begin 
	if @IsAdmin=1
	begin
		select 
			RoleID,
			RoleType
		from tblsa_ms_roles
		order by RoleType 
	end
	else
	begin
		select 
			RoleID,
			RoleType
		from tblsa_ms_roles 
		where RoleID <> 1
		order by RoleType 
	end
end
go

------------20191025
drop procedure SA_GetUserLogToList 
go

create procedure SA_GetUserLogToList
	@CardID nvarchar(10),
	@KC nvarchar(100),
	@Flag int
as
begin
	if @Flag=0
	begin
		if(len(@CardID)>0)
		begin
			select top 1
				u.UserNo as ID,
				u.Name as AccountName,
				u.UserID as UserID,
				(CASE DBO.DECRYPT_TEXT(@KC, u.RoleID) WHEN 1 THEN 'Undefined' ELSE T.RoleType END) as RoleType,
				u.Disabled_Acc AS AccountBlock,
				U.Change_Pass_NextLog AS ChangePasswordNextLogon,
				U.User_Cannot_Change_Pass AS RestrictPasswordChange,
				U.CardID as UserCode,
				--E.Photo as ProfilePicture,
				u.DateCreate
			from tblsa_set_userlog u
				inner join tblsa_ms_roles T on DBO.DECRYPT_TEXT(@KC, u.RoleID)=T.RoleID
				left join tblsa_employee_cardid EID on U.CardID=EID.CardID
				--left join tblsa_new_employees E on EID.StaffNo=E.StaffNo
			where U.CardID=@CardID 
				and (u.Mark_Deleted=0 or u.Mark_Deleted is null)
				and U.UserNo<>1 and U.UserNo<>2
				--and (E.Mark_Deleted=0 or E.Mark_Deleted is null) 
				--and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
			order by u.Name
		end
		else
		begin
			select 
				u.UserNo as ID,
				u.Name as AccountName,
				u.UserID as UserID,
				(CASE DBO.DECRYPT_TEXT(@KC, u.RoleID) WHEN 1 THEN 'Undefined' ELSE T.RoleType END) as RoleType,
				u.Disabled_Acc AS AccountBlock,
				U.Change_Pass_NextLog AS ChangePasswordNextLogon,
				U.User_Cannot_Change_Pass AS RestrictPasswordChange,
				U.CardID as UserCode,
				--E.Photo as ProfilePicture,
				u.DateCreate
			from tblsa_set_userlog u
				inner join tblsa_ms_roles T on DBO.DECRYPT_TEXT(@KC, u.RoleID)=T.RoleID
				--left join tblsa_new_employee_cardid EID on U.CardID=EID.CardID
				--left join tblsa_new_employees E on EID.StaffNo=E.StaffNo
			where (u.Mark_Deleted=0 or u.Mark_Deleted is null)
				and U.UserNo<>1 and U.UserNo<>2
				--and (E.Mark_Deleted=0 or E.Mark_Deleted is null) 
				--and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
			order by u.Name
		end
	end
	else
	begin
		if(len(@CardID)>0)
		begin
			select top 1
				u.UserNo as ID,
				u.Name as AccountName,
				u.UserID as UserID,
				(CASE DBO.DECRYPT_TEXT(@KC, u.RoleID) WHEN 1 THEN 'Undefined' ELSE T.RoleType END) as RoleType,
				u.Disabled_Acc AS AccountBlock,
				U.Change_Pass_NextLog AS ChangePasswordNextLogon,
				U.User_Cannot_Change_Pass AS RestrictPasswordChange,
				U.CardID as UserCode,
				--E.Photo as ProfilePicture,
				u.DateCreate
			from tblsa_set_userlog u
				inner join tblsa_ms_roles T on DBO.DECRYPT_TEXT(@KC, u.RoleID)=T.RoleID
				left join tblsa_employee_cardid EID on U.CardID=EID.CardID
				--left join tblsa_new_employees E on EID.StaffNo=E.StaffNo
			where U.CardID=@CardID 
				and (u.Mark_Deleted=0 or u.Mark_Deleted is null)
				--and (E.Mark_Deleted=0 or E.Mark_Deleted is null) 
				--and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
			order by u.Name
		end
		else
		begin
			select 
				u.UserNo as ID,
				u.Name as AccountName,
				u.UserID as UserID,
				(CASE DBO.DECRYPT_TEXT(@KC, u.RoleID) WHEN 1 THEN 'Undefined' ELSE T.RoleType END) as RoleType,
				u.Disabled_Acc AS AccountBlock,
				U.Change_Pass_NextLog AS ChangePasswordNextLogon,
				U.User_Cannot_Change_Pass AS RestrictPasswordChange,
				U.CardID as UserCode,
				--E.Photo as ProfilePicture,
				u.DateCreate
			from tblsa_set_userlog u
				inner join tblsa_ms_roles T on DBO.DECRYPT_TEXT(@KC, u.RoleID)=T.RoleID
				--left join tblsa_new_employee_cardid EID on U.CardID=EID.CardID
				--left join tblsa_new_employees E on EID.StaffNo=E.StaffNo
			where (u.Mark_Deleted=0 or u.Mark_Deleted is null)
				--and (E.Mark_Deleted=0 or E.Mark_Deleted is null) 
				--and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
			order by u.Name
		end
	end
end
go

-------20191025
drop procedure SA_BanUserAccount
go

create procedure SA_BanUserAccount
	@StrID nvarchar(max),
	@BlockAcc bit,
	@StictPassword bit,	
	@RequestChangePassword bit,
	@Mark_Deleted bit,
	@User nvarchar(100),	
	@IsAdd int output,
	@msg nvarchar(200) output
as 
begin 
	set nocount on
	set @msg = 'You cannot make change selected users due to IDs are not existed.'
	set @IsAdd=0
	DECLARE @TempStr nvarchar(max)=''

	DECLARE @TblTempID TABLE(ID int)
	INSERT INTO @TblTempID SELECT Name FROM dbo.SA_SplitString(@StrID, ',')

	DECLARE @TblTempList TABLE(ID int, CardID NVARCHAR(MAX))
	INSERT INTO @TblTempList SELECT I.ID, CardID from tblsa_set_userlog U inner join @TblTempID I on U.UserNo=I.ID

	DECLARE @TempID NVARCHAR(10)
	DECLARE DB_CURSOR CURSOR FOR SELECT ID from @TblTempList
	OPEN DB_CURSOR 
	
	FETCH NEXT FROM DB_CURSOR INTO @TempID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		if exists(select UserNo from tblsa_set_userlog where UserNo=@TempID)
		begin			
			update tblsa_set_userlog set
				Disabled_Acc=@BlockAcc,
				User_Cannot_Change_Pass=@StictPassword,
				Change_Pass_NextLog=@RequestChangePassword,
				Mark_Deleted=@Mark_Deleted,
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP
			where UserNo=@TempID
			insert into tblsa_audit_activity_log(ID, VisitedAt, Activity, Machine_Name, Instant_Name, Server_IP_Address, Client_IP_Address) 
			select @TempID, CURRENT_TIMESTAMP, 'Card ID: ' + @TempID + ' set Disable Account: ' + (CASE @BlockAcc WHEN 1 THEN 'Block' ELSE 'Allow' END) +',Stict Password: '+ (CASE @StictPassword WHEN 1 THEN 'Yes' ELSE 'No' END) + ',Change Password Next Login: '+ (CASE @RequestChangePassword WHEN 1 THEN 'Yes' ELSE 'No' END)+ ',Remove: '+ (CASE @RequestChangePassword WHEN 1 THEN 'Yes' ELSE 'No' END) +' IP address: ' + CLIENT_NET_ADDRESS, SERVERPROPERTY('ComputerNamePhysicalNetBIOS'), SERVERPROPERTY('InstanceName'), LOCAL_NET_ADDRESS, CLIENT_NET_ADDRESS from SYS.DM_EXEC_CONNECTIONS, tblsa_new_userlog  where SESSION_ID = @@SPID and UserNo=@TempID

			set @IsAdd=1
			set @TempStr=@TempStr +(select CardID from tblsa_set_userlog where UserNo=@TempID)+', ' 						
		end

		FETCH NEXT FROM DB_CURSOR INTO @TempID		
	END
	CLOSE DB_CURSOR
	DEALLOCATE DB_CURSOR
	
	if len(@TempStr)>0
	begin
		set @TempStr=LEFT(@TempStr, LEN(@TempStr)-1)
	end
	if @IsAdd=1
	begin
		set @msg = 'Card ID ' +@TempStr +' have been set:' +char(10) +char(9) +'- Disable Account: ' + (CASE @BlockAcc WHEN 1 THEN 'Block' ELSE 'Allow' END) +char(10) +char(9) +'- User Cannot Change Password: ' +(CASE @StictPassword WHEN 1 THEN 'Yes' ELSE 'No' END) +char(10) +char(9) +'- Required Password Change at Next Logon: ' +(CASE @RequestChangePassword WHEN 1 THEN 'Yes' ELSE 'No' END) +char(10) +char(9) +'- Account Removed ' +(CASE @Mark_Deleted WHEN 1 THEN 'Yes' ELSE 'No' END)
	end

	select @IsAdd, @Msg
end
go


------20191025
drop procedure SA_GetUserLogByID 
go

create procedure SA_GetUserLogByID
	@CardID nvarchar(10),
	@KC nvarchar(100)
as
begin
	if(len(@CardID)>0)
	begin
		if exists(select UserNo from tblsa_set_userlog where CardID=@CardID and (Mark_Deleted=0 or Mark_Deleted is null))
		begin
			select top 1
				'IsCreated' as IsCreated,
				u.UserNo,
				U.CardID,
				u.Name,
				E.Photo,
				u.UserID,
				u.Pass,
				DBO.DECRYPT_TEXT(@KC, u.RoleID) AS RoleID,
				u.Change_Pass_NextLog,
				u.User_Cannot_Change_Pass,
				u.Disabled_Acc,
				u.UserCreate,
				u.DateCreate,
				u.UserUpdate,
				u.DateUpdate
			from tblsa_set_userlog u
				left join tblsa_employee_cardid EID on U.CardID=EID.CardID
				inner join tblsa_employees E on EID.StaffNo=E.StaffNo
			where U.CardID=@CardID and (E.Mark_Deleted=0 or E.Mark_Deleted is null) and (u.Mark_Deleted=0 or u.Mark_Deleted is null)
		end
		else
		begin
			select top 1
				'IsNew' as IsCreated,
				E.StaffNo,
				EID.CardID,
				RTRIM(LTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Name,  		
				E.Photo
			FROM tblsa_employee_cardid EID
				inner JOIN tblsa_employees E on EID.StaffNo=E.StaffNo
			where EID.CardID=@CardID and (E.Mark_Deleted=0 or E.Mark_Deleted is null)
		end
	end
end
go
	
----------------20170918
drop procedure SA_SaveUserLog
go

create procedure SA_SaveUserLog
	@UserNo int,
	@CardID nvarchar(20),
	@UserAccount nvarchar(300),
	@UserID nvarchar(300),
	@Pass nvarchar(300),
	@RoleID tinyint,
	@Change_Pass_NextLog tinyint,
	@User_Cannot_Change_Pass tinyint,
	@Disabled_Acc tinyint,
	@User nvarchar(100),
	@KC nvarchar(max),
	@isAdd int output,
	@msg nvarchar(200) output
as 
begin 
	set nocount on
	set @isAdd = 0
	set @msg = ''
	declare @Name nvarchar(100)=''
	if @UserNo=0
	begin
		set @UserNo = (select ISNULL(max(UserNo), 0)+1 from tblsa_set_userlog)
	end

	if(len(@CardID)>0 and @UserNo>0 and len(@UserID)>0)
	begin
		if exists(select UserNo from tblsa_set_userlog where UserID=@UserID and UserNo<>@UserNo)
		begin
			set @msg = 'Username: '+ @UserAccount +' is already existed for employee id: '+ @CardID +' in the system.'
		end
		else
		begin
			if not exists(select UserNo from tblsa_set_userlog where CardID=@CardID and UserID=@UserID and UserNo=@UserNo)
			begin
				if exists(select ID 
							from tblsa_employee_cardid EID
								INNER JOIN tblsa_employees E on EID.StaffNo=E.StaffNo
							where CardID=@CardID and EID.Mark_Deleted=0 and E.Mark_Deleted=0)
				begin
					set @Name=(select LTRIM(RTRIM(ISNULL(FirstName, '') + ' ' + ISNULL(LastName, '')))  
							from tblsa_employee_cardid EID
								INNER JOIN tblsa_employees E on EID.StaffNo=E.StaffNo
							where CardID=@CardID and EID.Mark_Deleted=0 and E.Mark_Deleted=0)
				end
				
				insert into tblsa_set_userlog(CardID, Name, UserNo, Mark_Deleted, UserCreate, DateCreate) values(@CardID, @Name, @UserNo, 0, @User, CURRENT_TIMESTAMP)
				insert into tblsa_audit_activity_log(ID, VisitedAt, Activity, Machine_Name, Instant_Name, Server_IP_Address, Client_IP_Address) 
				select @UserNo, CURRENT_TIMESTAMP, 'Created UserID: '+ @UserID +', Usertype: ' + CONVERT(NVARCHAR(10), @RoleID) +' by IP address: ' + CONVERT(NVARCHAR(40), CLIENT_NET_ADDRESS), SERVERPROPERTY('ComputerNamePhysicalNetBIOS'), SERVERPROPERTY('InstanceName'), LOCAL_NET_ADDRESS, CLIENT_NET_ADDRESS from SYS.DM_EXEC_CONNECTIONS where SESSION_ID = @@SPID
				
				set @msg = 'Username: '+ @UserAccount +' has been registered for employee id: '+ @CardID +' successfully.'
			end	
			else
			begin
				update tblsa_set_userlog set DateUpdate=CURRENT_TIMESTAMP, UserUpdate=@User where CardID=@CardID and UserNo=@UserNo
				insert into tblsa_audit_activity_log(ID, VisitedAt, Activity, Machine_Name, Instant_Name, Server_IP_Address, Client_IP_Address) 
				select @UserNo, CURRENT_TIMESTAMP, 'Changed UserID: ' + @UserID +', Usertype: ' + CONVERT(NVARCHAR(10), @RoleID) + ' by IP address: ' + CLIENT_NET_ADDRESS, SERVERPROPERTY('ComputerNamePhysicalNetBIOS'), SERVERPROPERTY('InstanceName'), LOCAL_NET_ADDRESS, CLIENT_NET_ADDRESS from SYS.DM_EXEC_CONNECTIONS where SESSION_ID = @@SPID
			
				set @msg = 'Username: '+ @UserAccount +' has been modified for employee id: '+ @CardID +' successfully.'
			end

			begin
				update tblsa_set_userlog set
					UserID=@UserID,
					Pass=@Pass,
					@RoleID=DBO.ENCRYPT_TEXT(@KC, @RoleID),
					Disabled_Acc=@Disabled_Acc,
					Change_Pass_NextLog=@Change_Pass_NextLog,
					User_Cannot_Change_Pass=@User_Cannot_Change_Pass
				where CardID=@CardID and UserNo=@UserNo
			end
		
			set @isAdd = (Select top 1 UserNo from tblsa_set_userlog where CardID=@CardID and UserNo=@UserNo)
		end
	end
	else
	begin
		set @msg = 'Cannot performance this operation while the Employee ID is empty.'
	end

	select @isAdd, @msg
end
go


------20191025
drop procedure SA_GetUserLogByFilter
go

create procedure SA_GetUserLogByFilter
	@CardID nvarchar(20),
	@RoleID tinyint,
	@BlockAcc bit,
	@RestrictPasswordChange bit,
	@RequiredPasswordChange bit,
	@KC nvarchar(100)
as
begin
	if len(@CardID)=0
	begin
		if @RoleID=0
		begin
			select 
				u.UserNo as ID,
				U.CardID as UserCode,
				u.Name as AccountName,
				E.Sex,
				ISNULL(P.PositionEn, 'Undefined') AS Position,
				ISNULL(Dept.DepartmentEn, 'Undefined') AS Department,
				ISNULL(CL.ClinicEn, 'Undefined') AS Clinic,
				ISNULL(CA.CampusEn, 'Undefined') AS Campus,
				u.UserID,
				(CASE DBO.DECRYPT_TEXT(@KC, u.RoleID) WHEN 1 THEN 'Undefined' ELSE T.RoleType END) as RoleType,
				u.Disabled_Acc AS AccountBlock,
				U.Change_Pass_NextLog AS ChangePasswordNextLogon,
				U.User_Cannot_Change_Pass AS RestrictPasswordChange,
				--E.Photo as ProfilePicture,
				u.UserCreate,
				u.DateCreate,
				u.UserUpdate,
				u.DateUpdate
			from tblsa_set_userlog u
				INNER JOIN tblsa_ms_roles T on DBO.DECRYPT_TEXT(@KC, u.RoleID)=T.RoleID
				LEFT JOIN tblsa_employee_cardid EID on U.CardID=EID.CardID
				LEFT JOIN tblsa_employees E on EID.StaffNo=E.StaffNo
				LEFT JOIN tblsa_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID
				LEFT JOIN tblsa_ms_positions P on P.PositionID=EH.PositionID
				LEFT JOIN tblsa_ms_clinic CL on EH.ClinicID=CL.ClinicID
				LEFT JOIN tblsa_ms_departments Dept on EH.DepartmentID=Dept.DepartmentID
				LEFT JOIN tblsa_ms_campuses CA on EH.CampusID=CA.CampusID
			where (u.Mark_Deleted=0 or u.Mark_Deleted is null)
				and (E.Mark_Deleted=0 or E.Mark_Deleted is null) 
				and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
			order by u.Name
		end
		else
		begin
			select 
				u.UserNo as ID,
				U.CardID as UserCode,
				u.Name as AccountName,
				E.Sex,
				ISNULL(P.PositionEn, 'Undefined') AS Position,
				ISNULL(Dept.DepartmentEn, 'Undefined') AS Department,
				ISNULL(CL.ClinicEn, 'Undefined') AS Clinic,
				ISNULL(CA.CampusEn, 'Undefined') AS Campus,
				u.UserID,
				(CASE DBO.DECRYPT_TEXT(@KC, u.RoleID) WHEN 1 THEN 'Undefined' ELSE T.RoleType END) as RoleType,
				u.Disabled_Acc AS AccountBlock,
				U.Change_Pass_NextLog AS ChangePasswordNextLogon,
				U.User_Cannot_Change_Pass AS RestrictPasswordChange,
				--E.Photo as ProfilePicture,
				u.UserCreate,
				u.DateCreate,
				u.UserUpdate,
				u.DateUpdate
			from tblsa_set_userlog u
				INNER JOIN tblsa_ms_roles T on DBO.DECRYPT_TEXT(@KC, u.RoleID)=T.RoleID
				LEFT JOIN tblsa_employee_cardid EID on U.CardID=EID.CardID
				LEFT JOIN tblsa_employees E on EID.StaffNo=E.StaffNo
				LEFT JOIN tblsa_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID
				LEFT JOIN tblsa_ms_positions P on P.PositionID=EH.PositionID
				LEFT JOIN tblsa_ms_clinic CL on EH.ClinicID=CL.ClinicID
				LEFT JOIN tblsa_ms_departments Dept on EH.DepartmentID=Dept.DepartmentID
				LEFT JOIN tblsa_ms_campuses CA on EH.CampusID=CA.CampusID
			where (u.Mark_Deleted=0 or u.Mark_Deleted is null)
				and (E.Mark_Deleted=0 or E.Mark_Deleted is null) 
				and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
			order by u.Name
		end
	end
end
go

------------20191025
drop procedure SA_GetGroupToCombo
go

create procedure SA_GetGroupToCombo
as 
begin 
	select
		ID,
		Name as GroupName
	from tblsa_set_groups
	where Mark_Deleted=0 or Mark_Deleted is null
	order by Name
end
go


------------
drop procedure SA_GetGroupToList
go

create procedure SA_GetGroupToList
	@ID int
as 
begin 
	if @ID>0 
	begin
		select top 1
			ID,
			Name as GroupName,
			[Description],
			Mark_Deleted AS Inactive,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_set_groups
		where ID=@ID 
			--and (Mark_Deleted=0 or Mark_Deleted is null)
		--order by Name
	end
	else
	begin
		select
			ID,
			Name as GroupName,
			[Description],
			Mark_Deleted AS Inactive,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_set_groups
		--where (Mark_Deleted=0 or Mark_Deleted is null)
		order by Name
	end
end
go


--------------------------
--SA_GetUserPrivilegesToList 1
drop procedure SA_GetUserPrivilegesToList 
go

create procedure SA_GetUserPrivilegesToList
	@id int
as
begin
	select
		u.UserNo,
		u.Name as AccountName,
		u.UserID,		
		u.Disabled_Acc AS AccountBlock,
		U.Change_Pass_NextLog AS ChangePasswordNextLogon,
		U.User_Cannot_Change_Pass AS RestrictPasswordChange,
		U.CardID,			
		p.Mark_Deleted as Inactive
		--p.UserCreate,
		--p.DateCreate,
		--p.UserUpdate,
		--p.DateUpdate
	from tblsa_set_userlog u
		 join tblsa_set_user_privileges p on p.UserNo=u.UserNo
	WHERE p.GroupID=@id
		--and p.Mark_Deleted=0
	ORDER BY u.Name
end
go


-------------20191004
drop procedure SA_RemoveGroupPermissions
go

create procedure SA_RemoveGroupPermissions
	@GroupID int,
	@ControlList nvarchar(max),
	@IsUpdate int output,
	@Msg nvarchar(300) output
as
begin
	set @IsUpdate=0
	set @Msg='Selected permissions are not available to remove.'	
	DECLARE @TblTempID TABLE(ID NVARCHAR(max))
	INSERT INTO @TblTempID SELECT Name FROM dbo.SA_SplitString(@ControlList, ',')

	DECLARE @TempID NVARCHAR(max)
	DECLARE DB_CURSOR CURSOR FOR SELECT ID from @TblTempID
	OPEN DB_CURSOR 
	
	FETCH NEXT FROM DB_CURSOR INTO @TempID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		if(@GroupID>0)
		begin
			declare @ControlID int = (select top 1 ID from tblsa_set_controls where ControlName=@TempID)
			if exists(select GroupID from tblsa_set_group_permissions where GroupID=@GroupID and ControlID=@ControlID)
			begin
				delete from tblsa_set_group_permissions where GroupID=@GroupID and ControlID=@ControlID		
				set @IsUpdate=1
			end
		end
		FETCH NEXT FROM DB_CURSOR INTO @TempID		
	END
	CLOSE DB_CURSOR
	DEALLOCATE DB_CURSOR
	
	if @IsUpdate=1
	begin
		set @Msg='Selected permissions have been removed.'	
	end
	
	select @IsUpdate, @Msg	
end
go

---------------
drop procedure SA_GetGroupPermissionToList
go

create procedure SA_GetGroupPermissionToList
	@id int
as
begin
	SELECT
		c.ID,
		c.Caption,
		c.KhmerCaption,
		c.ControlName,
		c.UserCreate,
		c.DateCreate
	FROM tblsa_set_group_permissions g
	INNER JOIN tblsa_set_controls c on g.ControlID=c.ID 	
	WHERE g.GroupID=@id
	ORDER BY c.Caption
end
go

-------------
drop procedure SA_GetExcludeControlsToList
go

create procedure SA_GetExcludeControlsToList
as 
begin 
	select
		ID,
		Caption,
		KhmerCaption,
		ControlName
	from tblsa_set_controls	
	where (Mark_Deleted=0 or Mark_Deleted is null)
		and (Excluded=1)
end
go

-------------20191025
DROP FUNCTION SA_SplitString
GO
CREATE FUNCTION SA_SplitString ( 
	@stringToSplit VARCHAR(MAX),
	@separator VARCHAR(5)
)
RETURNS
	@returnList TABLE ([Name] [nvarchar] (500))
AS
BEGIN
	DECLARE @name NVARCHAR(255)
	DECLARE @pos INT

	WHILE CHARINDEX(@separator, @stringToSplit) > 0
		BEGIN
			SELECT @pos  = CHARINDEX(@separator, @stringToSplit)  
			SELECT @name = SUBSTRING(@stringToSplit, 1, @pos-1)

			INSERT INTO @returnList 
			SELECT @name

			SELECT @stringToSplit = SUBSTRING(@stringToSplit, @pos+1, LEN(@stringToSplit)-@pos)
	END
	
	INSERT INTO @returnList
	SELECT @stringToSplit

	RETURN
END
go

------------20191028
--drop procedure SA_GetAccountTypeByID 
--go

--create procedure SA_GetAccountTypeByID
--	@ID int
--as
--begin
--	if @ID<>0
--	begin
--		select top 1
--			UserTypeID as Code,
--			UserType,
--			Remark,		
--			Mark_Deleted as Inactive,
--			UserCreate,
--			DateCreate,
--			UserUpdate,
--			DateUpdate
--		from tblsa_ms_roles
--		where UserTypeID=@ID 
--		 --and (Mark_Deleted=0 or Mark_Deleted is null)
--	end
--	else
--	begin
--		select 
--			UserTypeID as Code,
--			UserType,
--			Remark,		
--			Mark_Deleted as Inactive,
--			UserCreate,
--			DateCreate,
--			UserUpdate,
--			DateUpdate
--		from tblsa_ms_roles
--		--where (Mark_Deleted=0 or Mark_Deleted is null)
--		order by UserType
--	end
--end
--go



---------20191028
drop procedure SA_GetLanguages
go

create procedure SA_GetLanguages
as 
begin 
	set nocount on
	select 
		ID,
		RTRIM(Lang) as [Language]
	from tblsa_ms_languages
	order by Language desc
end
go

--------20191028
------UESR MANAGEMENT
drop procedure SA_GetControlsToList
go

create procedure SA_GetControlsToList
	@ID int
as 
begin 
	if @ID>0 
	begin
		select
			ID,
			Caption,
			KhmerCaption,
			ControlName,
			UserCreate,
			DateCreate
		from tblsa_set_controls
		where ID=@ID and (Mark_Deleted=0 or Mark_Deleted is null)
		order by Caption
	end
	else
	begin
		select
			ID,
			Caption,
			KhmerCaption,
			ControlName,
			UserCreate,
			DateCreate
		from tblsa_set_controls 
		where (Mark_Deleted=0 or Mark_Deleted is null)
		order by Caption
	end
end
go

------------
drop procedure SA_GetUserAccessPermissionByID 
go

create procedure SA_GetUserAccessPermissionByID
	@UserNo int
as
begin
	SELECT
		c.ID,
		c.Caption,
		c.KhmerCaption,
		c.ControlName,
		P.IsAllowed,
		(CASE ISNULL(P.RoleID, 0) WHEN 0 THEN 'Undefined' WHEN 1 THEN 'System Admin' ELSE T.RoleType END) as RoleType
	FROM tblsa_set_userlog_permissions P 
		inner join tblsa_ms_roles T on P.RoleID=T.RoleID
		INNER JOIN tblsa_set_controls c on P.Permission=c.ID 	
	WHERE P.UserNo=@UserNo
		and (P.Mark_Deleted=0 or P.Mark_Deleted IS NULL)
	ORDER BY c.Caption	
end
go

------------------20171022
drop procedure SA_GetGroupControlID
go

create procedure SA_GetGroupControlID 
	@id int
as
begin
	select
		ControlName
	from tblsa_set_group_permissions g
	inner join tblsa_set_controls c on c.ID=g.ControlID
	 WHERE g.GroupID=@id
end
go


-------------20180820--update 20180824
drop procedure SA_GetAllControlsToList
go

create procedure SA_GetAllControlsToList
as 
begin 
	select
		ID,
		Caption,
		KhmerCaption,
		ControlName
	from tblsa_set_controls
	where (Mark_Deleted=0 or Mark_Deleted is null)
	ORDER BY Caption	
end
go



------20180903
drop procedure SA_GetRemovedControlsToList
go

create procedure SA_GetRemovedControlsToList
as 
begin 
	select
		ID,
		Caption,
		KhmerCaption,
		ControlName
	from tblsa_set_controls 
	where Mark_Deleted=1
	ORDER BY Caption	
end
go


--------------20171204
drop procedure SA_DeleteOldControls
go

create procedure SA_DeleteOldControls
as
begin
	delete from tblsa_set_controls where Excluded=0
end
go

--------------
drop procedure SA_GetUserPrivilegeID
go

create procedure SA_GetUserPrivilegeID
	@id int
as
begin
	select
		UserNo
	from tblsa_set_user_privileges 
	WHERE GroupID=@id
		and Mark_Deleted=0
end
go


--------------
drop procedure SA_GetUserAccountToList
go

create procedure SA_GetUserAccountToList
	@ID int
as 
begin 
	if @ID>0 
	begin
		select
			UserNo,
			Name as AccountName,
			UserID,
			CardID,	
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_set_userlog
		where UserNo=@ID and (Mark_Deleted=0 or Mark_Deleted is null)
		order by Name
	end
	else
	begin
		select
			UserNo,
			Name as AccountName,
			UserID,
			CardID,	
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_set_userlog
		where (Mark_Deleted=0 or Mark_Deleted is null)
		order by Name
	end
end
go

--------------------
drop procedure SA_RemoveUserPrivileges
go

create procedure SA_RemoveUserPrivileges
	@StrID nvarchar(max),
	@GroupID int,
	@Inactive bit,
	@IsRemoved bit,
	@FlagRemove bit,
	@User nvarchar(100),
	@IsUpdate int output,
	@Msg nvarchar(max) output
as
begin
	set @IsUpdate=0
	set @Msg='No user account selected to perform action.'
	DECLARE @TempStr nvarchar(max)=''

	DECLARE @TblTempID TABLE(ID NVARCHAR(10))
	INSERT INTO @TblTempID SELECT Name FROM dbo.SA_SplitString(@StrID, ',')

	DECLARE @TempID NVARCHAR(10)
	DECLARE DB_CURSOR CURSOR FOR SELECT ID from @TblTempID
	OPEN DB_CURSOR 
	
	FETCH NEXT FROM DB_CURSOR INTO @TempID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		if @FlagRemove=0
		begin
			if exists(select UserNo from tblsa_set_userlog where CardID=@TempID)
			begin			
				update tblsa_set_userlog set
					Disabled_Acc=@Inactive,
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where CardID=@TempID
				set @IsUpdate=1
				set @TempStr=@TempStr +(select top 1 CardID from tblsa_set_userlog where CardID=@TempID) +', ' 						
			end
		end
		else
		begin
			if exists(select p.UserNo from tblsa_set_user_privileges p inner join tblsa_set_userlog U on p.UserNo=U.UserNo where GroupID=@GroupID and U.CardID=@TempID)
			begin	
				update tblsa_set_user_privileges set
					Mark_Deleted=@IsRemoved,					
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				from tblsa_set_user_privileges p
					inner join tblsa_set_userlog U on p.UserNo=U.UserNo
				where GroupID=@GroupID 
					and U.CardID=@TempID					
				set @IsUpdate=2
				declare @CardID nvarchar(10)=(select top 1 U.CardID from tblsa_set_user_privileges p inner join tblsa_set_userlog U on p.UserNo=U.UserNo where GroupID=@GroupID and U.CardID=@TempID)
				set @TempStr=@TempStr +  CONVERT(NVARCHAR(20), @CardID) +', ' 		
			end
		end

		FETCH NEXT FROM DB_CURSOR INTO @TempID		
	END
	CLOSE DB_CURSOR
	DEALLOCATE DB_CURSOR

	if len(@TempStr)>0
	begin
		set @TempStr=LEFT(@TempStr, LEN(@TempStr)-1)
	end

	if @FlagRemove=0
	begin
		if @Inactive=1
		begin
			set @Msg='User accounts with ID: ' + @TempStr + ' has been blocked.'	
		end
		else
		begin
			set @Msg='User accounts with ID: ' + @TempStr + ' has been unblocked.'	
		end
	end
	else
	begin
		if @IsRemoved=1
		begin
			set @Msg='User accounts with ID: ' + @TempStr + ' has been removed.'	
		end
		else
		begin
			set @Msg='User accounts with ID: ' + @TempStr + ' has been restored.'	
		end
	end
	
	select @IsUpdate, @Msg	
end
go


-----20191003
drop procedure SA_SaveUserPrivileges
go

create procedure SA_SaveUserPrivileges
	@GroupID int,
	@StrID nvarchar(max),
	@Remark nvarchar(max),
	@User nvarchar(100),	
	@IsAdd int output,
	@msg nvarchar(max) output
as 
begin 
	set nocount on
	set @msg = 'You cannot make change selected users due to IDs are not existed.'
	set @IsAdd=0
	if @GroupID <> 0
	begin
		DECLARE @TempStr nvarchar(max)=''
		DECLARE @TblTempID TABLE(ID int)
		INSERT INTO @TblTempID SELECT Name FROM dbo.SA_SplitString(@StrID, ',')

		DECLARE @TempID NVARCHAR(10)=''
		DECLARE DB_CURSOR CURSOR FOR SELECT ID from @TblTempID
		OPEN DB_CURSOR 
	
		FETCH NEXT FROM DB_CURSOR INTO @TempID
		WHILE @@FETCH_STATUS = 0
		BEGIN
			if not exists(select UserNo from tblsa_set_user_privileges where GroupID=@GroupID and UserNo=@TempID and Mark_Deleted=0)
			begin
				insert into tblsa_set_user_privileges(GroupID, UserNo, Remark, Mark_Deleted, UserCreate, DateCreate) values(@GroupID, @TempID, @Remark, 0, @User, CURRENT_TIMESTAMP)
				set @TempStr=@TempStr +(select top 1 CardID from tblsa_set_userlog where UserNo=@TempID)+', ' 						
				set @IsAdd=1
			end

			FETCH NEXT FROM DB_CURSOR INTO @TempID		
		END
		CLOSE DB_CURSOR
		DEALLOCATE DB_CURSOR
	
		if len(@TempStr)>0
		begin
			set @TempStr=LEFT(@TempStr, LEN(@TempStr)-1)
		end
		if @IsAdd=1
		begin
			set @msg = 'Card ID: ' +@TempStr +' have been added to group '+(select top 1 Name from tblsa_set_groups where ID=@GroupID) +' successfully.'
		end
	end

	select @IsAdd, @Msg
end
go


------------------
drop procedure SA_PermanentDeleteAccountByGroupID
go

create procedure SA_PermanentDeleteAccountByGroupID
	@GroupID int,
	@StrID nvarchar(max),		
	@IsUpdate int output,
	@msg nvarchar(max) output
as
begin
	set @msg = 'You cannot make change selected users due to IDs are not existed.'
	set @IsUpdate=0
	if @GroupID <> 0
	begin
		DECLARE @TempStr nvarchar(max)=''
		DECLARE @TblTempID TABLE(ID int)
		INSERT INTO @TblTempID SELECT Name FROM dbo.SA_SplitString(@StrID, ',')

		DECLARE @TempID NVARCHAR(10)=''
		DECLARE DB_CURSOR CURSOR FOR SELECT ID from @TblTempID
		OPEN DB_CURSOR 
	
		FETCH NEXT FROM DB_CURSOR INTO @TempID
		WHILE @@FETCH_STATUS = 0
		BEGIN
			if exists(select UserNo from tblsa_set_user_privileges where GroupID=@GroupID and UserNo=@TempID)
			begin
				delete from tblsa_set_user_privileges 
				where GroupID=@GroupID 
					and UserNo=@TempID 			
				set @TempStr=@TempStr +(select top 1 CardID from tblsa_set_userlog where UserNo=@TempID)+', ' 			
				set @IsUpdate=1
			end

			FETCH NEXT FROM DB_CURSOR INTO @TempID		
		END
		CLOSE DB_CURSOR
		DEALLOCATE DB_CURSOR
	
		if len(@TempStr)>0
		begin
			set @TempStr=LEFT(@TempStr, LEN(@TempStr)-1)
		end
		if @IsUpdate=1
		begin
			set @msg = 'Card ID: ' +@TempStr +' have been permanently removed from group '+(select top 1 Name from tblsa_set_groups where ID=@GroupID) +'.'
		end
	end

	select @IsUpdate, @Msg
end
go

---------20191028
drop procedure SA_SaveGroupPermissions
go

create procedure SA_SaveGroupPermissions
	@GroupID int,
	@ControlList nvarchar(max),
	@User nvarchar(100),	
	@IsAdd int output,
	@msg nvarchar(max) output
as 
begin 
	set nocount on
	set @msg = 'You cannot make change selected users due to IDs are not existed.'
	set @IsAdd=0
	if @GroupID <> 0
	begin
		if exists(select GroupID from tblsa_set_group_permissions where GroupID=@GroupID)
		begin
			delete from tblsa_set_group_permissions where GroupID=@GroupID
		end

		DECLARE @TempStr nvarchar(max)=''
		DECLARE @TblTempID TABLE(ID nvarchar(200))
		INSERT INTO @TblTempID SELECT [Name] FROM dbo.SA_SplitString(@ControlList, ',')
				
		DECLARE @TempID NVARCHAR(200)=''
		DECLARE DB_CURSOR CURSOR FOR SELECT ID from @TblTempID
		OPEN DB_CURSOR 
	
		FETCH NEXT FROM DB_CURSOR INTO @TempID
		WHILE @@FETCH_STATUS = 0
		BEGIN
			declare @ControlID int = (select top 1 ID from tblsa_set_controls where ControlName=@TempID)
			if not exists(select GroupID from tblsa_set_group_permissions where GroupID=@GroupID and ControlID=@ControlID)
			begin
				insert into tblsa_set_group_permissions(GroupID, ControlID, Mark_Deleted, UserCreate, DateCreate) values(@GroupID, @ControlID, 0, @User, CURRENT_TIMESTAMP)
				set @TempStr=@TempStr +'- '+@TempID+char(10)+char(9)
				set @IsAdd=1
			end
			FETCH NEXT FROM DB_CURSOR INTO @TempID		
		END
		CLOSE DB_CURSOR
		DEALLOCATE DB_CURSOR
	
		if len(@TempStr)>0
		begin
			set @TempStr=LEFT(@TempStr, LEN(@TempStr)-1)
		end
		if @IsAdd=1
		begin
			set @msg = 'Group permissions: ' +char(10) +char(9) +@TempStr +'have been added to group '+(select top 1 [Name] from tblsa_set_groups where ID=@GroupID) +' successfully.'
		end
	end

	select @IsAdd, @Msg
end
go

---------20191028
--drop procedure SA_DeleteOldGroupPermissions
--go

--create procedure SA_DeleteOldGroupPermissions
--	@GroupID int
--as
--begin
--	if(@GroupID>0 )
--	begin
--		if exists(select GroupID from tblsa_set_group_permissions where GroupID=@GroupID)
--		begin
--			delete from tblsa_set_group_permissions where GroupID=@GroupID
--		end
--	end
--end
--go

---------------20191004
drop procedure SA_RemoveGroupPermissions
go

create procedure SA_RemoveGroupPermissions
	@GroupID int,
	@ControlList nvarchar(max),
	@IsUpdate int output,
	@Msg nvarchar(max) output
as
begin
	set @IsUpdate=0
	set @Msg='Selected permissions are not available to remove.'	
	if @GroupID <> 0
	begin
		DECLARE @TempStr nvarchar(max)=''
		DECLARE @TblTempID TABLE(ID NVARCHAR(max))
		INSERT INTO @TblTempID SELECT [Name] FROM dbo.SA_SplitString(@ControlList, ',')

		DECLARE @TempID NVARCHAR(max)
		DECLARE DB_CURSOR CURSOR FOR SELECT ID from @TblTempID
		OPEN DB_CURSOR 
	
		FETCH NEXT FROM DB_CURSOR INTO @TempID
		WHILE @@FETCH_STATUS = 0
		BEGIN
			declare @ControlID int = (select top 1 ID from tblsa_set_controls where ControlName=@TempID)

			if exists(select GroupID from tblsa_set_group_permissions where GroupID=@GroupID and ControlID=@ControlID)
			begin
				delete from tblsa_set_group_permissions where GroupID=@GroupID and ControlID=@ControlID		
				set @TempStr=@TempStr +'- '+@TempID+char(10)+char(9)
				set @IsUpdate=1
			end
			FETCH NEXT FROM DB_CURSOR INTO @TempID		
		END
		CLOSE DB_CURSOR
		DEALLOCATE DB_CURSOR

		if len(@TempStr)>0
		begin
			set @TempStr=LEFT(@TempStr, LEN(@TempStr)-1)
		end
		if @IsUpdate=1
		begin
			set @msg = 'Group permissions: ' +char(10) +char(9) +@TempStr +'have been removed from group '+(select top 1 [Name] from tblsa_set_groups where ID=@GroupID) +' successfully.'
		end
	end
	
	select @IsUpdate, @Msg	
end
go

---------20191030
drop procedure SA_SaveNewControls
go

create procedure SA_SaveNewControls	
	@Controls nvarchar(max),
	@Captions nvarchar(maX),
	@Mark_Deleted bit,
	@Excluded bit,
	@User nvarchar(100),
	@IsAdd int output,
	@Msg nvarchar(max) output
as
begin
	set @IsAdd = 0
	set @Msg = 'System Error: Cannot performance this operation while the code is empty.'
	DECLARE @TempStr nvarchar(max)=''

	DECLARE @TblControls TABLE(ID  int, ControlName nvarchar(max))
	INSERT INTO @TblControls SELECT ROW_NUMBER()OVER(ORDER BY (SELECT 1)), [Name] FROM dbo.SA_SplitString(@Controls, ',')

	DECLARE @TblCaptions TABLE(ID  int, CaptionName nvarchar(max))
	INSERT INTO @TblCaptions SELECT ROW_NUMBER()OVER(ORDER BY (SELECT 1)), [Name] FROM dbo.SA_SplitString(@Captions, ',')

	DECLARE @TblDataList TABLE(ControlName NVARCHAR(MAX), CaptionName NVARCHAR(MAX))
	INSERT INTO @TblDataList SELECT ControlName, CaptionName from @TblControls CO INNER JOIN @TblCaptions CA on CO.ID=CA.ID

	DECLARE @TempID NVARCHAR(max)=''
	DECLARE DB_CURSOR CURSOR FOR SELECT ControlName from @TblDataList
	OPEN DB_CURSOR 
	
	FETCH NEXT FROM DB_CURSOR INTO @TempID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		if not exists(select ID from tblsa_set_controls where ControlName=@TempID)
		begin
			declare @ControlID int = ISNULL( (select top 1 ID from tblsa_set_controls order by rand(ID) desc), 0) +1
	
			insert into tblsa_set_controls(ID, ControlName, Caption, Mark_Deleted, Excluded, UserCreate, DateCreate)
			select top 1 @ControlID, ControlName, CaptionName, @Mark_Deleted, @Excluded, @User, CURRENT_TIMESTAMP 
			from @TblDataList
			where ControlName=@TempID

			set @TempStr=@TempStr +'- '+@TempID+char(10)+char(9)
			set @IsAdd=1
		end
		else
		begin
			update tblsa_set_controls set
				Mark_Deleted=@Mark_Deleted,
				Excluded=@Excluded,
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP
			where ControlName=@TempID

			set @TempStr=@TempStr +'- '+@TempID+char(10)+char(9)
			set @IsAdd=2
		end

		FETCH NEXT FROM DB_CURSOR INTO @TempID		
	END
	CLOSE DB_CURSOR
	DEALLOCATE DB_CURSOR

	if len(@TempStr)>0
	begin
		set @TempStr=LEFT(@TempStr, LEN(@TempStr)-1)
	end
	if @IsAdd=1
	begin
		set @Msg = 'New group permissions: ' +char(10) +char(9) +@TempStr +'have been added successfully.'
	end 
	else if @IsAdd=2
	begin
		set @Msg = 'Group permissions: ' +char(10) +char(9) +@TempStr +'have been updated successfully.'
	end

	select @IsAdd, @Msg		
end
go

------20191030
drop procedure SA_GetUserLogByIDToList 
go

create procedure SA_GetUserLogByIDToList 
	@ID nvarchar(20)
as 
begin 
	if(len(@ID)>0)
	begin
		select top 1
			U.UserNo,
			U.CardID,
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as AccountName		
		FROM tblsa_set_userlog U
			left join tblsa_employee_cardid EID on U.CardID=EID.CardID
			left JOIN tblsa_employees E on EID.StaffNo=E.StaffNo
		where U.CardID=@ID 
			and (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
			and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
			and (E.Mark_Deleted=0 or E.Mark_Deleted is null)
	end
	else
	begin
		select 
			U.UserNo,
			U.CardID,
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as AccountName	
		FROM tblsa_set_userlog U
			left join tblsa_employee_cardid EID on U.CardID=EID.CardID
			left JOIN tblsa_employees E on EID.StaffNo=E.StaffNo
		Where (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
			and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
			and (E.Mark_Deleted=0 or E.Mark_Deleted is null)
		order by LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, '')))
	end
end
go

--------------------
drop procedure SA_GetUserAccountByID
go

create procedure SA_GetUserAccountByID
	@CardID nvarchar(10),
	@KC nvarchar(100)
as
begin
	if(len(@CardID)>0)
	begin
		if exists(select UserNo from tblsa_set_userlog where CardID=@CardID and (Mark_Deleted=0 or Mark_Deleted is null))
		begin
			select top 1
				'IsExisted' as IsExisted,
				u.UserNo,
				U.CardID,
				u.Name,
				E.CellPhone,
				u.UserID,
				u.Pass,
				u.Change_Pass_NextLog,
				u.User_Cannot_Change_Pass,
				u.Disabled_Acc,
				u.UserCreate,
				u.DateCreate,
				u.UserUpdate,
				u.DateUpdate
			from tblsa_set_userlog u
				left join tblsa_employee_cardid EID on U.CardID=EID.CardID
				inner join tblsa_employees E on EID.StaffNo=E.StaffNo
			where U.CardID=@CardID and (E.Mark_Deleted=0 or E.Mark_Deleted is null) and (u.Mark_Deleted=0 or u.Mark_Deleted is null)
		end
	end
end
go
	



-----------------------
drop procedure SA_GetNationalityList
go

create procedure SA_GetNationalityList
as 
begin 
	set nocount on
	select 
		ID,
		RTRIM(Nationality) as Nationality
	from tblsa_ms_location_countries order by Nationality
end
go


----------------------------------------
drop procedure SA_GetCountryList
go

create procedure SA_GetCountryList
as 
begin 
	set nocount on
	select 
		ID,
		RTRIM(Country) as Country
	from tblsa_ms_location_countries 
	order by Country
end
go

----------------------------------------
drop procedure SA_GetCityList
go

create procedure SA_GetCityList
	@ID int,
	@Flag bit
as 
begin 
	if @Flag=0 
	begin
		select 
			PID,
			RTRIM(City) as 'City/Province'
		from tblsa_ms_location_provinces order by City
	end
	else if @ID=0
	begin
		select
			PID,
			City,
			CityKH,
			PH_Code,
			Mark_Deleted as Inactive
		from tblsa_ms_location_provinces 
		order by City
	end
	else
	begin
		select top 1
			PID,
			City,
			CityKH,
			PH_Code
		from tblsa_ms_location_provinces 
		where PID=@ID
		order by City
	end
end
go


-------
drop procedure SA_GetKhanList
go

create procedure SA_GetKhanList
	@ID int,
	@CityID int,
	@Flag bit
as 
begin 
	if @Flag=0 
	begin
		select 
			KhanID,
			KhanEn as 'Khan/District'
		from tblsa_ms_location_khan 
		where CityID=@CityID
			and (Mark_Deleted=0 OR Mark_Deleted IS NULL)
		order by KhanEn
	end
	else if @ID=0
	begin
		select
			KhanID,
			KhanEn,
			KhanKh,
			PostalCode,
			CityID,
			Mark_Deleted as Inactive
		from tblsa_ms_location_khan 
		where CityID=@CityID
		order by KhanEn
	end
	else
	begin
		select top 1
			KhanID,
			KhanEn,
			KhanKh,
			PostalCode,
			CityID
		from tblsa_ms_location_khan 
		where KhanID=@ID
			and CityID=@CityID
		order by KhanEn
	end
end
go

--------------------20191104
drop procedure SA_IsUserAccessAllowed
go

create procedure SA_IsUserAccessAllowed
	@UserNo int,
	@RoleID int,
	@Permission nvarchar(max),
	@Flag int
as
begin
	if @Flag=0
	begin
		SELECT
			c.ID,
			c.Caption,
			c.ControlName,
			P.IsAllowed,
			P.UserCreate,
			P.DateCreate,
			P.UserUpdate,
			P.DateUpdate
		FROM tblsa_set_userlog_permissions P 
			INNER JOIN tblsa_set_controls c on P.Permission=c.ID 	
		WHERE P.UserNo=@UserNo
			and C.ControlName=@Permission
			and P.Mark_Deleted=0 or P.Mark_Deleted IS NULL
		ORDER BY c.Caption
	end
	else
	begin
		select
			c.ID,
			c.Caption,
			c.ControlName,
			P.IsAllowed,
			P.UserCreate,
			P.DateCreate,
			P.UserUpdate,
			P.DateUpdate
		FROM tblsa_set_userlog_permissions P 
			INNER JOIN tblsa_set_controls c on P.Permission=c.ID 	
		WHERE P.UserNo=@UserNo
			and P.RoleID=@RoleID
			and C.ControlName=@Permission
			and P.Mark_Deleted=0 or P.Mark_Deleted IS NULL
		ORDER BY c.Caption
	end
end
go


--------SAC------
--drop procedure SA_GetAllDepartmentsList
--go

--create procedure SA_GetAllDepartmentsList
--	@ClinicID int,
--	@Flag bit
--as 
--begin 
--	if @Flag=0 
--	begin
--		if @ClinicID=0
--		begin
--			select
--				0 as DepartmentID, 
--				'*** All departments' as Department,
--				'*** All clinics' as Clinic
--			UNION
--			select 
--				DepartmentID,
--				RTRIM(DepartmentEn) as Department,
--				CL.ABB as Clinic
--			from tblsa_ms_departments Dept
--				inner join tblsa_ms_clinic CL on Dept.ClinicID=CL.ClinicID
--			where Dept.Mark_Deleted=0 or Dept.Mark_Deleted is null 
--			order by Clinic, Department
--		end
--		else
--		begin
--			select top 1
--				99 as DepartmentID, 
--				'*** All departments' as Department,
--				ABB as Clinic
--			from tblsa_ms_clinic where ClinicID=@ClinicID
--			UNION
--			select 
--				DepartmentID,
--				RTRIM(DepartmentEn) as Department,
--				CL.ABB as Clinic
--			from tblsa_ms_departments Dept
--				inner join tblsa_ms_clinic CL on Dept.ClinicID=CL.ClinicID
--			where Dept.ClinicID=@ClinicID
--				and (Dept.Mark_Deleted=0 or Dept.Mark_Deleted is null) 
--			order by Department
--		end

--	end
--	else if @ClinicID=0
--	begin
--		select 
--			DepartmentID,
--			RTRIM(DepartmentEn) as Department,
--			CL.ABB as Clinic
--		from tblsa_ms_departments Dept
--			inner join tblsa_ms_clinic CL on Dept.ClinicID=CL.ClinicID
--		where Dept.Mark_Deleted=0 or Dept.Mark_Deleted is null 
--		order by Clinic, DepartmentEn
--	end
--	else
--	begin
--		select 
--			DepartmentID,
--			RTRIM(DepartmentEn) as Department,
--			CL.ABB as Clinic
--		from tblsa_ms_departments Dept
--			inner join tblsa_ms_clinic CL on Dept.ClinicID=CL.ClinicID
--		where (Dept.Mark_Deleted=0 or Dept.Mark_Deleted is null)
--			and Dept.ClinicID=@ClinicID
--		order by Clinic, DepartmentEn
--	end
--end
--go

-----------------------------------
--drop procedure SA_GetAllBuildingsList
--go

--create procedure SA_GetAllBuildingsList
--	@Flag bit
--as 
--begin 
--	if @Flag=0
--	begin
--		select
--			0 as BuildingID, 
--			'*** All buildings' as BuildingEn
--		UNION
--		select 
--			BuildingID,
--			BuildingEn
--		from tblsa_ms_buildings
--		where Mark_Deleted=0 or Mark_Deleted is null order by BuildingEn
--	end
--	else
--	begin
--		select 
--			BuildingID,
--			BuildingEn
--		from tblsa_ms_buildings
--		where Mark_Deleted=0 or Mark_Deleted is null order by BuildingEn	
--	end
--end
--go

-----------------------------------
--drop procedure SA_GetAllCampusesList
--go

--create procedure SA_GetAllCampusesList
--	@Flag bit
--as 
--begin 
--	if @Flag=0
--	begin
--		select
--			0 as CampusID, 
--			'All' as ShortName,
--			'*** All campuses' as Campus
--		UNION
--		select 
--			CampusID,
--			ABBR as ShortName,
--			RTRIM(CampusEn) as Campus
--		from tblsa_ms_campuses
--		where Mark_Deleted=0 or Mark_Deleted is null order by ShortName
--	end
--	else
--	begin
--		select 
--			CampusID,
--			ABBR as ShortName,
--			RTRIM(CampusEn) as Campus
--		from tblsa_ms_campuses
--		where Mark_Deleted=0 or Mark_Deleted is null order by ABBR	
--	end
--end
--go


	
-------------------------
drop procedure SA_GetAllRelationsList
go

create procedure SA_GetAllRelationsList
	@Flag bit
as 
begin 
	if @Flag=0
	begin
		select
			0 as RelationID, 
			'*** All relations' as Relation
		UNION
		select 
			RelationID,
			RTRIM(Relation) as Relation
		from tblsa_ms_relation order by Relation
	end
	else
	begin
		select 
			RelationID,
			RTRIM(Relation) as Relation
		from tblsa_ms_relation order by Relation
	end
end
go

----------------
--drop procedure SA_GetAllCampusesList
--go

--create procedure SA_GetAllCampusesList
--	@Flag bit
--as 
--begin 
--	if @Flag=0
--	begin
--		select
--			0 as CampusID, 
--			'*** All campuses' as CampusEn
--		UNION
--		select 
--			CampusID,
--			CampusEn
--		from tblsa_ms_campuses 
--		where Mark_Deleted=0 or Mark_Deleted is null 
--		order by CampusEn
--	end
--	else
--	begin
--		select 
--			CampusID,
--			CampusEn
--		from tblsa_ms_campuses 
--		where Mark_Deleted=0 or Mark_Deleted is null 
--		order by CampusEn	
--	end
--end
--go


---------------------------------
--drop procedure SA_GetDepartmentList
--go

--create procedure SA_GetDepartmentList
--as 
--begin 
--	set nocount on
--	select 
--		DepartmentID,
--		RTRIM(DepartmentEn) as Department
--	from tblsa_ms_departments
--	where Mark_Deleted=0 or Mark_Deleted is null order by DepartmentEn
--end
--go



--------------20191121
--drop procedure SA_GetDepartmentToListForAdmin 
--go

--create procedure SA_GetDepartmentToListForAdmin
--	@ClinicID int,
--	@Flag bit
--as 
--begin 
--	if @Flag=0
--	begin
--		if @ClinicID=0
--		begin
--			select 
--				Dept.DepartmentEn as Department, 
--				Dept.DepartmentKh as DepartmentInKhmer,
--				CL.ClinicEn,
--				count(EH.ID) as Staff,
--				Dept.DepartmentID as Code,
--				Dept.Mark_Deleted as Inactive,
--				Dept.UserCreate,
--				Dept.DateCreate,
--				Dept.UserUpdate,
--				Dept.DateUpdate
--			from tblsa_ms_departments Dept			
--				inner join tblsa_ms_clinic CL ON CL.ClinicID=Dept.ClinicID
--				left JOIN tblsa_employee_employment EH ON Dept.DepartmentID=EH.DepartmentID and EH.ClinicID=CL.ClinicID and EH.Mark_Deleted=0
--				left join tblsa_employee_cardid EID on EID.ID=EH.CardIDNo and EID.Mark_Deleted=0
--			where (Dept.Mark_Deleted=0 or Dept.Mark_Deleted is null)
--				and (EH.Mark_Deleted=0 OR EH.Mark_Deleted IS NULL)
--				and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
--			group by Dept.DepartmentEn,
--				Dept.DepartmentKh,
--				CL.ClinicEn,			
--				Dept.DepartmentID,
--				Dept.Mark_Deleted,
--				Dept.UserCreate,
--				Dept.DateCreate,
--				Dept.UserUpdate,
--				Dept.DateUpdate
--			order by Dept.DepartmentEn
--		end
--		else
--		begin
--			select 
--				Dept.DepartmentEn as Department, 
--				Dept.DepartmentKh as DepartmentInKhmer,
--				CL.ClinicEn,
--				count(EH.ID) as Staff,
--				Dept.DepartmentID as Code,
--				Dept.Mark_Deleted as Inactive,
--				Dept.UserCreate,
--				Dept.DateCreate,
--				Dept.UserUpdate,
--				Dept.DateUpdate
--			from tblsa_ms_departments Dept			
--				inner join tblsa_ms_clinic CL ON CL.ClinicID=Dept.ClinicID
--				left JOIN tblsa_employee_employment EH ON Dept.DepartmentID=EH.DepartmentID and EH.ClinicID=CL.ClinicID and EH.Mark_Deleted=0
--				left join tblsa_employee_cardid EID on EID.ID=EH.CardIDNo and EID.Mark_Deleted=0
--			where CL.ClinicID=@ClinicID
--				and (Dept.Mark_Deleted=0 or Dept.Mark_Deleted is null)
--				and (EH.Mark_Deleted=0 OR EH.Mark_Deleted IS NULL)
--				and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
--			group by Dept.DepartmentEn,
--				Dept.DepartmentKh,
--				CL.ClinicEn,				
--				Dept.DepartmentID,
--				Dept.Mark_Deleted,
--				Dept.UserCreate,
--				Dept.DateCreate,
--				Dept.UserUpdate,
--				Dept.DateUpdate
--			order by Dept.DepartmentEn
--		end
--	end
--	else
--	begin
--		if @ClinicID=0
--		begin
--			select 
--				Dept.DepartmentEn as Department, 
--				Dept.DepartmentKh as DepartmentInKhmer,
--				CL.ClinicEn,
--				count(EH.ID) as Staff,
--				Dept.DepartmentID as Code,
--				Dept.Mark_Deleted as Inactive,
--				Dept.UserCreate,
--				Dept.DateCreate,
--				Dept.UserUpdate,
--				Dept.DateUpdate
--			from tblsa_ms_departments Dept			
--				inner join tblsa_ms_clinic CL ON CL.ClinicID=Dept.ClinicID
--				left JOIN tblsa_employee_employment EH ON Dept.DepartmentID=EH.DepartmentID and EH.ClinicID=CL.ClinicID and EH.Mark_Deleted=0
--				left join tblsa_employee_cardid EID on EID.ID=EH.CardIDNo and EID.Mark_Deleted=0
--			where (EH.Mark_Deleted=0 OR EH.Mark_Deleted IS NULL)
--				and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
--			group by Dept.DepartmentEn,
--				Dept.DepartmentKh,
--				CL.ClinicEn,				
--				Dept.DepartmentID,
--				Dept.Mark_Deleted,
--				Dept.UserCreate,
--				Dept.DateCreate,
--				Dept.UserUpdate,
--				Dept.DateUpdate
--			order by Dept.DepartmentEn
--		end
--		else
--		begin
--			select 
--				Dept.DepartmentEn as Department, 
--				Dept.DepartmentKh as DepartmentInKhmer,
--				CL.ClinicEn,
--				count(EH.ID) as Staff,
--				Dept.DepartmentID as Code,
--				Dept.Mark_Deleted as Inactive,
--				Dept.UserCreate,
--				Dept.DateCreate,
--				Dept.UserUpdate,
--				Dept.DateUpdate
--			from tblsa_ms_departments Dept			
--				inner join tblsa_ms_clinic CL ON CL.ClinicID=Dept.ClinicID
--				left JOIN tblsa_employee_employment EH ON Dept.DepartmentID=EH.DepartmentID and EH.ClinicID=CL.ClinicID and EH.Mark_Deleted=0
--				left join tblsa_employee_cardid EID on EID.ID=EH.CardIDNo and EID.Mark_Deleted=0
--			WHERE CL.ClinicID=@ClinicID
--				and (EH.Mark_Deleted=0 OR EH.Mark_Deleted IS NULL)
--				and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
--			group by Dept.DepartmentEn,
--				Dept.DepartmentKh,
--				CL.ClinicEn,				
--				Dept.DepartmentID,
--				Dept.Mark_Deleted,
--				Dept.UserCreate,
--				Dept.DateCreate,
--				Dept.UserUpdate,
--				Dept.DateUpdate
--			order by Dept.DepartmentEn
--		end
--	end
--end
--go


----------
drop procedure SA_GetSectionToListForAdmin
go

create procedure SA_GetSectionToListForAdmin
	@SectionID int,
	@DeptID int
as 
begin 	
	if @DeptID=0
	begin
		if @SectionID=0
		begin
			select 
				Sec.SectionEn, 
				Sec.SectionKh,
				Dept.DepartmentEn,
				count(EH.ID) as Staff,				
				Sec.SectionID,			
				Sec.Mark_Deleted as Inactive,
				Sec.UserCreate,
				Sec.DateCreate,
				Sec.UserUpdate,
				Sec.DateUpdate
			from tblsa_ms_sections Sec
				inner join tblsa_ms_departments Dept on Dept.DepartmentID=Sec.DepartmentID
				LEFT JOIN tblsa_employee_employment EH ON Sec.SectionID = EH.SectionID and EH.DepartmentID=Dept.DepartmentID and EH.Mark_Deleted=0
				left join tblsa_employee_cardid EID on EID.ID=EH.CardIDNo and EID.Mark_Deleted=0
			where (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
				and (EH.Mark_Deleted=0 OR EH.Mark_Deleted IS NULL)
			group by Sec.SectionEn,
				Sec.SectionKH,			
				Dept.DepartmentEn,
				Sec.SectionID,
				Sec.Mark_Deleted,
				Sec.UserCreate,
				Sec.DateCreate,
				Sec.UserUpdate,
				Sec.DateUpdate
			order by Dept.DepartmentEn, Sec.SectionEn
		end
		else
		begin
			select top 1			
				SectionID,
				SectionKh,
				SectionEn,			
				ISNULL(DepartmentID, 0) as DepartmentID,			
				Mark_Deleted,
				UserCreate,
				DateCreate,
				UserUpdate,
				DateUpdate
			from tblsa_ms_sections		
			where SectionID=@SectionID
		end
	end
	else
	begin
		if @SectionID=0
		begin
			select 
				Sec.SectionID,
				Sec.SectionEn, 
				Dept.DepartmentEn
			from tblsa_ms_sections Sec
				inner join tblsa_ms_departments Dept on Dept.DepartmentID=Sec.DepartmentID
			where (Sec.Mark_Deleted=0 or Sec.Mark_Deleted is null)
				and Sec.DepartmentID=@DeptID											
			order by Dept.DepartmentEn, Sec.SectionEn
		end
		else
		begin
			select top 1			
				SectionID,
				SectionKh,
				SectionEn,			
				ISNULL(DepartmentID, 0) as DepartmentID,			
				Mark_Deleted,
				UserCreate,
				DateCreate,
				UserUpdate,
				DateUpdate
			from tblsa_ms_sections		
			where SectionID=@SectionID
		end
	end
end
go

------------------
drop procedure SA_DisabledSections
go

create procedure SA_DisabledSections
	@StrID nvarchar(max),
	@Inactive bit,
	@User int,
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'System Error: Cannot performance this operation while the code is empty.'
	DECLARE @TempStr nvarchar(max)=''
	DECLARE @TempStrNotUpdate nvarchar(max)=''

	DECLARE @TblTempID TABLE(ID int)
	INSERT INTO @TblTempID SELECT Name FROM dbo.SA_SplitString(@StrID, ',')

	DECLARE @TempID INT
	DECLARE DB_CURSOR CURSOR FOR SELECT ID from @TblTempID
	OPEN DB_CURSOR 
	
	FETCH NEXT FROM DB_CURSOR INTO @TempID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		declare @NumStaffs int=(select count(EH.ID)
									from tblsa_ms_sections Sec
										LEFT JOIN tblsa_employee_employment EH ON Sec.SectionID = EH.SectionID and Sec.DepartmentID=EH.DepartmentID
										left join tblsa_employee_cardid EID on EID.ID=EH.CardIDNo				
									where Sec.SectionID=@TempID
										and (EH.Mark_Deleted=0 or EH.Mark_Deleted is null)				
										and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL))
		if exists(select SectionID from tblsa_ms_sections where SectionID=@TempID)
		begin	
			if @Inactive=1 and @NumStaffs>0
			begin				
				declare @NonUpdateData nvarchar(max)=(select top 1 SectionEn from tblsa_ms_sections WHERE SectionID=@TempID)
				set @TempStrNotUpdate=@TempStrNotUpdate +  @NonUpdateData +', '
			end
			else
			begin
				update tblsa_ms_sections set 
					Mark_Deleted=@Inactive, 
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP				
				where SectionID=@TempID 
					
				set @IsAdd=1
				declare @UpdateData nvarchar(max)=(select top 1 SectionEn from tblsa_ms_sections WHERE SectionID=@TempID)
				set @TempStr=@TempStr +  @UpdateData +', '
			end
		end

		FETCH NEXT FROM DB_CURSOR INTO @TempID		
	END
	CLOSE DB_CURSOR
	DEALLOCATE DB_CURSOR

	if len(@TempStr)>0
	begin
		set @TempStr=LEFT(@TempStr, LEN(@TempStr)-1)
	end
	if len(@TempStrNotUpdate)>0
	begin
		set @TempStrNotUpdate=LEFT(@TempStrNotUpdate, LEN(@TempStrNotUpdate)-1)
	end

	if @Inactive=0
	begin
		set @Msg = 'Sections: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		declare @TempSMS nvarchar(max)=''
		if LEN(@TempStr)=0
		begin
			if LEN(@TempStrNotUpdate)>0
			begin
				set @Msg='Sections: ' +@TempStrNotUpdate +' cannot remove because there are some staff in the section.'
			end
		end
		else
		begin
			if LEN(@TempStrNotUpdate)>0
			begin
				set @Msg='Sections: ' + @TempStr + ' have been removed. Sections: ' +@TempStrNotUpdate +' cannot remove because there are some staff in the section.'
			end
			else
			begin
				set @Msg='Sections: ' + @TempStr + ' have been removed.'
			end
		end
	end

	select @IsAdd, @Msg	
end
go


---------------
drop procedure SA_GetSectionByID
go

create procedure SA_GetSectionByID
	@ID int
as
begin
	if @ID<>0
	begin
		select top 1			
			SectionID,
			SectionKh,
			SectionEn,			
			ISNULL(DepartmentID, 0) as DepartmentID,			
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_ms_sections		
		where SectionID=@ID
	end
	else
	begin
		select
			SectionID,
			SectionKh,
			SectionEn,			
			ISNULL(Sec.DepartmentID, 0) as DepartmentID,					
			Sec.Mark_Deleted as Inactive,
			Sec.UserCreate,
			Sec.DateCreate,
			Sec.UserUpdate,
			Sec.DateUpdate
		from tblsa_ms_sections Sec
			inner join tblsa_ms_departments Dept ON Dept.DepartmentID=Sec.DepartmentID
		order by Sec.SectionEn
	end
end
go
---------20191207
drop procedure SA_SaveSection
go

create procedure SA_SaveSection
	@ID int,	
	@DepartmentID int,
	@SectionEn nvarchar(max),
	@SectionKh nvarchar(max),	
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@SectionEn)>0 and @DepartmentID>0)
	begin
		if not exists(select SectionID from tblsa_ms_sections where DepartmentID=@DepartmentID and SectionEn=@SectionEn and SectionID<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		begin
			if @ID=0
			begin
				insert into tblsa_ms_sections(DepartmentID, SectionEn, SectionKh, Mark_Deleted, UserCreate, DateCreate) 
				values(@DepartmentID, LTRIM(RTRIM(@SectionEn)), LTRIM(RTRIM(@SectionKh)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Section name: ' +@SectionEn +' has been added successfully.'
			end
			else if exists(select SectionID from tblsa_ms_sections where SectionID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_ms_sections set				
					SectionEn=LTRIM(RTRIM(@SectionEn)),
					SectionKh=LTRIM(RTRIM(@SectionKh)),
					DepartmentID=DepartmentID,
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where SectionID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Section name: ' +@SectionEn + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found'
			end
		end
		else
		begin
			set @Msg = 'Section name: ' +@SectionEn  +' already exists in the system.'
		end
	end

	select @IsAdd, @Msg
end
go



---------------------
--drop procedure SA_GetBuildingByID
--go

--create procedure SA_GetBuildingByID
--	@ID int
--as
--begin
--	if @ID<>0
--	begin
--		select top 1			
--			BuildingID,
--			BuildingEn,
--			Acronym,
--			BuildingKh,
--			AddressEn,
--			AddressKh,
--			ClinicID,
--			Mark_Deleted,
--			UserCreate,
--			DateCreate,
--			UserUpdate,
--			DateUpdate
--		from tblsa_ms_buildings		
--		where BuildingID=@ID
--	end
--	else
--	begin
--		select
--			BuildingID,
--			BuildingEn,
--			Acronym,
--			BuildingKh,
--			AddressEn,
--			AddressKh,
--			B.ClinicID,
--			CL.ClinicEn,
--			B.Mark_Deleted,
--			B.UserCreate,
--			B.DateCreate,
--			B.UserUpdate,
--			B.DateUpdate
--		from tblsa_ms_buildings	B
--			inner join tblsa_ms_clinic CL on CL.ClinicID=B.ClinicID
--		order by BuildingEn
--	end
--end
--go


----20191210---
--drop procedure SA_SaveCity
--go

--create procedure SA_SaveCity
--	@ID int,	
--	@CityEn nvarchar(max),
--	@CityKh nvarchar(max),
--	@User int,	
--	@IsAdd int output,
--	@Msg nvarchar(200) output
--as 
--begin 
--	set nocount on
--	set @IsAdd = 0
--	set @Msg = 'Cannot performance this operation while the code is empty.'

--	if(len(@CityEn)>0)
--	begin
--		if not exists(select PID from tblsa_ms_location_provinces where City=@CityEn and PID<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
--		begin
--			if @ID=0
--			begin
--				insert into tblsa_ms_location_provinces(City, CityKh, Mark_Deleted, UserCreate, DateCreate) 
--				values(LTRIM(RTRIM(@CityEn)), LTRIM(RTRIM(@CityKh)), 0, @User, CURRENT_TIMESTAMP)					
--				set @IsAdd=1
--				set @Msg = 'City: ' +@CityEn +' has been added successfully.'
--			end
--			else if exists(select PID from tblsa_ms_location_provinces where PID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
--			begin
--				update tblsa_ms_location_provinces set				
--					City=LTRIM(RTRIM(@CityEn)),
--					CityKh=LTRIM(RTRIM(@CityKh)),
--					UserUpdate=@User,
--					DateUpdate=CURRENT_TIMESTAMP
--				where PID=@ID 
--					and (Mark_Deleted=0 or Mark_Deleted is null)
			
--				set @IsAdd=2
--				set @Msg = 'City: ' +@CityEn + ' has been updated successfully.'
--			end
--			else
--			begin
--				set @Msg = 'Cannot make update due to the code is not found'
--			end
--		end
--		else
--		begin
--			set @Msg = 'City: ' +@CityEn  +' already exists in the system.'
--		end
--		------------------
--		--if not exists(select PID from MJQEPOS.dbo.tblsa_ms_location_provinces where City=@CityEn and PID<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
--		--begin
--		--	if @ID=0
--		--	begin
--		--		insert into MJQEPOS.dbo.tblsa_ms_location_provinces(City, CityKh, Mark_Deleted, UserCreate, DateCreate) 
--		--		values(LTRIM(RTRIM(@CityEn)), LTRIM(RTRIM(@CityKh)), 0, @User, CURRENT_TIMESTAMP)					
--		--	end
--		--	else if exists(select PID from MJQEPOS.dbo.tblsa_ms_location_provinces where PID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
--		--	begin
--		--		update MJQEPOS.dbo.tblsa_ms_location_provinces set				
--		--			City=LTRIM(RTRIM(@CityEn)),
--		--			CityKh=LTRIM(RTRIM(@CityKh)),
--		--			UserUpdate=@User,
--		--			DateUpdate=CURRENT_TIMESTAMP
--		--		where PID=@ID 
--		--			and (Mark_Deleted=0 or Mark_Deleted is null)			
--		--	end
--		--end
--		------------------
--	end

--	select @IsAdd, @Msg
--end
--go

--20191210---
drop procedure SA_SaveCity
go

create procedure SA_SaveCity
	@ID int,	
	@CityEn nvarchar(max),
	@CityKh nvarchar(max),
	@Code nvarchar(40),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@CityEn)>0)
	begin
		--if not exists(select PID from tblsa_ms_location_provinces where City=@CityEn and PID<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		if not exists(select PID from tblsa_ms_location_provinces where City=@CityEn and PID<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_ms_location_provinces(City, CityKh, PH_Code, Mark_Deleted, UserCreate, DateCreate) 
				values(LTRIM(RTRIM(@CityEn)), LTRIM(RTRIM(@CityKh)), LTRIM(RTRIM(@Code)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'City: ' +@CityEn +' has been added successfully.'
			end
			else if exists(select PID from tblsa_ms_location_provinces where PID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_ms_location_provinces set				
					City=LTRIM(RTRIM(@CityEn)),
					CityKh=LTRIM(RTRIM(@CityKh)),
					PH_Code=LTRIM(RTRIM(@Code)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where PID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'City: ' +@CityEn + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'City: ' +@CityEn  +' already exists in the system.'
		end

		--------------------
		if not exists(select PID from MJQEPOS.dbo.tblsa_ms_location_provinces where City=@CityEn and PID<>@ID)
		begin
			if @ID=0
			begin
				insert into MJQEPOS.dbo.tblsa_ms_location_provinces(City, CityKh, PH_Code, Mark_Deleted, UserCreate, DateCreate) 
				values(LTRIM(RTRIM(@CityEn)), LTRIM(RTRIM(@CityKh)), LTRIM(RTRIM(@Code)), 0, @User, CURRENT_TIMESTAMP)									
			end
			else if exists(select PID from MJQEPOS.dbo.tblsa_ms_location_provinces where PID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update MJQEPOS.dbo.tblsa_ms_location_provinces set				
					City=LTRIM(RTRIM(@CityEn)),
					CityKh=LTRIM(RTRIM(@CityKh)),
					PH_Code=LTRIM(RTRIM(@Code)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where PID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)			
			end			
		end	
		------------------
	end

	select @IsAdd, @Msg
end
go


---------20191121
drop procedure SA_DisabledCity
go

create procedure SA_DisabledCity
	@StrID nvarchar(max),
	@Inactive bit,
	@Permanent bit,
	@User nvarchar(100),
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'System Error: Cannot performance this operation while the code is empty.'
	DECLARE @TempStr nvarchar(max)=''
	DECLARE @TempStrNotUpdate nvarchar(max)=''

	DECLARE @TblTempID TABLE(ID int)
	INSERT INTO @TblTempID SELECT Name FROM dbo.SA_SplitString(@StrID, ',')

	DECLARE @TempID INT
	DECLARE DB_CURSOR CURSOR FOR SELECT ID from @TblTempID
	OPEN DB_CURSOR 
	
	FETCH NEXT FROM DB_CURSOR INTO @TempID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		declare @NumItems int=(select count(CL.PID)
									from tblsa_ms_location_provinces CL
										inner join tblsa_ms_location_khan KH on CL.PID=Kh.CityID		
									where CL.PID=@TempID
										and (CL.Mark_Deleted=0 or CL.Mark_Deleted is null)				
										and (Kh.Mark_Deleted=0 OR Kh.Mark_Deleted IS NULL))
		if exists(select PID from tblsa_ms_location_provinces where PID=@TempID)
		begin	
			if @Inactive=1 and @NumItems>0
			begin				
				declare @NonUpdateData nvarchar(max)=(select top 1 City from tblsa_ms_location_provinces WHERE PID=@TempID)
				set @TempStrNotUpdate=@TempStrNotUpdate +  @NonUpdateData +', '
			end
			else if @Inactive=1 and @Permanent=1
			begin
				delete from tblsa_ms_location_provinces
				where PID=@TempID
				set @IsAdd=2
			end
			else
			begin
				update tblsa_ms_location_provinces set 
					Mark_Deleted=@Inactive, 
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP				
				where PID=@TempID 
					
				set @IsAdd=1
				declare @UpdateData nvarchar(max)=(select top 1 City from tblsa_ms_location_provinces WHERE PID=@TempID)
				set @TempStr=@TempStr +  @UpdateData +', '
			end
		end

		FETCH NEXT FROM DB_CURSOR INTO @TempID		
	END
	CLOSE DB_CURSOR
	DEALLOCATE DB_CURSOR

	if len(@TempStr)>0
	begin
		set @TempStr=LEFT(@TempStr, LEN(@TempStr)-1)
	end
	if len(@TempStrNotUpdate)>0
	begin
		set @TempStrNotUpdate=LEFT(@TempStrNotUpdate, LEN(@TempStrNotUpdate)-1)
	end

	if @Inactive=0
	begin
		set @Msg = 'City: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		declare @TempSMS nvarchar(max)=''
		if LEN(@TempStr)=0
		begin
			if LEN(@TempStrNotUpdate)>0
			begin
				set @Msg='City: ' +@TempStrNotUpdate +' cannot remove because there are some staff in the City.'
			end
		end
		else
		begin
			if LEN(@TempStrNotUpdate)>0
			begin
				set @Msg='City: ' + @TempStr + ' have been removed. City: ' +@TempStrNotUpdate +' cannot remove because there are some staff in the City.'
			end
			else
			begin
				set @Msg='City: ' + @TempStr + ' have been removed.'
			end
		end
	end

	select @IsAdd, @Msg	
end
go

----20191210---
--drop procedure SA_SaveKhan
--go

--create procedure SA_SaveKhan
--	@ID int,	
--	@CityID int,
--	@KhanEn nvarchar(max),
--	@KhanKh nvarchar(max),
--	@User int,	
--	@IsAdd int output,
--	@Msg nvarchar(200) output
--as 
--begin 
--	set nocount on
--	set @IsAdd = 0
--	set @Msg = 'Cannot performance this operation while the code is empty.'

--	if(len(@KhanEn)>0 and @CityID>0)
--	begin
--		if not exists(select KhanID from tblsa_ms_location_khan where KhanEn=@KhanEn and CityID=@CityID and KhanID<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
--		begin
--			if @ID=0
--			begin
--				insert into tblsa_ms_location_khan(CityID, KhanEn, KhanKh, Mark_Deleted, UserCreate, DateCreate) 
--				values(@CityID, LTRIM(RTRIM(@KhanEn)), LTRIM(RTRIM(@KhanKh)), 0, @User, CURRENT_TIMESTAMP)					
--				set @IsAdd=1
--				set @Msg = 'Khan: ' +@KhanEn +' has been added successfully.'
--			end
--			else if exists(select KhanID from tblsa_ms_location_khan where KhanID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
--			begin
--				update tblsa_ms_location_khan set				
--					KhanEn=LTRIM(RTRIM(@KhanEn)),
--					KhanKh=LTRIM(RTRIM(@KhanKh)),
--					UserUpdate=@User,
--					DateUpdate=CURRENT_TIMESTAMP
--				where KhanID=@ID 
--					and (Mark_Deleted=0 or Mark_Deleted is null)
			
--				set @IsAdd=2
--				set @Msg = 'Khan: ' +@KhanEn + ' has been updated successfully.'
--			end
--			else
--			begin
--				set @Msg = 'Cannot make update due to the code is not found'
--			end
--		end
--		else
--		begin
--			set @Msg = 'Khan: ' +@KhanEn  +' already exists in the system.'
--		end
--	end

--	select @IsAdd, @Msg
--end
--go

drop procedure SA_SaveKhan
go

create procedure SA_SaveKhan
	@ID int,	
	@CityID int,
	@KhanEn nvarchar(max),
	@KhanKh nvarchar(max),
	@Code nvarchar(40),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@KhanEn)>0 and @CityID>0)
	begin
		--if not exists(select KhanID from tblsa_ms_location_khan where KhanEn=@KhanEn and CityID=@CityID and KhanID<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		if not exists(select KhanID from tblsa_ms_location_khan where KhanEn=@KhanEn and CityID=@CityID and KhanID<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_ms_location_khan(CityID, KhanEn, KhanKh, PostalCode, Mark_Deleted, UserCreate, DateCreate) 
				values(@CityID, LTRIM(RTRIM(@KhanEn)), LTRIM(RTRIM(@KhanKh)), LTRIM(RTRIM(@Code)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Khan: ' +@KhanEn +' has been added successfully.'
			end
			else if exists(select KhanID from tblsa_ms_location_khan where KhanID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_ms_location_khan set				
					KhanEn=LTRIM(RTRIM(@KhanEn)),
					KhanKh=LTRIM(RTRIM(@KhanKh)),
					PostalCode=LTRIM(RTRIM(@Code)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where KhanID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Khan: ' +@KhanEn + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'Khan: ' +@KhanEn  +' already exists in the system.'
		end

		--------add khan to MJQEWarehouse
		--if not exists(select KhanID from MJQEPOS.dbo.tblsa_ms_location_khan where KhanEn=@KhanEn and CityID=@CityID and KhanID<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		if not exists(select KhanID from MJQEPOS.dbo.tblsa_ms_location_khan where KhanEn=@KhanEn and CityID=@CityID and KhanID<>@ID)
		begin
			if @ID=0
			begin
				insert into MJQEPOS.dbo.tblsa_ms_location_khan(CityID, KhanEn, KhanKh, PostalCode, Mark_Deleted, UserCreate, DateCreate) 
				values(@CityID, LTRIM(RTRIM(@KhanEn)), LTRIM(RTRIM(@KhanKh)), LTRIM(RTRIM(@Code)), 0, @User, CURRENT_TIMESTAMP)									
			end
			else if exists(select KhanID from MJQEPOS.dbo.tblsa_ms_location_khan where KhanID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update MJQEPOS.dbo.tblsa_ms_location_khan set				
					KhanEn=LTRIM(RTRIM(@KhanEn)),
					KhanKh=LTRIM(RTRIM(@KhanKh)),
					PostalCode=LTRIM(RTRIM(@Code)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where KhanID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			end
		end
		-----------------------
	end

	select @IsAdd, @Msg
end
go

----
drop procedure SA_DisabledKhan
go

create procedure SA_DisabledKhan
	@StrID nvarchar(max),
	@Inactive bit,
	@Permanent bit,
	@User nvarchar(100),
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'System Error: Cannot performance this operation while the code is empty.'
	DECLARE @TempStr nvarchar(max)=''
	DECLARE @TempStrNotUpdate nvarchar(max)=''

	DECLARE @TblTempID TABLE(ID int)
	INSERT INTO @TblTempID SELECT Name FROM dbo.SA_SplitString(@StrID, ',')

	DECLARE @TempID INT
	DECLARE DB_CURSOR CURSOR FOR SELECT ID from @TblTempID
	OPEN DB_CURSOR 
	
	FETCH NEXT FROM DB_CURSOR INTO @TempID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		declare @NumItems int=(select count(KH.KhanID)
									from tblsa_ms_location_khan KH
										inner join tblsa_ms_location_sangkat SA on KH.KhanID=SA.KhanID		
									where KH.KhanID=@TempID
										and (KH.Mark_Deleted=0 or KH.Mark_Deleted is null)				
										and (SA.Mark_Deleted=0 OR SA.Mark_Deleted IS NULL))
		if exists(select KhanID from tblsa_ms_location_khan where KhanID=@TempID)
		begin	
			if @Inactive=1 and @NumItems>0
			begin				
				declare @NonUpdateData nvarchar(max)=(select top 1 KhanEn from tblsa_ms_location_khan WHERE KhanID=@TempID)
				set @TempStrNotUpdate=@TempStrNotUpdate +  @NonUpdateData +', '
			end
			else if @Inactive=1 and @Permanent=1
			begin
				delete from tblsa_ms_location_khan
				where KhanID=@TempID
				set @IsAdd=2
			end
			else
			begin
				update tblsa_ms_location_khan set 
					Mark_Deleted=@Inactive, 
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP				
				where KhanID=@TempID 
					
				set @IsAdd=1
				declare @UpdateData nvarchar(max)=(select top 1 KhanEn from tblsa_ms_location_khan WHERE KhanID=@TempID)
				set @TempStr=@TempStr +  @UpdateData +', '
			end
		end

		FETCH NEXT FROM DB_CURSOR INTO @TempID		
	END
	CLOSE DB_CURSOR
	DEALLOCATE DB_CURSOR

	if len(@TempStr)>0
	begin
		set @TempStr=LEFT(@TempStr, LEN(@TempStr)-1)
	end
	if len(@TempStrNotUpdate)>0
	begin
		set @TempStrNotUpdate=LEFT(@TempStrNotUpdate, LEN(@TempStrNotUpdate)-1)
	end

	if @Inactive=0
	begin
		set @Msg = 'Khan: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		declare @TempSMS nvarchar(max)=''
		if LEN(@TempStr)=0
		begin
			if LEN(@TempStrNotUpdate)>0
			begin
				set @Msg='Khan: ' +@TempStrNotUpdate +' cannot remove because there are some staff in the Khan.'
			end
		end
		else
		begin
			if LEN(@TempStrNotUpdate)>0
			begin
				set @Msg='Khan: ' + @TempStr + ' have been removed. Khan: ' +@TempStrNotUpdate +' cannot remove because there are some staff in the Khan.'
			end
			else
			begin
				set @Msg='Khan: ' + @TempStr + ' have been removed.'
			end
		end
	end

	select @IsAdd, @Msg	
end
go

--------20191211
-------
drop procedure SA_GetSangkatList
go

create procedure SA_GetSangkatList
	@ID int,
	@KhanID int,
	@Flag bit
as 
begin 
	if @Flag=0 
	begin
		select 
			SangkatID,
			SangkatEn as 'Sangkat/Commune'
		from tblsa_ms_location_sangkat 
		where KhanID=@KhanID
			and (Mark_Deleted=0 or Mark_Deleted IS NULL)
		order by SangkatEn
	end
	else if @ID=0
	begin
		select
			SangkatID,
			SangkatEn,
			SangkatKh,
			PostalCode,
			KhanID,
			Mark_Deleted as Inactive
		from tblsa_ms_location_sangkat 
		where KhanID=@KhanID
		order by SangkatEn
	end
	else
	begin
		select top 1
			SangkatID,
			SangkatEn,
			SangkatKh,
			PostalCode,
			KhanID
		from tblsa_ms_location_sangkat 
		where SangkatID=@ID
			and KhanID=@KhanID
		order by SangkatEn
	end
end
go

------------
----20191210---
--drop procedure SA_SaveSangkat
--go

--create procedure SA_SaveSangkat
--	@ID int,	
--	@KhanID int,
--	@SangkatEn nvarchar(max),
--	@SangkatKh nvarchar(max),
--	@User int,	
--	@IsAdd int output,
--	@Msg nvarchar(200) output
--as 
--begin 
--	set nocount on
--	set @IsAdd = 0
--	set @Msg = 'Cannot performance this operation while the code is empty.'

--	if(len(@SangkatEn)>0 and @KhanID>0)
--	begin
--		if not exists(select KhanID from tblsa_ms_location_sangkat where SangkatEn=@SangkatEn and KhanID=@KhanID and SangkatID<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
--		begin
--			if @ID=0
--			begin
--				insert into tblsa_ms_location_sangkat(KhanID, SangkatEn, SangkatKh, Mark_Deleted, UserCreate, DateCreate) 
--				values(@KhanID, LTRIM(RTRIM(@SangkatEn)), LTRIM(RTRIM(@SangkatKh)), 0, @User, CURRENT_TIMESTAMP)					
--				set @IsAdd=1
--				set @Msg = 'Sangkat: ' +@SangkatEn +' has been added successfully.'
--			end
--			else if exists(select SangkatID from tblsa_ms_location_sangkat where SangkatID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
--			begin
--				update tblsa_ms_location_sangkat set				
--					SangkatEn=LTRIM(RTRIM(@SangkatEn)),
--					SangkatKh=LTRIM(RTRIM(@SangkatKh)),
--					UserUpdate=@User,
--					DateUpdate=CURRENT_TIMESTAMP
--				where SangkatID=@ID 
--					and (Mark_Deleted=0 or Mark_Deleted is null)
			
--				set @IsAdd=2
--				set @Msg = 'Sangkat: ' +@SangkatEn + ' has been updated successfully.'
--			end
--			else
--			begin
--				set @Msg = 'Cannot make update due to the code is not found'
--			end
--		end
--		else
--		begin
--			set @Msg = 'Sangkat: ' +@SangkatEn  +' already exists in the system.'
--		end
--	end

--	select @IsAdd, @Msg
--end
--go

drop procedure SA_SaveSangkat
go

create procedure SA_SaveSangkat
	@ID int,	
	@KhanID int,
	@SangkatEn nvarchar(max),
	@SangkatKh nvarchar(max),
	@Code nvarchar(40),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@SangkatEn)>0 and @KhanID>0)
	begin
		--if not exists(select SangkatID from tblsa_ms_location_sangkat where SangkatEn=@SangkatEn and KhanID=@KhanID and SangkatID<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		if not exists(select SangkatID from tblsa_ms_location_sangkat where SangkatEn=@SangkatEn and KhanID=@KhanID and SangkatID<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_ms_location_sangkat(KhanID, SangkatEn, SangkatKh, PostalCode, Mark_Deleted, UserCreate, DateCreate) 
				values(@KhanID, LTRIM(RTRIM(@SangkatEn)), LTRIM(RTRIM(@SangkatKh)), LTRIM(RTRIM(@Code)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Sangkat: ' +@SangkatEn +' has been added successfully.'
			end
			else if exists(select SangkatID from tblsa_ms_location_sangkat where SangkatID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_ms_location_sangkat set				
					SangkatEn=LTRIM(RTRIM(@SangkatEn)),
					SangkatKh=LTRIM(RTRIM(@SangkatKh)),
					PostalCode=LTRIM(RTRIM(@Code)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where SangkatID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Sangkat: ' +@SangkatEn + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'Sangkat: ' +@SangkatEn  +' already exists in the system.'
		end

		---------add sangkat to MJQEWarehouse---------
		if not exists(select SangkatID from MJQEPOS.dbo.tblsa_ms_location_sangkat where SangkatEn=@SangkatEn and KhanID=@KhanID and SangkatID<>@ID)
		begin
			if @ID=0
			begin
				insert into MJQEPOS.dbo.tblsa_ms_location_sangkat(KhanID, SangkatEn, SangkatKh, PostalCode, Mark_Deleted, UserCreate, DateCreate) 
				values(@KhanID, LTRIM(RTRIM(@SangkatEn)), LTRIM(RTRIM(@SangkatKh)), LTRIM(RTRIM(@Code)), 0, @User, CURRENT_TIMESTAMP)									
			end
			else if exists(select SangkatID from MJQEPOS.dbo.tblsa_ms_location_sangkat where SangkatID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update MJQEPOS.dbo.tblsa_ms_location_sangkat set				
					SangkatEn=LTRIM(RTRIM(@SangkatEn)),
					SangkatKh=LTRIM(RTRIM(@SangkatKh)),
					PostalCode=LTRIM(RTRIM(@Code)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where SangkatID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)			
			end
		end
		------------------
	end

	select @IsAdd, @Msg
end
go

-------------------
----
drop procedure SA_DisabledSangkat
go

create procedure SA_DisabledSangkat
	@StrID nvarchar(max),
	@Inactive bit,
	@Permanent bit,
	@User nvarchar(100),
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'System Error: Cannot performance this operation while the code is empty.'
	DECLARE @TempStr nvarchar(max)=''
	DECLARE @TempStrNotUpdate nvarchar(max)=''

	DECLARE @TblTempID TABLE(ID int)
	INSERT INTO @TblTempID SELECT Name FROM dbo.SA_SplitString(@StrID, ',')

	DECLARE @TempID INT
	DECLARE DB_CURSOR CURSOR FOR SELECT ID from @TblTempID
	OPEN DB_CURSOR 
	
	FETCH NEXT FROM DB_CURSOR INTO @TempID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		declare @NumItems int=(select count(SA.SangkatID)
									from tblsa_ms_location_sangkat SA
										inner join tblsa_ms_location_village VI on SA.SangkatID=VI.SangkatID
									where SA.SangkatID=@TempID
										and (VI.Mark_Deleted=0 or VI.Mark_Deleted is null)				
										and (SA.Mark_Deleted=0 OR SA.Mark_Deleted IS NULL))
		if exists(select SangkatID from tblsa_ms_location_sangkat where SangkatID=@TempID)
		begin	
			if @Inactive=1 and @NumItems>0
			begin				
				declare @NonUpdateData nvarchar(max)=(select top 1 SangkatEn from tblsa_ms_location_sangkat WHERE SangkatID=@TempID)
				set @TempStrNotUpdate=@TempStrNotUpdate +  @NonUpdateData +', '
			end
			else if @Inactive=1 and @Permanent=1
			begin
				delete from tblsa_ms_location_sangkat
				where SangkatID=@TempID
				set @IsAdd=2
			end
			else
			begin
				update tblsa_ms_location_sangkat set 
					Mark_Deleted=@Inactive, 
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP				
				where SangkatID=@TempID 
					
				set @IsAdd=1
				declare @UpdateData nvarchar(max)=(select top 1 SangkatEn from tblsa_ms_location_sangkat WHERE SangkatID=@TempID)
				set @TempStr=@TempStr +  @UpdateData +', '
			end
		end

		FETCH NEXT FROM DB_CURSOR INTO @TempID		
	END
	CLOSE DB_CURSOR
	DEALLOCATE DB_CURSOR

	if len(@TempStr)>0
	begin
		set @TempStr=LEFT(@TempStr, LEN(@TempStr)-1)
	end
	if len(@TempStrNotUpdate)>0
	begin
		set @TempStrNotUpdate=LEFT(@TempStrNotUpdate, LEN(@TempStrNotUpdate)-1)
	end

	if @Inactive=0
	begin
		set @Msg = 'Sangkat: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		declare @TempSMS nvarchar(max)=''
		if LEN(@TempStr)=0
		begin
			if LEN(@TempStrNotUpdate)>0
			begin
				set @Msg='Sangkat: ' +@TempStrNotUpdate +' cannot remove because there are some staff in the Sangkat.'
			end
		end
		else
		begin
			if LEN(@TempStrNotUpdate)>0
			begin
				set @Msg='Sangkat: ' + @TempStr + ' have been removed. Khan: ' +@TempStrNotUpdate +' cannot remove because there are some staff in the Sangkat.'
			end
			else
			begin
				set @Msg='Sangkat: ' + @TempStr + ' have been removed.'
			end
		end
	end

	select @IsAdd, @Msg	
end
go

-------
drop procedure SA_GetVillageList
go

create procedure SA_GetVillageList
	@ID int,
	@SangkatID int,
	@Flag bit
as 
begin 
	if @Flag=0 
	begin
		select 
			VillageID,
			VillageEn as 'Village'
		from tblsa_ms_location_village 
		where SangkatID=@SangkatID
			and (Mark_Deleted=0 OR Mark_Deleted IS NULL)
		order by VillageEn
	end
	else if @ID=0
	begin
		select
			VillageID,
			VillageEn,
			VillageKh,
			SangkatID,
			Mark_Deleted as Inactive
		from tblsa_ms_location_village 
		where SangkatID=@SangkatID
		order by VillageEn
	end
	else
	begin
		select top 1
			VillageID,
			VillageEn,
			VillageKh,
			SangkatID,
			PostalCode
		from tblsa_ms_location_village 
		where VillageID=@ID
			and SangkatID=@SangkatID
		order by VillageEn
	end
end
go

----20191210---
--drop procedure SA_SaveVillage
--go

--create procedure SA_SaveVillage
--	@ID int,	
--	@SangkatID int,
--	@VillageEn nvarchar(max),
--	@VillageKh nvarchar(max),
--	@User int,	
--	@IsAdd int output,
--	@Msg nvarchar(200) output
--as 
--begin 
--	set nocount on
--	set @IsAdd = 0
--	set @Msg = 'Cannot performance this operation while the code is empty.'

--	if(len(@VillageEn)>0 and @SangkatID>0)
--	begin
--		if not exists(select VillageID from tblsa_ms_location_village where VillageEn=@VillageEn and SangkatID=@SangkatID and VillageID<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
--		begin
--			if @ID=0
--			begin
--				insert into tblsa_ms_location_village(SangkatID, VillageEn, VillageKh, Mark_Deleted, UserCreate, DateCreate) 
--				values(@SangkatID, LTRIM(RTRIM(@VillageEn)), LTRIM(RTRIM(@VillageKh)), 0, @User, CURRENT_TIMESTAMP)					
--				set @IsAdd=1
--				set @Msg = 'Village: ' +@VillageEn +' has been added successfully.'
--			end
--			else if exists(select SangkatID from tblsa_ms_location_village where VillageID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
--			begin
--				update tblsa_ms_location_village set				
--					VillageEn=LTRIM(RTRIM(@VillageEn)),
--					Villagekh=LTRIM(RTRIM(@VillageKh)),
--					UserUpdate=@User,
--					DateUpdate=CURRENT_TIMESTAMP
--				where VillageID=@ID 
--					and (Mark_Deleted=0 or Mark_Deleted is null)
			
--				set @IsAdd=2
--				set @Msg = 'Village: ' +@VillageEn + ' has been updated successfully.'
--			end
--			else
--			begin
--				set @Msg = 'Cannot make update due to the code is not found'
--			end
--		end
--		else
--		begin
--			set @Msg = 'Village: ' +@VillageEn  +' already exists in the system.'
--		end
--	end

--	select @IsAdd, @Msg
--end
--go

--20191210---
drop procedure SA_SaveVillage
go

create procedure SA_SaveVillage
	@ID int,	
	@SangkatID int,
	@VillageEn nvarchar(max),
	@VillageKh nvarchar(max),
	@Code nvarchar(40),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@VillageEn)>0 and @SangkatID>0)
	begin
		--if not exists(select VillageID from tblsa_ms_location_village where VillageEn=@VillageEn and SangkatID=@SangkatID and VillageID<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		if not exists(select VillageID from tblsa_ms_location_village where VillageEn=@VillageEn and SangkatID=@SangkatID and VillageID<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_ms_location_village(SangkatID, VillageEn, VillageKh, PostalCode, Mark_Deleted, UserCreate, DateCreate) 
				values(@SangkatID, LTRIM(RTRIM(@VillageEn)), LTRIM(RTRIM(@VillageKh)), LTRIM(RTRIM(@Code)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Village: ' +@VillageEn +' has been added successfully.'
			end
			else if exists(select SangkatID from tblsa_ms_location_village where VillageID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_ms_location_village set				
					VillageEn=LTRIM(RTRIM(@VillageEn)),
					Villagekh=LTRIM(RTRIM(@VillageKh)),
					PostalCode=LTRIM(RTRIM(@Code)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where VillageID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Village: ' +@VillageEn + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'Village: ' +@VillageEn  +' already exists in the system.'
		end

		---------add sangkat to MJQEWarehouse---------
		if not exists(select VillageID from MJQEPOS.dbo.tblsa_ms_location_village where VillageEn=@VillageEn and SangkatID=@SangkatID and VillageID<>@ID)
		begin
			if @ID=0
			begin
				insert into MJQEPOS.dbo.tblsa_ms_location_village(SangkatID, VillageEn, VillageKh, PostalCode, Mark_Deleted, UserCreate, DateCreate) 
				values(@SangkatID, LTRIM(RTRIM(@VillageEn)), LTRIM(RTRIM(@VillageKh)), LTRIM(RTRIM(@Code)), 0, @User, CURRENT_TIMESTAMP)					
			end
			else if exists(select SangkatID from MJQEWarehouse.dbo.tblsa_ms_location_village where VillageID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update MJQEPOS.dbo.tblsa_ms_location_village set				
					VillageEn=LTRIM(RTRIM(@VillageEn)),
					Villagekh=LTRIM(RTRIM(@VillageKh)),
					PostalCode=LTRIM(RTRIM(@Code)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where VillageID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)			
			end
		end
		----------------------------------------------
	end

	select @IsAdd, @Msg
end
go

-----------


drop procedure SA_DisabledVillage
go

create procedure SA_DisabledVillage
	@StrID nvarchar(max),
	@Inactive bit,
	@Permanent bit,
	@User nvarchar(100),
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'System Error: Cannot performance this operation while the code is empty.'
	DECLARE @TempStr nvarchar(max)=''
	DECLARE @TempStrNotUpdate nvarchar(max)=''

	DECLARE @TblTempID TABLE(ID int)
	INSERT INTO @TblTempID SELECT Name FROM dbo.SA_SplitString(@StrID, ',')

	DECLARE @TempID INT
	DECLARE DB_CURSOR CURSOR FOR SELECT ID from @TblTempID
	OPEN DB_CURSOR 
	
	FETCH NEXT FROM DB_CURSOR INTO @TempID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		if exists(select VillageID from tblsa_ms_location_village where VillageID=@TempID)
		begin	
			 if @Inactive=1 and @Permanent=1
			begin
				delete from tblsa_ms_location_village
				where VillageID=@TempID
				set @IsAdd=2
			end
			else
			begin
				update tblsa_ms_location_village set 
					Mark_Deleted=@Inactive, 
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP				
				where VillageID=@TempID 
					
				set @IsAdd=1
				declare @UpdateData nvarchar(max)=(select top 1 VillageEn from tblsa_ms_location_village WHERE VillageID=@TempID)
				set @TempStr=@TempStr +  @UpdateData +', '
			end
		end

		FETCH NEXT FROM DB_CURSOR INTO @TempID		
	END
	CLOSE DB_CURSOR
	DEALLOCATE DB_CURSOR

	if len(@TempStr)>0
	begin
		set @TempStr=LEFT(@TempStr, LEN(@TempStr)-1)
	end

	if @Inactive=0
	begin
		set @Msg = 'Village: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		set @Msg = 'Village: ' + @TempStr + ' have been removed.'
	end

	select @IsAdd, @Msg	
end
go


--20191210---
drop procedure SA_UpdateItemCode
go

create procedure SA_UpdateItemCode
	@ID int,	
	@Caption nvarchar(max),
	@Code nvarchar(max),
	@Flag nvarchar(30),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@Caption)>0 and len(@Code)>0 and @ID>0)
	begin
		if LOWER(@Flag)='phone_code'
		begin
			if exists(select PID from tblsa_ms_location_provinces where PID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_ms_location_provinces set				
					PH_Code=LTRIM(RTRIM(@Code))
				where PID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=1
				set @Msg = 'Phone code: '+@Code +' is updated in City: ' +@Caption + '.'
			end
		end
		else if LOWER(@Flag)='khan_postal_code'
		begin
			if exists(select KhanID from tblsa_ms_location_khan where KhanID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_ms_location_khan set				
					PostalCode=LTRIM(RTRIM(@Code))
				where KhanID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=1
				set @Msg = 'Postal code: '+@Code +' is updated in Khan: ' +@Caption + '.'
			end
		end
		else if LOWER(@Flag)='sangkat_postal_code'
		begin
			if exists(select SangkatID from tblsa_ms_location_sangkat where SangkatID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_ms_location_sangkat set				
					PostalCode=LTRIM(RTRIM(@Code))
				where SangkatID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=1
				set @Msg = 'Postal code: '+@Code +' is updated in Sangkat: ' +@Caption + '.'
			end
		end
	end

	select @IsAdd, @Msg
end
go

-------------
---------------------
drop procedure SA_SaveExchangeRate
go

create procedure SA_SaveExchangeRate
	@ID int,
	@NotifyDate date,
	@Rate float,
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'


	if(@Rate>0)
	begin
		if @ID=0
		begin
			--if not exists(select TranID from tblsa_set_exchange_rate where NotifiedDate=@NotifyDate and ExchangeRate=@Rate and (Mark_Deleted=0 or Mark_Deleted is null))
			if not exists(select TranID from tblsa_set_exchange_rate where NotifiedDate=@NotifyDate and ExchangeRate=@Rate)
			begin		
				insert into tblsa_set_exchange_rate(NotifiedDate, ExchangeRate, Mark_Deleted, UserCreate, DateCreate) 
				values(@NotifyDate, @Rate, 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Exchange rate $1=' +CONVERT(NVARCHAR(10), @Rate) + ' on '+CONVERT(NVARCHAR(10), @NotifyDate)+' has been set.'
			end
			else
			begin
				set @Msg = 'Exchange rate $1=' +CONVERT(NVARCHAR(10), @Rate) + ' on '+CONVERT(NVARCHAR(10), @NotifyDate)+' already exists.'
			end
		end
		else if exists(select TranID from tblsa_set_exchange_rate where TranID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		begin
			update tblsa_set_exchange_rate set
				NotifiedDate=@NotifyDate,
				ExchangeRate=@Rate,
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP
			where TranID=@ID and (Mark_Deleted=0 or Mark_Deleted is null)
			
			set @IsAdd=2
			set @Msg = 'Exchange rate $1=' +CONVERT(NVARCHAR(10), @Rate) + ' on '+CONVERT(NVARCHAR(10), @NotifyDate)+' has been updated.'
		end
		else if exists(select TranID from tblsa_set_exchange_rate where TranID=@ID)
		begin
			set @Msg = 'Exchange rate $1=' +CONVERT(NVARCHAR(10), @Rate) + ' on '+CONVERT(NVARCHAR(10), @NotifyDate) +' has been removed or deactivated.'
		end
	end

	select @IsAdd, @Msg
end
go

---------------------
drop procedure SA_SaveVAT
go

create procedure SA_SaveVAT
	@ID int,
	@NotifyDate date,
	@VAT float,
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'


	if(@VAT>=0)
	begin
		if @ID=0
		begin
			if not exists(select TranID from tblsa_set_vat where NotifiedDate=@NotifyDate and VAT=@VAT and (Mark_Deleted=0 or Mark_Deleted is null))
			begin		
				insert into tblsa_set_vat(NotifiedDate, VAT, Mark_Deleted, UserCreate, DateCreate) 
				values(@NotifyDate, @VAT, 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'VAT (%) ' +CONVERT(NVARCHAR(10), @VAT) + ' on '+CONVERT(NVARCHAR(10), @NotifyDate)+' has been set.'
			end
			else
			begin
				set @Msg = 'VAT (%) ' +CONVERT(NVARCHAR(10), @VAT) + ' on '+CONVERT(NVARCHAR(10), @NotifyDate)+' already exists.'
			end
		end
		else if exists(select TranID from tblsa_set_vat where TranID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		begin
			update tblsa_set_vat set
				NotifiedDate=@NotifyDate,
				VAT=@VAT,
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP
			where TranID=@ID and (Mark_Deleted=0 or Mark_Deleted is null)
			
			set @IsAdd=2
			set @Msg = 'VAT (%) ' +CONVERT(NVARCHAR(10), @VAT) + ' on '+CONVERT(NVARCHAR(10), @NotifyDate)+' has been updated.'
		end
		else if exists(select TranID from tblsa_set_vat where TranID=@ID)
		begin
			set @Msg = 'VAT (%) ' +CONVERT(NVARCHAR(10), @VAT) + ' on '+CONVERT(NVARCHAR(10), @NotifyDate) +' has been removed or deactivated.'
		end
	end

	select @IsAdd, @Msg
end
go

-------------------
drop procedure SA_GetExchangeRate
go

create procedure SA_GetExchangeRate
	@ID int,
	@Flag bit
as
begin
	if @ID<>0
	begin
		select top 1			
			TranID,
			NotifiedDate,
			ExchangeRate,			
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_set_exchange_rate		
		where TranID=@ID
	end
	else if @Flag=0
	begin
		select
			TranID,
			NotifiedDate,
			ExchangeRate,			
			Mark_Deleted as Inactive,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_set_exchange_rate
		order by NotifiedDate desc
	end
	else if @Flag=1
	begin
		select top 1
			TranID,
			NotifiedDate,
			ExchangeRate,			
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_set_exchange_rate
		order by NotifiedDate desc
	end
end
go

---------
drop procedure SA_GetVAT
go

create procedure SA_GetVAT
	@ID int,
	@Flag bit
as
begin
	if @ID<>0
	begin
		select top 1			
			TranID,
			NotifiedDate,
			VAT,			
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_set_vat		
		where TranID=@ID
	end
	else if @Flag=0
	begin
		select
			TranID,
			NotifiedDate,
			VAT,			
			Mark_Deleted as Inactive,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_set_vat
		order by NotifiedDate desc
	end
	else if @Flag=1
	begin
		select top 1
			TranID,
			NotifiedDate,
			VAT,			
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_set_vat
		order by NotifiedDate desc
	end
end
go


----------20191220
drop procedure SA_SaveSupplier
go

create procedure SA_SaveSupplier
	@ID int,
	@Company nvarchar(300),
	@CompanyCode nvarchar(100),
	@OfficePhone nvarchar(100),
	@Webiste nvarchar(100),
	@Email nvarchar(100),
	@Address nvarchar(max),
	@ContactPerson nvarchar(200),
	@CellPhone nvarchar(100),	
	@ContactEmail nvarchar(100),
	@Notes nvarchar(max),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'


	if(len(@Company)>0 and len(@OfficePhone)>0 and len(@ContactPerson)>0 and len(@CellPhone)>0)
	begin
		if @ID=0
		begin
			--if not exists(select CompanyID from tblsa_set_suppliers where Company=@Company and (Mark_Deleted=0 or Mark_Deleted is null))
			if not exists(select CompanyID from tblsa_set_suppliers where Company=@Company)
			begin		
				insert into tblsa_set_suppliers(Company, CompanyCode, OfficePhone, Website, Email, Address, ContactPerson, CellPhone, ContactEmail, Notes, Mark_Deleted, UserCreate, DateCreate) 
				values(LTRIM(RTRIM(@Company)), LTRIM(RTRIM(@CompanyCode)), LTRIM(RTRIM(@OfficePhone)), LTRIM(RTRIM(@Webiste)), LTRIM(RTRIM(@Email)), LTRIM(RTRIM(@Address)), LTRIM(RTRIM(@ContactPerson)), LTRIM(RTRIM(@CellPhone)), LTRIM(RTRIM(@ContactEmail)), LTRIM(RTRIM(@Notes)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Supplier ' +LTRIM(RTRIM(@Company)) +' has been saved successfully.'
			end
			else
			begin
				set @Msg = 'Supplier ' +LTRIM(RTRIM(@Company)) +' already exists on the system.'
			end
		end
		else if exists(select CompanyID from tblsa_set_suppliers where CompanyID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		begin
			update tblsa_set_suppliers set
				Company=LTRIM(RTRIM(@Company)),
				CompanyCode=LTRIM(RTRIM(@CompanyCode)),
				OfficePhone=LTRIM(RTRIM(@OfficePhone)),
				Website=LTRIM(RTRIM(@Webiste)),
				Email=LTRIM(RTRIM(@Email)),
				Address=LTRIM(RTRIM(@Address)),
				ContactPerson=LTRIM(RTRIM(@ContactPerson)),
				CellPhone=LTRIM(RTRIM(@CellPhone)),				
				ContactEmail=LTRIM(RTRIM(@ContactEmail)),
				Notes=LTRIM(RTRIM(@Notes)),
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP
			where CompanyID=@ID and (Mark_Deleted=0 or Mark_Deleted is null)
			
			set @IsAdd=2
			set @Msg = 'Supplier ' +LTRIM(RTRIM(@Company)) +' has been updated successfully.'
		end
		else if exists(select CompanyID from tblsa_set_suppliers where CompanyID=@ID)
		begin
			set @Msg = 'Supplier ' +LTRIM(RTRIM(@Company)) +' has been removed or deactivated.'
		end
	end

	select @IsAdd, @Msg
end
go


-------------------
drop procedure SA_GetSuppliersByID
go

create procedure SA_GetSuppliersByID
	@ID int,
	@isList int
as
begin
	if @ID<>0
	begin
		select top 1
			CompanyID,
			Company,
			CompanyCode,
			OfficePhone,
			Website,
			Email,
			Address,
			ContactPerson,
			CellPhone,
			--CellPhone2,
			ContactEmail,
			Notes,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_set_suppliers		
		where CompanyID=@ID
	end
	else if @isList=1
	begin
		select
			CompanyID,
			Company
		from tblsa_set_suppliers
		where Mark_Deleted=0 or Mark_Deleted IS NULL
		order by Company
	end
	else
	begin
		select
			CompanyID,
			Company,
			CompanyCode,
			OfficePhone,
			Website,
			Email,
			Address,
			ContactPerson,
			CellPhone,
			--CellPhone2,
			ContactEmail,
			Notes,
			Mark_Deleted as Inactive,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_set_suppliers
		order by Company
	end
end
go

-------------
---------20191121
drop procedure SA_DisabledSuppliers
go

create procedure SA_DisabledSuppliers
	@StrID nvarchar(max),
	@Inactive bit,
	@User nvarchar(100),
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'System Error: Cannot performance this operation while the code is empty.'
	DECLARE @TempStr nvarchar(max)=''
	DECLARE @TempStrNotUpdate nvarchar(max)=''

	DECLARE @TblTempID TABLE(ID int)
	INSERT INTO @TblTempID SELECT Name FROM dbo.SA_SplitString(@StrID, ',')

	DECLARE @TempID INT
	DECLARE DB_CURSOR CURSOR FOR SELECT ID from @TblTempID
	OPEN DB_CURSOR 
	
	FETCH NEXT FROM DB_CURSOR INTO @TempID
	WHILE @@FETCH_STATUS = 0
	BEGIN

		if exists(select CompanyID from tblsa_set_suppliers where CompanyID=@TempID)
		begin	
			update tblsa_set_suppliers set 
					Mark_Deleted=@Inactive, 
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP				
				where CompanyID=@TempID 
					
				set @IsAdd=1
				declare @UpdateData nvarchar(max)=(select top 1 Company from tblsa_set_suppliers H WHERE H.CompanyID=@TempID)
				set @TempStr=@TempStr +  @UpdateData +', '
		end

		FETCH NEXT FROM DB_CURSOR INTO @TempID		
	END
	CLOSE DB_CURSOR
	DEALLOCATE DB_CURSOR

	if len(@TempStr)>0
	begin
		set @TempStr=LEFT(@TempStr, LEN(@TempStr)-1)
	end
	
	if @Inactive=0
	begin
		set @Msg = 'Suppliers: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		set @Msg='Suppliers: ' + @TempStr + ' have been removed.'
	end

	select @IsAdd, @Msg	
end
go

--20191219
drop procedure SA_GetPrinterType
go

create procedure SA_GetPrinterType
as
begin
	select
		ID,
		PrinterType
	from tblsa_ms_printer_type
	order by PrinterType
end
go

----------20191121
--tblsa_patients_corporate_companies
--drop procedure SA_GetCorporateClientsByID
--go

--create procedure SA_GetCorporateClientsByID
--	@ID int,
--	@ClinicID int
--as
--begin
--	if @ClinicID=0
--	begin
--		if @ID<>0
--		begin
--			select top 1			
--				ID,
--				CorporateClient,
--				[Description],			
--				ClinicID,			
--				Mark_Deleted,
--				UserCreate,
--				DateCreate,
--				UserUpdate,
--				DateUpdate
--			from tblsa_cashier_cooporate_clients		
--			where ID=@ID
--		end
--		else
--		begin
--			select
--				ID,
--				CorporateClient,
--				[Description],
--				CC.ClinicID,		
--				MS.ClinicEn,
--				CC.Mark_Deleted as Inactive,
--				CC.UserCreate,
--				CC.DateCreate,
--				CC.UserUpdate,
--				CC.DateUpdate
--			from tblsa_cashier_cooporate_clients CC
--				inner join tblsa_ms_clinic MS on CC.ClinicID=MS.ClinicID
--			order by MS.ClinicEn, CorporateClient
--		end
--	end
--	else
--	begin
--		if @ID<>0
--		begin
--			select top 1			
--				ID,
--				CorporateClient,
--				[Description],			
--				ClinicID,			
--				Mark_Deleted,
--				UserCreate,
--				DateCreate,
--				UserUpdate,
--				DateUpdate
--			from tblsa_cashier_cooporate_clients	
--			where ID=@ID
--		end
--		else
--		begin
--			select
--				ID,
--				CorporateClient,
--				MS.ClinicEn				
--			from tblsa_cashier_cooporate_clients CC
--				inner join tblsa_ms_clinic MS on CC.ClinicID=MS.ClinicID
--			where CC.ClinicID=@ClinicID and (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
--			order by MS.ClinicEn, CorporateClient
--		end
--	end
--end
--go

------------


------------20191003
drop procedure SA_GetUserRoleByID 
go

create procedure SA_GetUserRoleByID
	@ID int
as
begin
	if @ID<>0
	begin
		select top 1
			RoleID as Code,
			RoleType,
			Remark,		
			Mark_Deleted as Inactive,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_ms_roles
		where RoleID=@ID 
		 --and (Mark_Deleted=0 or Mark_Deleted is null)
	end
	else
	begin
		select 
			RoleID as Code,
			RoleType,
			Remark,		
			Mark_Deleted as Inactive,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_ms_roles
		--where (Mark_Deleted=0 or Mark_Deleted is null)
		order by RoleType
	end
end
go


-------------
drop procedure SA_SaveUserRole
go

create procedure SA_SaveUserRole
	@ID int,
	@RoleType nvarchar(max),
	@Remark nvarchar(max),
	@User nvarchar(100),	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@RoleType)>0 and @ID>0)
	begin
		--if not exists(select RoleID from tblsa_ms_roles where RoleType=@RoleType and RoleID<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		if not exists(select RoleID from tblsa_ms_roles where RoleType=@RoleType and RoleID<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_ms_roles(RoleType, Remark, Mark_Deleted, UserCreate, DateCreate) 
				values(LTRIM(RTRIM(@RoleType)), LTRIM(RTRIM(@Remark)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'User type: ' +@RoleType +' has been added successfully.'
			end
			else if exists(select RoleID from tblsa_ms_roles where RoleID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_ms_roles set				
					RoleType=LTRIM(RTRIM(@RoleType)),
					Remark=LTRIM(RTRIM(@Remark)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where RoleID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'User type: ' +@RoleType +' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'User type: ' +@RoleType  +' already exists in the system.'
		end
	end

	select @IsAdd, @Msg
end
go

--------20191003
drop procedure SA_DisabledUserRole
go

create procedure SA_DisabledUserRole
	@StrID nvarchar(max),
	@Inactive bit,
	@User nvarchar(100),
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'System Error: Cannot performance this operation while the code is empty.'
	DECLARE @TempStr nvarchar(max)=''

	DECLARE @TblTempID TABLE(ID int)
	INSERT INTO @TblTempID SELECT Name FROM dbo.SA_SplitString(@StrID, ',')

	DECLARE @TempID INT
	DECLARE DB_CURSOR CURSOR FOR SELECT ID from @TblTempID
	OPEN DB_CURSOR 
	
	FETCH NEXT FROM DB_CURSOR INTO @TempID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		if exists(select RoleID from tblsa_ms_roles where RoleID=@TempID )
		begin	
			update tblsa_ms_roles set 
				Mark_Deleted=@Inactive, 
				DateUpdate=CURRENT_TIMESTAMP, 
				UserUpdate=@User 
			where RoleID=@TempID 
					
			set @IsAdd=1
			declare @AccountType nvarchar(max)=(select top 1 RoleType from tblsa_ms_roles H WHERE H.RoleID=@TempID)
			set @TempStr=@TempStr +  @AccountType +', '
		end

		FETCH NEXT FROM DB_CURSOR INTO @TempID		
	END
	CLOSE DB_CURSOR
	DEALLOCATE DB_CURSOR

	if len(@TempStr)>0
	begin
		set @TempStr=LEFT(@TempStr, LEN(@TempStr)-1)
	end
	if @Inactive=0
	begin
		set @Msg = 'Acccount Type: ' + @TempStr + ' have been restored successfully.'
	end 
	else 
	begin
		set @Msg = 'Acccount Type: ' + @TempStr + ' have been removed successfully.'
	end

	select @IsAdd, @Msg	
end
go

----------------------------

drop procedure SA_SaveGroup
go

create procedure SA_SaveGroup
	@ID int,
	@GroupName nvarchar(max),
	@Description nvarchar(max),
	@User nvarchar(100),	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@GroupName)>0 and @ID>0)
	begin
		--if not exists(select ID from tblsa_set_groups where Name=@GroupName and ID<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		if not exists(select ID from tblsa_set_groups where Name=@GroupName and ID<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_set_groups(Name, Description, Mark_Deleted, UserCreate, DateCreate) 
				values(LTRIM(RTRIM(@GroupName)), LTRIM(RTRIM(@Description)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Group name: ' +@GroupName +' has been added successfully.'
			end
			else if exists(select ID from tblsa_set_groups where ID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_set_groups set				
					Name=LTRIM(RTRIM(@GroupName)),
					Description=LTRIM(RTRIM(@Description)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where ID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Group name: ' +@GroupName +' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'Group name: ' +@GroupName  +' already exists in the system.'
		end
	end

	select @IsAdd, @Msg
end
go

---------------
---20191004
drop procedure SA_DisabledGroupType
go

create procedure SA_DisabledGroupType
	@StrID nvarchar(max),
	@Inactive bit,
	@User int,
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'System Error: Cannot performance this operation while the code is empty.'
	DECLARE @TempStr nvarchar(max)=''

	DECLARE @TblTempID TABLE(ID int)
	INSERT INTO @TblTempID SELECT Name FROM dbo.SA_SplitString(@StrID, ',')

	DECLARE @TempID INT
	DECLARE DB_CURSOR CURSOR FOR SELECT ID from @TblTempID
	OPEN DB_CURSOR 
	
	FETCH NEXT FROM DB_CURSOR INTO @TempID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		if exists(select ID from tblsa_set_groups where ID=@TempID)
		begin	
			update tblsa_set_groups set 
				Mark_Deleted=@Inactive, 
				DateUpdate=CURRENT_TIMESTAMP, 
				UserUpdate=@User 
			where ID=@TempID 
					
			set @IsAdd=1
			declare @AccountType nvarchar(max)=(select top 1 H.Name from tblsa_set_groups H inner join @TblTempID T on H.ID=T.ID WHERE H.ID=@TempID)
			set @TempStr=@TempStr +  @AccountType +', '
		end

		FETCH NEXT FROM DB_CURSOR INTO @TempID		
	END
	CLOSE DB_CURSOR
	DEALLOCATE DB_CURSOR

	if len(@TempStr)>0
	begin
		set @TempStr=LEFT(@TempStr, LEN(@TempStr)-1)
	end
	if @Inactive=0
	begin
		set @Msg = 'Group name: ' + @TempStr + ' have been restored successfully.'
	end 
	else 
	begin
		set @Msg = 'Group name: ' + @TempStr + ' have been removed successfully.'
	end

	select @IsAdd, @Msg	
end
go


----------------
drop procedure SA_SaveUserAccessPermissions
go

create procedure SA_SaveUserAccessPermissions	
	@UserNo int,
	@IsAllowed int,
	@RoleID int,
	@ControlList nvarchar(max),
	@KC nvarchar(100),
	@User int,
	@IsAdd int output,
	@Msg nvarchar(max) output
as
begin
	set @IsAdd=0
	set @Msg='Selected access permissions are not available to perform action.'	
	DECLARE @TempStr nvarchar(max)=''

	DECLARE @TblTempID TABLE(ID NVARCHAR(max))
	INSERT INTO @TblTempID SELECT Name FROM dbo.SA_SplitString(@ControlList, ',')

	DECLARE @TempID NVARCHAR(max)
	DECLARE DB_CURSOR CURSOR FOR SELECT ID from @TblTempID
	OPEN DB_CURSOR 
	
	FETCH NEXT FROM DB_CURSOR INTO @TempID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		if(@UserNo>0)
		begin			
			if @RoleID=0
			begin
				if @IsAllowed=1
				begin
					if not exists(select P.ID from tblsa_set_userlog_permissions P inner join tblsa_set_controls C ON P.Permission=C.ID where UserNo=@UserNo and ControlName=@TempID)
					begin
						insert into tblsa_set_userlog_permissions(UserNo, Permission, IsAllowed, RoleID, Mark_Deleted, UserCreate, DateCreate)
						select top 1 @UserNo, 
							ID,
							@IsAllowed,
							(select DBO.DECRYPT_TEXT(@KC, RoleID) from tblsa_set_userlog where UserNo=@UserNo),
							0,
							@User,
							CURRENT_TIMESTAMP
						from tblsa_set_controls 
						where ControlName=@TempID				
						set @TempStr=@TempStr +'- ' +@TempID +char(10) +char(9)
						set @IsAdd=1
					end
					else
					begin
						update tblsa_set_userlog_permissions set
							Permission=C.ID,
							IsAllowed=@IsAllowed,
							RoleID=DBO.DECRYPT_TEXT(@KC, U.RoleID),
							UserUpdate=@User,
							DateUpdate=CURRENT_TIMESTAMP
						from tblsa_set_userlog_permissions P 
							inner join tblsa_set_userlog U on P.UserNo=U.UserNo
							inner join tblsa_set_controls C ON P.Permission=C.ID 
						where P.UserNo=@UserNo and ControlName=@TempID
						set @TempStr=@TempStr +'- ' +@TempID +char(10) +char(9)
						set @IsAdd=2
					end
				end
				else
				begin
					if exists(select P.ID from tblsa_set_userlog_permissions P inner join tblsa_set_controls C ON P.Permission=C.ID where UserNo=@UserNo and ControlName=@TempID)
					begin
						delete tblsa_set_userlog_permissions 
						from  tblsa_set_userlog_permissions P 
							inner join tblsa_set_controls C ON P.Permission=C.ID 
						where UserNo=@UserNo and ControlName=@TempID
						set @TempStr=@TempStr +'- ' +@TempID +char(10) +char(9)
						set @IsAdd=3
					end
				end
			end
			else
			begin
				if exists(select P.ID from tblsa_set_userlog_permissions P inner join tblsa_set_controls C ON P.Permission=C.ID where UserNo=@UserNo and ControlName=@TempID)
				begin
					update tblsa_set_userlog_permissions set					
						RoleID=@RoleID,
						UserUpdate=@User,
						DateUpdate=CURRENT_TIMESTAMP
					from tblsa_set_userlog_permissions P 
						inner join tblsa_set_controls C ON P.Permission=C.ID 
					where P.UserNo=@UserNo and ControlName=@TempID
					set @TempStr=@TempStr +'- ' +@TempID +char(10) +char(9)
					set @IsAdd=4
				end
				else
				begin
					set @Msg = 'Please add selected permissions to user id ' +CONVERT(NVARCHAR(10), @UserNo) +' first.'
				end
			end
		end
		FETCH NEXT FROM DB_CURSOR INTO @TempID		
	END
	CLOSE DB_CURSOR
	DEALLOCATE DB_CURSOR
	
	if len(@TempStr)>0
	begin
		set @TempStr=LEFT(@TempStr, LEN(@TempStr)-1)
	end
	if @IsAdd=1
	begin
		set @Msg = 'Permissions: ' +char(10) +char(9) + @TempStr + 'have been added to user id ' +CONVERT(NVARCHAR(10), @UserNo) +'.'
	end 
	else if @IsAdd=2
	begin
		set @Msg = 'Permissions: ' +char(10) +char(9) + @TempStr + 'have been updated for user id ' +CONVERT(NVARCHAR(10), @UserNo) +'.'
	end
	else if @IsAdd=3
	begin
		set @Msg = 'Permissions: ' +char(10) +char(9) + @TempStr + 'have been removed from user id ' +CONVERT(NVARCHAR(10), @UserNo) +'.'
	end
	else if @IsAdd=4
	begin
		set @Msg = 'Permissions: ' +char(10) +char(9) + @TempStr + 'have been assigned to user id ' +CONVERT(NVARCHAR(10), @UserNo) +'.'
	end
	
	select @IsAdd, @Msg	
end
go


------20200104
drop procedure SA_GetUserAccount
go

create procedure SA_GetUserAccount
	@KC nvarchar(max)
as
begin
	select
		UserNo,
		u.Name as AccountName,
		(CASE DBO.DECRYPT_TEXT(@KC, u.RoleID) WHEN 1 THEN 'Undefined' ELSE T.RoleType END) as RoleType
	from tblsa_set_userlog U
		inner join tblsa_ms_roles T on DBO.DECRYPT_TEXT(@KC, u.RoleID)=T.RoleID
	where (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
	order by u.Name
end
go

