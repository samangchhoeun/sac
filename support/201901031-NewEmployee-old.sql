-------20190108
drop procedure SA_SaveEmployeeProfile
go

create procedure SA_SaveEmployeeProfile 
	@StaffNo int,
	@CardID nvarchar(20),
	@FirstName nvarchar(100),
	@LastName nvarchar(100),
	@KFirstName nvarchar(100),
	@KLastName nvarchar(100),
	@Sex nvarchar(10),
	@DOB date,
	@MaritalStatus nvarchar(50),
	@Nationality nvarchar(50),
	@Qualification nvarchar(100),
	@NSSF nvarchar(30),
	@WorkBookNo nvarchar(30),
	@Email nvarchar(100),
	@PersonalEmail nvarchar(100),
	@Phone nvarchar(100),
	@Phone2 nvarchar(100),
	@NationalID nvarchar(50),
	@NationalID_IssueDate date,
	@NationalID_ExpireDate date,
	@ContactAddress nvarchar(max),
	@PassportNo nvarchar(50),
	@Passport_IssueDate date,
	@Passport_ExpireDate date,
	@DOB_Country nvarchar(100),
	@DOB_City nvarchar(100),
	@DOB_Address nvarchar(max),
	@Cur_Country nvarchar(100),
	@Cur_City nvarchar(100),
	@Cur_Address nvarchar(max),
	@Position nvarchar(max),	
	@Department int,	
	@Campus int,
	@JoinDate date,
	@Em_Name nvarchar(100),
	@Em_Relation nvarchar(100),
	@Em_Phone nvarchar(100),
	@Em_Phone2 nvarchar(100),
	@IsExistImage tinyint,
	@Photo varbinary(max),
	@User nvarchar(100),	
	@IsAdd int output,
	@Msg nvarchar(max) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the employee id is empty.'
	--declare @RecID int=0
	declare @NewTranID int=0
	
	set @FirstName=LTRIM(RTRIM(@FirstName))
	set @LastName=LTRIM(RTRIM(@LastName))
	set @KFirstName=UPPER(LTRIM(RTRIM(@KFirstName)))
	set @KLastName=UPPER(LTRIM(RTRIM(@KLastName)))
	set @Phone=LTRIM(RTRIM(@Phone))
	set @Phone2=LTRIM(RTRIM(@Phone2))
	set @NationalID=LTRIM(RTRIM(@NationalID))
	set @DOB_Address=LTRIM(RTRIM(@DOB_Address))
	set @Cur_Address=LTRIM(RTRIM(@Cur_Address))
	set @Email=LTRIM(RTRIM(REPLACE(REPLACE(@Email, CHAR(13), ''), CHAR(10), '')))
	set @Qualification=LTRIM(RTRIM(@Qualification))
	set @Position=LTRIM(RTRIM(@Position))

	if(len(@CardID)>0 and len(@LastName)>0 and len(@FirstName)>0 and @StaffNo>0)
	begin
		if not exists(select StaffNo from tblsa_employees where FirstName=@FirstName and LastName=@LastName and DOB=DOB and Sex=@Sex and StaffNo=0 and Mark_Deleted=0)
		begin
			if @StaffNo=0
			begin
				set @StaffNo = ISNULL((select top 1 StaffNo from tblsa_employees order by rand(StaffNo) desc), 0) + 1
			end

			if not exists(select EID.StaffNo from tblsa_employee_cardid EID left join tblsa_employees E ON EID.StaffNo=E.StaffNo where E.StaffNo=@StaffNo and CardID=@CardID and EID.Mark_Deleted=0 and E.Mark_Deleted=0)
			begin
				insert into tblsa_employees(StaffNo, UserCreate, DateCreate) values(@StaffNo, @User, CURRENT_TIMESTAMP)
			
				if not exists(select ID from tblsa_employee_cardid where StaffNo=@StaffNo and CardID=@CardID and Mark_Deleted=0)
				begin
					insert into tblsa_employee_cardid(StaffNo, CardID, AccessCode, JoinDate, UserCreate, DateCreate) values(@StaffNo, @CardID, '65e881ac1f03ca658b1dd3aa245d28cc', @JoinDate, @User, CURRENT_TIMESTAMP)
				end

				if not exists(select StaffNo from tblsa_employee_contact where StaffNo=@StaffNo)
				begin
					insert into tblsa_employee_contact(StaffNo) values(@StaffNo)
				end

				if not exists(select 
								CardIDNo 
							from tblsa_employee_employment EH
								inner join tblsa_employee_cardid EID on EID.ID=EH.CardIDNo
							where EID.StaffNo=@StaffNo and EID.Mark_Deleted=0)
				begin
					set @NewTranID = ISNULL((select top 1 TranID from tblsa_employee_employment order by rand(TranID) desc), 0)+1
					
					insert into tblsa_employee_employment(TranID, CardIDNo, Position, Department, Campus, Reason, ApprovedBy, ApprovedDate, EffectiveDate, UserCreate, DateCreate) 
					select top 1 @NewTranID, EC.ID, @Position, @Department, @Campus, 'New Staff', 'HRD', CURRENT_TIMESTAMP, @JoinDate, @User, CURRENT_TIMESTAMP
					from tblsa_employee_employment ee
						inner join tblsa_employee_cardid ec on ec.ID=ee.CardIDNo
					where ec.StaffNo=@StaffNo and ec.CardID=@CardID and ec.Mark_Deleted=0
					
					update tblsa_employee_cardid set TranID=@NewTranID where StaffNo=@StaffNo and CardID=@CardID and Mark_Deleted=0
				end

				set @Msg = 'Employee '+ LTRIM(RTRIM(ISNULL(@FirstName, '') +' ' + ISNULL(@LastName, ''))) + ' with Card ID '+ @CardID+' has been registered successfully.'
			end
			else
			begin
				update tblsa_employees set DateUpdate=CURRENT_TIMESTAMP, UserUpdate=@User where StaffNo=@StaffNo and Mark_Deleted=0
				
				update tblsa_employee_cardid set
					JoinDate=@JoinDate,
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where StaffNo=@StaffNo and CardID=@CardID
				
				update tblsa_employee_contact set
					MaritalStatus=@MaritalStatus,
					Nationality=@Nationality,
					Qualification=@Qualification,
					NSSF=@NSSF,
					WorkBookNo=@WorkBookNo,
					NationalID=@NationalID,
					NationalID_IssueDate=@NationalID_IssueDate,
					NationalID_ExpireDate=@NationalID_ExpireDate,
					ContactAddress=@ContactAddress,
					PassportNo=@PassportNo,
					Passport_IssueDate=@Passport_IssueDate,
					Passport_ExpireDate=@Passport_ExpireDate,
					DOB_Country=@DOB_Country,
					DOB_City=@DOB_City,
					DOB_Address=@DOB_Address,
					Cur_Country=@Cur_Country,
					Cur_City=@Cur_City,
					Cur_Address=@Cur_Address,
					Em_Name=@Em_Name,
					Em_Relation=@Em_Relation,
					Em_Phone=@Em_Phone,
					Em_Phone2=@Em_Phone2
				where StaffNo=@StaffNo

				set @Msg = 'Employee '+ LTRIM(RTRIM(ISNULL(@FirstName, '') +' ' + ISNULL(@LastName, ''))) + ' with Card ID '+ @CardID+' has been updated successfully.'
			end
			
			update tblsa_employees set
				LastName=@LastName,
				FirstName=@FirstName,
				KLastName=@KLastName,
				KFirstName=@KFirstName,
				Sex=@Sex,
				DOB=@DOB,
				Phone=@Phone,
				Phone2=@Phone2,
				Email=@Email,
				PersonalEmail=@PersonalEmail
			where StaffNo=@StaffNo and Mark_Deleted=0
		
			if @IsExistImage=0 
			begin
				update tblsa_employees set Photo=@Photo where StaffNo=@StaffNo and Mark_Deleted=0
			end

			set @IsAdd = 1
		end
		else
		begin
			set @Msg = 'Employee '+ LTRIM(RTRIM(ISNULL(@FirstName, '') +' ' + ISNULL(@LastName, ''))) + ' with Card ID '+ @CardID +' already exists on the system.'
		end
	end

	select @IsAdd, @Msg
end
go

----------------20190108
drop procedure SA_GetEmployeeDetailByID 
go

create procedure SA_GetEmployeeDetailByID
	@ID nvarchar(20)
as 
begin 
	if(len(@ID)>0)
	begin
		select top 1
			EID.StaffNo,
			EID.CardID,
			LastName,
			FirstName,
			KLastName,
			KFirstName,
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Name,					
			Sex,
			DOB,
			Phone,
			Phone2,
			CardExpire,
			UserLevelID,
			MaritalStatus,
			Qualification,
			NSSF,
			WorkBookNo,
			Nationality,
			NationalID,
			NationalID_IssueDate,
			NationalID_ExpireDate,
			ContactAddress,
			PassportNo,
			Passport_IssueDate,
			Passport_ExpireDate,
			DOB_Country,
			DOB_City,
			DOB_Address,
			Cur_Country,
			Cur_City,
			Cur_Address,
			E.Email,
			E.PersonalEmail,
			EH.Position,
			EH.Department,
			EH.Campus,
			Em_Name,
			Em_Relation,
			Em_Phone,
			Em_Phone2,
			EID.JoinDate,
			(Case WHEN EJ.StopDate<=cast(GETDATE() as date) THEN 'Resigned' ELSE 'Working' END) as EmpStatus,	
			EJ.StopDate,
			Photo,
			E.UserCreate,
			E.DateCreate,
			E.UserUpdate,
			E.DateUpdate
		FROM tblsa_employee_cardid EID
			LEFT JOIN tblsa_employees E on EID.StaffNo=E.StaffNo
			LEFT JOIN tblsa_employee_contact EC ON E.StaffNo=EC.StaffNo
			LEFT JOIN tblsa_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
			LEFT JOIN tblsa_employee_resigns EJ ON EJ.CardIDNo=EID.ID
		WHERE EID.CardID=@ID
	end
	else
	begin
		select 
			EID.StaffNo,
			EID.CardID,
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Name,		
			LTRIM(RTRIM(ISNULL(KLastName, '') +' ' + ISNULL(KFirstName, ''))) as KName,						
			Sex,
			DOB,
			Phone,
			Phone2,
			CardExpire,
			UserLevelID,
			MaritalStatus,
			Qualification,
			NSSF,
			WorkBookNo,
			Nationality,
			NationalID,
			NationalID_IssueDate,
			NationalID_ExpireDate,
			ContactAddress,
			PassportNo,
			Passport_IssueDate,
			Passport_ExpireDate,
			DOB_Country,
			DOB_City,
			DOB_Address,
			Cur_Country,
			Cur_City,
			Cur_Address,
			E.Email,
			E.PersonalEmail,
			EH.Position,
			EH.Department,
			EH.Campus,
			Em_Name,
			Em_Relation,
			Em_Phone,
			Em_Phone2,
			EID.JoinDate,
			(Case WHEN EJ.StopDate<=cast(GETDATE() as date) THEN 'Resigned' ELSE 'Working' END) as EmpStatus,	
			EJ.StopDate,
			Photo,
			E.UserCreate,
			E.DateCreate,
			E.UserUpdate,
			E.DateUpdate
		FROM tblsa_employee_cardid EID
			LEFT JOIN tblsa_employees E on EID.StaffNo=E.StaffNo
			LEFT JOIN tblsa_employee_contact EC ON E.StaffNo=EC.StaffNo
			LEFT JOIN tblsa_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
			LEFT JOIN tblsa_employee_resigns EJ ON EJ.CardIDNo=EID.ID
		ORDER BY RIGHT(EID.CardID, 4) DESC
	end
end
go


-----20190109
drop procedure SA_GetStaffDetailByIDToList 
go

create procedure SA_GetStaffDetailByIDToList
	@ID nvarchar(20)
as 
begin 
	if(len(@ID)>0)
	begin
		select top 1
			EID.CardID,
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Name,
			LTRIM(RTRIM(ISNULL(KLastName, '') +' ' + ISNULL(KFirstName, ''))) as KName,
			Sex,
			--DOB,
			--Phone,
			--Phone2,
			EID.JoinDate,
			EH.Position,
			Dept.Department,
			--CO.Division,
			--CA.Campus
			(Case WHEN EJ.StopDate<=cast(GETDATE() as date) THEN 'Departed' ELSE 'Current' END) as EmpStatus
		FROM tblsa_new_employee_cardid EID
			LEFT JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
			LEFT JOIN tblsa_new_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
			LEFT JOIN tblsa_new_employee_resigns EJ ON EJ.CardIDNo=EID.ID
			LEFT OUTER JOIN tblsa_departments Dept ON EH.Department = Dept.ID
		WHERE EID.CardID=@ID 
			AND (E.Mark_Deleted=0 OR E.Mark_Deleted IS NULL)
			AND (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
	end
	else
	begin
		select 
			EID.CardID,
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Name,
			LTRIM(RTRIM(ISNULL(KLastName, '') +' ' + ISNULL(KFirstName, ''))) as KName,
			Sex,
			--DOB,
			--Phone,
			--Phone2,
			EID.JoinDate,
			EH.Position,
			Dept.Department,
			--CO.Division,
			--CA.Campus
			(Case WHEN EJ.StopDate<=cast(GETDATE() as date) THEN 'Departed' ELSE 'Current' END) as EmpStatus
		FROM tblsa_new_employee_cardid EID
			LEFT JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
			LEFT JOIN tblsa_new_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
			LEFT JOIN tblsa_new_employee_resigns EJ ON EJ.CardIDNo=EID.ID
			LEFT OUTER JOIN tblsa_departments Dept ON EH.Department = Dept.ID
		WHERE (E.Mark_Deleted=0 OR E.Mark_Deleted IS NULL)
			AND (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
		ORDER BY RIGHT(EID.CardID, 4) DESC
	end
end
go


-----------20190109----
drop procedure SA_GetEmployeeHistory 
go

create procedure SA_GetEmployeeHistory
	@CardID nvarchar(20)
as 
begin 
	if(len(@CardID)>0)
	begin
		select top 1
			EID.CardID,
			EID.ID,
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Name,			
			Phone,
			EID.JoinDate
		FROM tblsa_new_employee_cardid EID
			LEFT JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
		where EID.CardID=@CardID 
			AND (E.Mark_Deleted=0 OR E.Mark_Deleted IS NULL)
			AND (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
	end
end
go

-----------20190109----
--SA_GetEmploymentHistoryToList '6646', ''
drop procedure SA_GetEmploymentHistoryToList 
go

create procedure SA_GetEmploymentHistoryToList
	@CardID nvarchar(10),
	@TranID int
as 
begin 
	if(len(@CardID)>0)
	begin
		if(@TranID>0)
		begin
			select top 1
				EH.TranID,
				EH.CardIDNo,
				CardID,
				Position,
				--Division,
				Department,
				Section,
				Division,
				Campus,
				Reason,
				ISNULL(dbo.SA_FunGetManagementLevels(Management,' | ',' | '), '') as Management,
				EH.EffectiveDate,
				ApprovedBy,
				ApprovedDate,
				Remark,
				(case when EH.TranID=@TranID THEN 'Current' ELSE '' END) as [Status],
				EH.UserCreate,
				EH.DateCreate,
				EH.UserUpdate,
				EH.DateUpdate
			from tblsa_new_employee_employment EH
				INNER join tblsa_new_employee_cardid EID ON EID.ID=EH.CardIDNo
			where EH.TranID=@TranID and EID.CardID=@CardID 
				and (EH.Mark_Deleted=0 or EH.Mark_Deleted is null)

			--select top 1
			--	EH.TranID,
			--	EID.CardID,
			--	--Name,
			--	EH.Position,
			--	--b.Business as Division,
			--	Dept.Department,
			--	CO.Division,
			--	CA.Campus,
			--	EH.Reason,
			--	ISNULL(dbo.SA_FunGetManagementLevels(EH.Management,' | ',' | '), '') as Management,
			--	EH.EffectiveDate,
			--	EH.ApprovedBy,
			--	EH.ApprovedDate,
			--	EH.Remark,
			--	(case when EID.TranID=EH.TranID  THEN 'Current' ELSE '' END) as [Status],
			--	EH.UserCreate,
			--	EH.DateCreate,
			--	EH.UserUpdate,
			--	EH.DateUpdate
			--FROM tblsa_new_employee_cardid EID
			--	LEFT JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
			--	LEFT JOIN tblsa_new_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
			--	left join tblsa_divisions CO on EH.Division=CO.ID
			--	left join tblsa_departments Dept on EH.Department=Dept.ID
			--	left join tblSA_Campuses CA on EH.Campus=CA.Num
			--where EID.CardID=@CardID 
			--	and EH.TranID=@TranID 
			--	and (EH.Mark_Deleted=0 or EH.Mark_Deleted is null)
			--order by EffectiveDate desc
		end
		else
		begin
			------------
			select 
				EH.TranID,
				EID.CardID,
				--Name,
				EH.Position,
				--b.Business as Division,
				Dept.Department,
				Sec.Section,
				CO.Division,
				CA.Campus,
				EH.Reason,
				ISNULL(dbo.SA_FunGetManagementLevels(EH.Management,' | ',' | '), '') as Management,
				EH.EffectiveDate,
				EH.ApprovedBy,
				EH.ApprovedDate,
				EH.Remark,
				(case when EID.TranID=EH.TranID  THEN 'Current' ELSE '' END) as [Status],
				EH.UserCreate,
				EH.DateCreate,
				EH.UserUpdate,
				EH.DateUpdate
			FROM tblsa_new_employee_cardid EID
				INNER JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
				LEFT JOIN tblsa_new_employee_employment EH ON EID.ID=EH.CardIDNo 
				left join tblsa_divisions CO on EH.Division=CO.ID
				left join tblsa_departments Dept on EH.Department=Dept.ID
				left join tblsa_sections Sec on EH.Section=Sec.ID
				left join tblSA_Campuses CA on EH.Campus=CA.Num
			where EID.CardID=@CardID 
				and (EH.Mark_Deleted=0 or EH.Mark_Deleted is null)			
			order by EffectiveDate desc, DateCreate desc
		end
	end
end
go


-----------20190109----
--drop procedure SA_GetEmploymentHistoryListByID --'986'
--go

--create procedure SA_GetEmploymentHistoryListByID
--	@TranID nvarchar(20)
--as 
--begin 
--	if(len(@TranID)>0)
--	begin
--		select top 1
--			EH.TranID,
--			EH.CardIDNo,
--			CardID,
--			Position,
--			--Division,
--			Department,
--			Division,
--			Campus,
--			Reason,
--			ISNULL(dbo.SA_FunGetManagementLevels(Management,' | ',' | '), '') as Management,
--			EH.EffectiveDate,
--			ApprovedBy,
--			ApprovedDate,
--			Remark,
--			(case when EH.TranID=@TranID THEN 'Current' ELSE '' END) as [Status],
--			EH.UserCreate,
--			EH.DateCreate,
--			EH.UserUpdate,
--			EH.DateUpdate
--		from tblsa_new_employee_employment EH
--			left join tblsa_new_employee_cardid EID ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID
--		where EH.TranID=@TranID 
--			and (EH.Mark_Deleted=0 or EH.Mark_Deleted is null)
--	end
--end
--go


---------20190109
drop procedure SA_SaveEmploymentHistory                     
go

create procedure SA_SaveEmploymentHistory
	@TranID int,
	@CardIDNo int,
	@CardID nvarchar(20),
	@Name nvarchar(100),
	@Position nvarchar(100),
	@Division int,
	@Department int,
	@Section int,
	@Campus int,
	@Management nvarchar(100),
	@Reason nvarchar(300),
	@EffectiveDate date,
	@ApprovedBy nvarchar(300),
	@ApprovedDate date,
	@Remark nvarchar(3000),
	@User nvarchar(100),
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the employee id is empty.'	
	declare @TempTranID int = 0
	set @Position = LTRIM(RTRIM(@Position))
	set @Reason = (CASE WHEN LEN(LTRIM(RTRIM(@Reason)))=0 THEN 'New Staff' ELSE LTRIM(RTRIM(@Reason)) END)
	set @Remark = LTRIM(RTRIM(@Remark))
	set @ApprovedBy = (CASE WHEN LEN(LTRIM(RTRIM(@ApprovedBy)))=0 THEN 'HRD' ELSE LTRIM(RTRIM(@ApprovedBy)) END)

	if @CardIDNo=0
	begin
		Set @CardIDNo=(select top 1 ID from tblsa_new_employee_cardid where CardID=@CardID and Mark_Deleted=0)
	end

	--if(len(@CardID)>0 and @CardIDNo>0 and len(@Position)>0 and len(@ApprovedBy)>0)
	if(len(@CardID)>0 and @CardIDNo>0 and len(@Position)>0)
	begin
		if @TranID=0
		begin
			set @TranID = ISNULL((select top 1 TranID from tblsa_new_employee_employment order by rand(TranID) desc), 0)+1
		end
		
		if not exists(select ID from tblsa_new_employee_employment where CardIDNo=@CardIDNo and @TranID=0 and EffectiveDate>=@EffectiveDate and Mark_Deleted=0)
		begin
			if not exists(select ID from tblsa_new_employee_employment where CardIDNo=@CardIDNo and Position=@Position and Division=@Division and Department=@Department and Campus=@Campus and EffectiveDate=@EffectiveDate and Mark_Deleted=0 and TranID<>@TranID)
			begin
				if not exists(select ID from tblsa_new_employee_employment where CardIDNo=@CardIDNo and TranID=@TranID and Mark_Deleted=0)
				begin
					insert into tblsa_new_employee_employment(CardIDNo, TranID, UserCreate, DateCreate) values(@CardIDNo, @TranID, @User, CURRENT_TIMESTAMP)
					set @msg = 'Position ' + @Position +' has been designated for card id: '+ @CardID +' successfully.'
				end
				else
				begin
					update tblsa_new_employee_employment set DateUpdate=CURRENT_TIMESTAMP, UserUpdate=@User where CardIDNo=@CardIDNo and TranID=@TranID
					set @msg = 'Position ' + @Position +' has been updated for card id: '+ @CardID +' successfully.'
				end

				begin
					update tblsa_new_employee_employment set
						Position=@Position,
						Division=@Division,
						FinDivision=@Division,
						Department=@Department,
						Section=@Section,
						Campus=@Campus,
						EffectiveDate=@EffectiveDate,
						Reason=@Reason,
						Management=@Management,
						ApprovedBy=@ApprovedBy,
						ApprovedDate=@ApprovedDate,
						Remark=@Remark
					from tblsa_new_employee_employment
					where CardIDNo=@CardIDNo and TranID=@TranID
				end

				set @TempTranID = (SELECT top 1 TranID FROM tblsa_new_employee_employment WHERE CardIDNo=@CardIDNo and Mark_Deleted=0 ORDER BY EffectiveDate DESC)	
								
				if @TempTranID>0
				begin
					If exists(select ID from tblsa_new_employee_cardid where ID=@CardIDNo and CardID=@CardID and Mark_Deleted=0)
					begin
						update tblsa_new_employee_cardid set TranID=@TempTranID Where ID=@CardIDNo and CardID=@CardID and Mark_Deleted=0
					end
				end

				set @IsAdd = (Select top 1 TranID from tblsa_new_employee_employment where CardIDNo=@CardIDNo and TranID=@TranID and Mark_Deleted=0)

			end
			else
			begin
				set @msg = 'System Error: Cannot designate the position because effective is older than current.'
			end
		end
		else
		begin
			set @msg = 'System Error: Position '+ @Position +' has already been designated for card id '+ @CardID +' in the system.'
		end
	end

	select @IsAdd, @Msg
end
go

-----------20190210
drop procedure SA_GetStaffIDByCompany
go

create procedure SA_GetStaffIDByCompany
as 
begin 
	set nocount on
	select 
		CardID
	from tblsa_new_employee_cardid EID
		inner join tblsa_new_employees E on EID.StaffNo=E.StaffNo
	where (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
		and (E.Mark_Deleted=0 or E.Mark_Deleted is null)
	ORDER BY RIGHT(CardID, 4) DESC
end
go


--------20190210
drop procedure SA_GetPositionToListForAdmin
go

create procedure SA_GetPositionToListForAdmin
	@Flag bit
as 
begin 
	if @Flag=0
	begin
		select
			Position,
			PositionInKhmer,
			ID,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_new_positions	
		where Mark_Deleted=0 or Mark_Deleted is null
		order by Position
	end
	else
	begin
		select
			Position,
			PositionInKhmer,
			ID,
			Mark_Deleted as Inactive,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_new_positions		
		order by Position
	end
end
go

-----------------
drop procedure SA_SavePosition
go

create procedure SA_SavePosition
	@ID int,
	@Position nvarchar(200),
	@KhPosition nvarchar(max),
	@UserCreate nvarchar(100),
	@UserUpdate nvarchar(100),
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @msg = 'Cannot performance this operation while the position id is empty.'
	declare @RecID int=0
	set @Position=LTRIM(RTRIM(@Position))
	set	@KhPosition=LTRIM(RTRIM(@KhPosition))
	
	if(len(@Position)>0)
	begin
		if @ID=0
		begin
			set @RecID = ISNULL((select top 1 ID from tblsa_new_positions order by rand(ID) desc), 0)+1
		end
		else
		begin
			set @RecID=@ID
		end

		--if not exists(select ID from tblsa_new_positions where Position=@Position and ID<>@RecID and (Mark_Deleted = 0 or Mark_Deleted is null))
		--if not exists(select ID from tblsa_new_positions where ID<>@RecID and (Mark_Deleted = 0 or Mark_Deleted is null))
		--begin
			--if not exists(select ID from tblsa_new_positions where Position=@Position and ID=@RecID and (Mark_Deleted = 0 or Mark_Deleted is null))
			if not exists(select ID from tblsa_new_positions where ID=@RecID and (Mark_Deleted = 0 or Mark_Deleted is null))
			begin
				insert into tblsa_new_positions(ID, Mark_Deleted, UserCreate, DateCreate) values(@RecID, 0, @UserCreate, CURRENT_TIMESTAMP)
				set @Msg = 'Position '+ @Position +' is created successfully.'
			end	
			else
			begin
				update tblsa_new_positions set DateUpdate=CURRENT_TIMESTAMP, UserUpdate=@UserUpdate where ID=@RecID and Mark_Deleted=0 
				set @Msg = 'Position '+ @Position +' is updated successfully.'
			end

			begin
				update tblsa_new_positions set
					Position=@Position,
					PositionInKhmer=@KhPosition
				where ID=@RecID 
			end

			set @isAdd = (Select top 1 ID from tblsa_new_positions where ID=@RecID)
		--end
		--else
		--begin
		--	set @Msg = 'Position '+ @Position +' already exists in the system.'
		--end
	end

	select @IsAdd, @Msg
end
go

-----------20190211---
drop procedure SA_GetPositionToList
go

create procedure SA_GetPositionToList
as 
begin 
	select
		ID,
		Position,
		PositionInKhmer,
		UserCreate,
		DateCreate,
		UserUpdate,
		DateUpdate
	from tblsa_new_positions
	where Mark_Deleted=0 or Mark_Deleted is null
	order by Position
end
go


-------------20190211--
drop procedure SA_GetPositionByID
go

create procedure SA_GetPositionByID
	@ID nvarchar(20)
as 
begin 
	if(len(@ID)>0)
	begin
		select top 1
			ID,
			Position,
			PositionInKhmer,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_new_positions
		where ID=@ID
	end
end
go

--------------20190211---
drop procedure SA_GetEmployeesJoinDate 
go

create procedure SA_GetEmployeesJoinDate
	@CardID nvarchar(20)
as
begin
	if len(@CardID)>0
	begin
		select 
			EID.ID,
			EID.CardID,
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Name,
			LTRIM(RTRIM(ISNULL(KLastName, '') +' ' + ISNULL(KFirstName, ''))) as KhmerName,
			E.Sex,
			--E.DOB,
			EH.Position,
			CO.Division,
			Dept.Department,
			EID.JoinDate,
			(Case WHEN ER.StopDate<=cast(GETDATE() as date) THEN 'Resigned' ELSE 'Working' END) as EmpStatus,	
			ER.StopDate,
			EID.UserCreate,
			EID.DateCreate,
			EID.UserUpdate,
			EID.DateUpdate
		FROM tblsa_new_employee_cardid EID
			INNER JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
			left join tblsa_new_employee_resigns ER ON EID.ID=ER.CardIDNo
			LEFT JOIN tblsa_new_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
			left join tblsa_divisions CO on EH.Division=CO.ID
			left join tblsa_departments Dept on EH.Department=Dept.ID
		where EID.Mark_Deleted=0 
			and EID.CardID=@CardID
		ORDER BY RIGHT(CardID, 4) DESC
	end
	else
	begin
		select 
			EID.ID,
			EID.CardID,
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Name,
			LTRIM(RTRIM(ISNULL(KLastName, '') +' ' + ISNULL(KFirstName, ''))) as KhmerName,
			E.Sex,
			--E.DOB,
			EH.Position,
			CO.Division,
			Dept.Department,
			EID.JoinDate,
			(Case WHEN ER.StopDate<=cast(GETDATE() as date) THEN 'Resigned' ELSE 'Working' END) as EmpStatus,	
			ER.StopDate,
			EID.UserCreate,
			EID.DateCreate,
			EID.UserUpdate,
			EID.DateUpdate
		FROM tblsa_new_employee_cardid EID
			INNER JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
			left join tblsa_new_employee_resigns ER ON EID.ID=ER.CardIDNo
			LEFT JOIN tblsa_new_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
			left join tblsa_divisions CO on EH.Division=CO.ID
			left join tblsa_departments Dept on EH.Department=Dept.ID
		where EID.Mark_Deleted=0 
		ORDER BY RIGHT(CardID, 4) DESC
	end
end
go

-----------20190211---
drop procedure SA_GetEmployeeJoinDateByID 
go

create procedure SA_GetEmployeeJoinDateByID
	@ID int,
	@CardID nvarchar(20)
as
begin
	select top 1
		EID.ID,
		EID.CardID,
		LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Name,		
		JoinDate,
		EID.UserCreate,
		EID.DateCreate,
		EID.UserUpdate,
		EID.DateUpdate
	FROM tblsa_new_employee_cardid EID
		INNER JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
	where EID.ID=@ID 
		and EID.CardID=@CardID 
		and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
end
go


------------
drop procedure SA_ChangeEmployeeJoinDateByID 
go

create procedure SA_ChangeEmployeeJoinDateByID
	@ID int,
	@CardID nvarchar(20),
	@JoinDate date,	
	@UserUpdate nvarchar(100),
	@IsAdd int output,
	@Msg nvarchar(200) output
as
begin
	set @IsAdd = 0
	set @Msg = 'System Error: Could not perform changing employee join date.'
	declare @CurJoinDate nvarchar(max)

	if exists(select ID from tblsa_new_employee_cardid where ID=@ID and CardID=@CardID and (Mark_Deleted=0 or Mark_Deleted IS NULL))
	begin
		set @CurJoinDate=CONVERT(NVARCHAR(30), ISNULL((select top 1  JoinDate from tblsa_new_employee_cardid where ID=@ID and CardID=@CardID and (Mark_Deleted=0 or Mark_Deleted IS NULL)), ''))

		update tblsa_new_employee_cardid set
			JoinDate=@JoinDate,
			UserUpdate=@UserUpdate,
			DateUpdate=CURRENT_TIMESTAMP
		where ID=@ID and CardID=@CardID

		set @Msg='Employee ID: ' + @CardID +' is modified his/her join date.'
		set @IsAdd=(select top 1 ID from tblsa_new_employee_cardid where ID=@ID and CardID=@CardID and (Mark_Deleted=0 or Mark_Deleted IS NULL))
		
		insert into tblSA_ActivityLog(ID, VisitedAt, Activity, Machine_Name, Instant_Name, Server_IP_Address, Client_IP_Address) 
		select @ID, CURRENT_TIMESTAMP, 'Change Joindate from '+ @CurJoinDate +' to ' + CONVERT(NVARCHAR(MAX), ISNULL(@JoinDate, '')) + ' for employee id ' + @CardID +' at IPAddress ' + CONVERT(NVARCHAR(max), CLIENT_NET_ADDRESS), SERVERPROPERTY('ComputerNamePhysicalNetBIOS'), SERVERPROPERTY('InstanceName'), LOCAL_NET_ADDRESS, CLIENT_NET_ADDRESS from SYS.DM_EXEC_CONNECTIONS where SESSION_ID = @@SPID
	end

	select @IsAdd, @Msg
end
go

--------------
drop procedure SA_GetEmployeeInfoForNewAdd
go

create procedure SA_GetEmployeeInfoForNewAdd
	@ID nvarchar(20)
as 
begin 
	if(len(@ID)>0)
	begin
		select top 1
			EID.ID,
			EID.StaffNo,
			EID.CardID,
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Name,
			Phone,
			Photo,
			EID.JoinDate,			
			(Case WHEN ER.StopDate<=cast(GETDATE() as date) THEN 'Resigned' ELSE 'Working' END) as EmpStatus,	
			ER.StopDate,
			CAST(datediff(minute, CAST(ISNULL(EID.M_TimeIn, '') AS TIME), CAST(ISNULL(EID.M_TimeOut, '') AS TIME))/60.0+datediff(minute, CAST(ISNULL(EID.A_TimeIn, '') AS TIME), CAST(ISNULL(EID.A_TimeOut, '') AS TIME))/60.0+datediff(minute, CAST(ISNULL(EID.E_TimeIn, '') AS TIME), CAST(ISNULL(EID.E_TimeOut, '') AS TIME))/60.0 AS numeric(10, 3)) as WeekDayWH,
			CAST(datediff(minute, CAST(ISNULL(EID.SM_TimeIn, '') AS TIME), CAST(ISNULL(EID.SM_TimeOut, '') AS TIME))/60.0+datediff(minute, CAST(ISNULL(EID.SA_TimeIn, '') AS TIME), CAST(ISNULL(EID.SA_TimeOut, '') AS TIME))/60.0 AS numeric(10, 3)) as SaturdayWH,
			CAST(datediff(minute, CAST(ISNULL(EID.UM_TimeIn, '') AS TIME), CAST(ISNULL(EID.UM_TimeOut, '') AS TIME))/60.0+datediff(minute, CAST(ISNULL(EID.UA_TimeIn, '') AS TIME), CAST(ISNULL(EID.UA_TimeOut, '') AS TIME))/60.0 AS numeric(10, 3)) as SundayWH,
			E.UserCreate,
			E.DateCreate,
			E.UserUpdate,
			E.DateUpdate
		FROM tblsa_new_employee_cardid EID
			INNER JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
			left join tblsa_new_employee_resigns ER ON EID.ID=ER.CardIDNo
		WHERE EID.CardID=@ID 
			and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null) 
	end
	else
	begin
		select
			EID.ID,
			EID.StaffNo,
			EID.CardID,
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Name,			
			Phone,
			Photo,
			EID.JoinDate,			
			(Case WHEN ER.StopDate<=cast(GETDATE() as date) THEN 'Resigned' ELSE 'Working' END) as EmpStatus,	
			ER.StopDate,
			E.UserCreate,
			E.DateCreate,
			E.UserUpdate,
			E.DateUpdate
		FROM tblsa_new_employee_cardid EID
			INNER JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
			left join tblsa_new_employee_resigns ER ON EID.ID=ER.CardIDNo			
		WHERE (EID.Mark_Deleted=0 or EID.Mark_Deleted is null) 
		order by EID.EffectiveDate desc
	end
end
go

------------
drop procedure SA_GetStaffResignToList --'5595'
go

create procedure SA_GetStaffResignToList
	@CardID nvarchar(20),
	@ID int
as 
begin 
	if(len(@CardID)>0)
	begin
		if @ID>0
		begin
			select 
				ER.ID,
				EID.CardID,
				LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Name,
				--E.Name,
				--s.Photo,
				EID.JoinDate,
				ER.ResignCode,
				ER.RequestDate,
				ER.StopDate,
				ER.Reason,			
				HasResignLetter,
				ER.VerifiedBy,
				ER.DateVerify,
				ER.ApprovedBy,
				ER.ApprovedDate,
				ER.AcknowledgedBy,
				ER.DateAcknowledge,
				Remark, 
				ER.UserCreate,
				ER.DateCreate,
				ER.UserUpdate,
				ER.DateUpdate,
				(case when ER.StopDate>=CAST(GETDATE() AS DATE) OR ER.StopDate IS NULL OR ER.StopDate='' THEN 'Current' ELSE '' END) as [Status]
			FROM tblsa_new_employee_cardid EID
				INNER JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
				left join tblsa_new_employee_resigns ER ON EID.ID=ER.CardIDNo
				LEFT JOIN tblSA_ResignTypes R on R.ResignID=ER.ResignCode
			where EID.CardID=@CardID 
				and ER.ID=@ID 
				and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
				and (ER.Mark_Deleted=0 or ER.Mark_Deleted is null)
			order by EID.JoinDate desc
		end
		else
		begin
			select 
				ER.ID,
				EID.CardID,
				LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Name,			
				--E.Name,
				--s.Photo,
				EID.JoinDate,
				ER.RequestDate,
				ER.StopDate,
				r.ResignType,
				ER.Reason,			
				HasResignLetter,
				ER.ApprovedBy,
				ER.ApprovedDate,
				Remark, 
				ER.UserCreate,
				ER.DateCreate,
				ER.UserUpdate,
				ER.DateUpdate,
				(case when ER.StopDate>=CAST(GETDATE() AS DATE) OR ER.StopDate IS NULL OR ER.StopDate='' THEN 'Current' ELSE '' END) as [Status]
			FROM tblsa_new_employee_cardid EID
				INNER JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
				left join tblsa_new_employee_resigns ER ON EID.ID=ER.CardIDNo
				LEFT JOIN tblSA_ResignTypes R on R.ResignID=ER.ResignCode
			where EID.CardID=@CardID 
				and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
				and (ER.Mark_Deleted=0 or ER.Mark_Deleted is null)
			order by EID.JoinDate desc
		end
	end
	else
	begin
		select 
			ER.ID,
			EID.CardID,
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Name,			
			--E.Name,
			--s.Photo,
			EID.JoinDate,
			ER.RequestDate,
			ER.StopDate,
			r.ResignType,
			ER.Reason,
			HasResignLetter,
			ER.ApprovedBy,
			ER.ApprovedDate, 
			Remark,
			ER.UserCreate,
			ER.DateCreate,
			ER.UserUpdate,
			ER.DateUpdate,
			(case when ER.StopDate>=CAST(GETDATE() AS DATE) OR ER.StopDate IS NULL OR ER.StopDate='' THEN 'Current' ELSE '' END) as [Status]
		FROM tblsa_new_employee_cardid EID
			INNER JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
			left join tblsa_new_employee_resigns ER ON EID.ID=ER.CardIDNo
			LEFT JOIN tblSA_ResignTypes R on R.ResignID=ER.ResignCode 
		where (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
			and (ER.Mark_Deleted=0 or ER.Mark_Deleted is null)
		order by EID.JoinDate desc
	end
end
go

---------------------
drop procedure SA_SaveEmployeeResign                     
go

create procedure SA_SaveEmployeeResign
	@ID int,
	@CardID nvarchar(50),
	@ResignType int,
	@Reason nvarchar(max),
	@RequestedDate date,
	@StopDate date,
	@VerifiedBy nvarchar(100),
	@VerifiedDate date,
	@AckBy nvarchar(100),
	@AckDate date,
	@HasResignLetter bit,	
	@ApprovedBy nvarchar(300),
	@ApprovedDate date,
	@Remark nvarchar(3000),
	@UserCreate nvarchar(100),
	@UserUpdate nvarchar(100),
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the employeee id is empty.'
	declare @StaffNo int = 0
	declare @TempID int = 0

	if(len(@CardID)>0 and len(@Reason)>0 and @ResignType>0 and len(@ApprovedBy)>0)
	begin
		if exists(select ID from tblsa_new_employee_cardid where ID=@ID and CardID=@CardID and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
		begin
			if not exists(select ID from tblsa_new_employee_resigns where CardIDNo=@ID and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
			begin
				insert into tblsa_new_employee_resigns(CardIDNo, UserCreate, DateCreate) values(@ID, @UserCreate, CURRENT_TIMESTAMP)
				set @Msg = 'Employee id: ' + @CardID +' has submitted the resignation letter on ' + CONVERT(nvarchar(40), @RequestedDate) + '.' + char(13) + 'The Last day is on ' + CONVERT(nvarchar(40), @StopDate) + '.'
			end
			else
			begin
				update tblsa_new_employee_resigns set 
					UserUpdate=@UserUpdate, 
					DateUpdate=CURRENT_TIMESTAMP
				where CardIDNo=@ID and (Mark_Deleted=0 OR Mark_Deleted IS NULL)
				set @msg = 'Employee id: ' + @CardID +' has updated the resignation letter on ' + CONVERT(nvarchar(40), @RequestedDate) + '.' + char(13) + 'The Last day is on ' + CONVERT(nvarchar(40), @StopDate) + '.'
			end

			UPDATE tblsa_new_employee_resigns SET
				RequestDate=@RequestedDate,
				StopDate=@StopDate,
				ResignCode=@ResignType,
				Reason=@Reason,
				AcknowledgedBy=@AckBy,
				DateAcknowledge=@AckDate,
				VerifiedBy=@VerifiedBy,
				DateVerify=@VerifiedDate,
				HasResignLetter=@HasResignLetter,
				Remark=@Remark,
				ApprovedBy=@ApprovedBy,
				ApprovedDate=@ApprovedDate,
				Mark_Deleted=0,
				DateUpdate=CURRENT_TIMESTAMP, 
				UserUpdate=@UserUpdate 
			WHERE CardIDNo=@ID and (Mark_Deleted=0 OR Mark_Deleted IS NULL)

			set @IsAdd = 1
		end		
	end

	select @IsAdd, @Msg
end
go

---------20190211
drop procedure SA_UpdateEmployeeWorkingHours
go

create procedure SA_UpdateEmployeeWorkingHours
	@EmpIDList nvarchar(max),
	@Condition nvarchar(10),
	@TotalWorkingHour nvarchar(10),
	@M_TimeIn nvarchar(10),
	@M_TimeOut nvarchar(10),
	@A_TimeIn nvarchar(10),
	@A_TimeOut nvarchar(10),
	@E_TimeIn nvarchar(10),
	@E_TimeOut nvarchar(10),
	@SM_TimeIn nvarchar(10),
	@SM_TimeOut nvarchar(10),
	@SA_TimeIn nvarchar(10),
	@SA_TimeOut nvarchar(10),
	@UM_TimeIn nvarchar(10),
	@UM_TimeOut nvarchar(10),
	@UA_TimeIn nvarchar(10),
	@UA_TimeOut nvarchar(10),
	@EffectiveDate date,
	@UserCreate nvarchar(100),
	@UserUpdate nvarchar(100),
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the employee id is empty.'
	declare @TempCardIDNo int=0
	
	DECLARE @TblID TABLE (CardID NVARCHAR(MAX))
	INSERT INTO @TblID SELECT LTRIM([Name]) FROM dbo.SA_SplitString(@EmpIDList, ',')
	DECLARE @TempCardID NVARCHAR(20)
	DECLARE DB_CURSOR CURSOR FOR SELECT CardID from @TblID
	OPEN DB_CURSOR 
		FETCH NEXT FROM DB_CURSOR INTO @TempCardID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF(LEN(@EmpIDList)>0)
		BEGIN
			if exists(select ID from tblsa_new_employee_cardid where CardID=@TempCardID and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
			begin
				update tblsa_new_employee_cardid set
					UserUpdate=@UserUpdate,
					DateUpdate=CURRENT_TIMESTAMP
				where CardID=@TempCardID and (Mark_Deleted=0 or Mark_Deleted is null)

				exec SA_BackupEmployeeWorkingHours @TempCardID, @Condition, @TotalWorkingHour, @M_TimeIn, @M_TimeOut, @A_TimeIn, @A_TimeOut, @E_TimeIn, @E_TimeOut, @SM_TimeIn, @SM_TimeOut, @SA_TimeIn, @SA_TimeOut,	@UM_TimeIn, @UM_TimeOut, @UA_TimeIn, @UA_TimeOut, @EffectiveDate, @UserUpdate
				set @Msg = 'Employee id '+ @TempCardID + ' has been updated working hours successfully.'
				set @IsAdd = 2
			end
			else
			begin
				set @Msg = 'System Error: There is no profile info for employee id '+ @TempCardID +'.'
				--set @IsAdd = 1
			end

			begin
				update tblsa_new_employee_cardid set
					Condition=@Condition,
					TotalWorkingHour=@TotalWorkingHour,
					M_TimeIn=@M_TimeIn,
					M_TimeOut=@M_TimeOut,
					A_TimeIn=@A_TimeIn,
					A_TimeOut=@A_TimeOut,
					E_TimeIn=@E_TimeIn,
					E_TimeOut=@E_TimeOut,
					SM_TimeIn=@SM_TimeIn,
					SM_TimeOut=@SM_TimeOut,
					SA_TimeIn=@SA_TimeIn,
					SA_TimeOut=@SA_TimeOut,
					UM_TimeIn=@UM_TimeIn,
					UM_TimeOut=@UM_TimeOut,
					UA_TimeIn=@UA_TimeIn,
					UA_TimeOut=@UA_TimeOut,
					EffectiveDate=@EffectiveDate
				where CardID=@TempCardID and (Mark_Deleted=0 or Mark_Deleted is null)
			end

			FETCH NEXT FROM DB_CURSOR INTO @TempCardID
		END
	END
	CLOSE DB_CURSOR
	DEALLOCATE DB_CURSOR
		
	select @IsAdd, @Msg
end
go


------------------------
drop procedure SA_IsExistEmployeeDatails
go

create procedure SA_IsExistEmployeeDatails
	@CardID nvarchar(10)	
as 
begin
	if exists(select ID from tblsa_new_employee_cardid where CardID=@CardID and (Mark_Deleted=0 or Mark_Deleted is null))
	begin
		select
			CardID,
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Name
		FROM tblsa_new_employee_cardid EID
			LEFT JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
			left join tblsa_new_employee_resigns ER ON EID.ID=ER.CardIDNo
		where CardID=@CardID
			and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
			and (E.Mark_Deleted=0 or E.Mark_Deleted is null)
	end
end
go

-----------------
drop procedure SA_GetAllWorkingHoursToList --'6646, 5595, 6483, 5938', ''
go

create procedure SA_GetAllWorkingHoursToList
	@EmpIDList nvarchar(max),
	@ID int
as 
begin 
	DECLARE @TblID TABLE (CardID NVARCHAR(MAX))
	INSERT INTO @TblID
	SELECT LTRIM([Name])
	FROM dbo.SA_SplitString(@EmpIDList, ',')

	if @ID>0
	begin
		SELECT 
			EID.ID,
			--EID.StaffNo,
			EID.CardID,
			EID.Condition,
			EID.TotalWorkingHour,
			EID.M_TimeIn,
			EID.M_TimeOut,
			EID.A_TimeIn,
			EID.A_TimeOut,
			EID.E_TimeIn,
			EID.E_TimeOut,
			EID.SM_TimeIn,
			EID.SM_TimeOut,
			EID.SA_TimeIn,
			EID.SA_TimeOut,
			EID.UM_TimeIn,
			EID.UM_TimeOut,
			EID.UA_TimeIn,
			EID.UA_TimeOut,
			EID.EffectiveDate,
			EID.UserCreate,
			EID.DateCreate,
			EID.UserUpdate,
			EID.DateUpdate
		from tblsa_new_employee_cardid EID
			left join tblsa_new_employees E ON E.StaffNo=EID.StaffNo
			inner JOIN @TblID AS T2 ON EID.CardID=T2.CardID		
		where EID.ID=@ID 
			and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
	end
	else
	begin
		SELECT 
			EID.ID,
			--EID.StaffNo,
			EID.CardID,
			EID.Condition,
			EID.TotalWorkingHour,
			EID.M_TimeIn,
			EID.M_TimeOut,
			EID.A_TimeIn,
			EID.A_TimeOut,
			EID.E_TimeIn,
			EID.E_TimeOut,
			EID.SM_TimeIn,
			EID.SM_TimeOut,
			EID.SA_TimeIn,
			EID.SA_TimeOut,
			EID.UM_TimeIn,
			EID.UM_TimeOut,
			EID.UA_TimeIn,
			EID.UA_TimeOut,
			EID.EffectiveDate,
			EID.UserCreate,
			EID.DateCreate,
			EID.UserUpdate,
			EID.DateUpdate
		from tblsa_new_employee_cardid EID
			left join tblsa_new_employees E ON E.StaffNo=EID.StaffNo
			inner JOIN @TblID AS T2 ON EID.CardID=T2.CardID				
		where (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
	end	
end
go


---------------------
drop procedure SA_GetWorkingHoursToList
go

create procedure SA_GetWorkingHoursToList
	@CardID nvarchar(20),
	@ID int
as 
begin 
	if(len(@CardID)>0)
	begin
		if @ID>0
		begin
			select top 1 
				EID.ID,
				EID.CardID,
				EID.Condition,
				EID.TotalWorkingHour,
				EID.M_TimeIn,
				EID.M_TimeOut,
				EID.A_TimeIn,
				EID.A_TimeOut,
				EID.E_TimeIn,
				EID.E_TimeOut,
				EID.SM_TimeIn,
				EID.SM_TimeOut,
				EID.SA_TimeIn,
				EID.SA_TimeOut,
				EID.UM_TimeIn,
				EID.UM_TimeOut,
				EID.UA_TimeIn,
				EID.UA_TimeOut,
				EID.EffectiveDate,
				EID.UserCreate,
				EID.DateCreate,
				EID.UserUpdate,
				EID.DateUpdate
			from tblsa_new_employee_cardid EID
				left join tblsa_new_employees E ON E.StaffNo=EID.StaffNo				
			where EID.CardID=@CardID 
				and EID.ID=@ID 
				and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
		end
		else
		begin
			select
				EID.ID,
				EID.CardID,
				EID.Condition,
				EID.TotalWorkingHour,
				EID.M_TimeIn,
				EID.M_TimeOut,
				EID.A_TimeIn,
				EID.A_TimeOut,
				EID.E_TimeIn,
				EID.E_TimeOut,
				EID.SM_TimeIn,
				EID.SM_TimeOut,
				EID.SA_TimeIn,
				EID.SA_TimeOut,
				EID.UM_TimeIn,
				EID.UM_TimeOut,
				EID.UA_TimeIn,
				EID.UA_TimeOut,
				EID.EffectiveDate,
				EID.UserCreate,
				EID.DateCreate,
				EID.UserUpdate,
				EID.DateUpdate
			from tblsa_new_employee_cardid EID
				left join tblsa_new_employees E ON E.StaffNo=EID.StaffNo
			where EID.CardID=@CardID				
				and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
			order by EID.EffectiveDate desc
		end
	end
	else
	begin
		select
				EID.ID,
				EID.CardID,
				EID.Condition,
				EID.TotalWorkingHour,
				EID.M_TimeIn,
				EID.M_TimeOut,
				EID.A_TimeIn,
				EID.A_TimeOut,
				EID.E_TimeIn,
				EID.E_TimeOut,
				EID.SM_TimeIn,
				EID.SM_TimeOut,
				EID.SA_TimeIn,
				EID.SA_TimeOut,
				EID.UM_TimeIn,
				EID.UM_TimeOut,
				EID.UA_TimeIn,
				EID.UA_TimeOut,
				EID.EffectiveDate,
				EID.UserCreate,
				EID.DateCreate,
				EID.UserUpdate,
				EID.DateUpdate
			from tblsa_new_employee_cardid EID
				left join tblsa_new_employees E ON E.StaffNo=EID.StaffNo
			where (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
			order by EID.EffectiveDate desc
	end
end
go

---------------------
drop procedure SA_BackupEmployeeWorkingHours
go

create procedure SA_BackupEmployeeWorkingHours
	@CardIDNo int,
	@Condition nvarchar(10),
	@TotalWorkingHour nvarchar(10),
	@M_TimeIn nvarchar(10),
	@M_TimeOut nvarchar(10),
	@A_TimeIn nvarchar(10),
	@A_TimeOut nvarchar(10),
	@E_TimeIn nvarchar(10),
	@E_TimeOut nvarchar(10),
	@SM_TimeIn nvarchar(10),
	@SM_TimeOut nvarchar(10),
	@SA_TimeIn nvarchar(10),
	@SA_TimeOut nvarchar(10),
	@UM_TimeIn nvarchar(10),
	@UM_TimeOut nvarchar(10),
	@UA_TimeIn nvarchar(10),
	@UA_TimeOut nvarchar(10),
	@EffectiveDate date,
	@UserUpdate nvarchar(100)
as 
begin 
	if exists(select ID from tblsa_new_employee_cardid where ID=@CardIDNo and Condition=@Condition and TotalWorkingHour=@TotalWorkingHour and M_TimeIn=@M_TimeIn and M_TimeOut=@M_TimeOut and A_TimeIn=@A_TimeIn and A_TimeOut=@A_TimeOut and E_TimeIn=@M_TimeIn and E_TimeOut=@E_TimeOut and SM_TimeIn=@SM_TimeIn and SM_TimeOut=@SM_TimeOut and SA_TimeIn=@SA_TimeIn and SA_TimeOut=@SA_TimeOut and UM_TimeIn=@UM_TimeIn and UM_TimeOut=@UM_TimeOut and UA_TimeIn=@UA_TimeIn and UA_TimeOut=@UA_TimeOut)
	begin
		if not exists(select ID from tblsa_new_employee_workinghour_history where ID=@CardIDNo and Condition=@Condition and TotalWorkingHour=@TotalWorkingHour and M_TimeIn=@M_TimeIn and M_TimeOut=@M_TimeOut and A_TimeIn=@A_TimeIn and A_TimeOut=@A_TimeOut and E_TimeIn=@M_TimeIn and E_TimeOut=@E_TimeOut and SM_TimeIn=@SM_TimeIn and SM_TimeOut=@SM_TimeOut and SA_TimeIn=@SA_TimeIn and SA_TimeOut=@SA_TimeOut and UM_TimeIn=@UM_TimeIn and UM_TimeOut=@UM_TimeOut and UA_TimeIn=@UA_TimeIn and UA_TimeOut=@UA_TimeOut)
		begin
			insert into tblsa_new_employee_workinghour_history(
				CardIDNo,
				Condition,
				TotalWorkingHour,
				M_TimeIn,
				M_TimeOut,
				A_TimeIn,
				A_TimeOut,
				E_TimeIn,
				E_TimeOut,
				SM_TimeIn,
				SM_TimeOut,
				SA_TimeIn,
				SA_TimeOut,
				UM_TimeIn,
				UM_TimeOut,
				UA_TimeIn,
				UA_TimeOut,
				EffectiveDate,
				UserCreate,
				DateCreate,
				UserUpdate,
				DateUpdate
			) select @CardIDNo,			
				Condition,
				TotalWorkingHour,
				M_TimeIn,
				M_TimeOut,
				A_TimeIn,
				A_TimeOut,
				E_TimeIn,
				E_TimeOut,
				SM_TimeIn,
				SM_TimeOut,
				SA_TimeIn,
				SA_TimeOut,
				UM_TimeIn,
				UM_TimeOut,
				UA_TimeIn,
				UA_TimeOut,
				EffectiveDate,
				UserCreate,
				DateCreate,
				UserUpdate,
				DateUpdate
			from tblsa_new_employee_cardid where ID=@CardIDNo
		end
	end
end
go

--------------

--drop procedure SA_GetEmployeeWorkingHoursList
--go

--create procedure SA_GetEmployeeWorkingHoursList
--	@CardID nvarchar(10),
--	@DeptID int
--as
--begin
--	if @DeptID>0
--	begin
--		select 
--			EID.CardID,
--			RTRIM(LTRIM(E.FirstName +' ' + E.LastName)) as Name,
--			E.Sex,
--			EH.Position,
--			CO.Division,
--			Dept.Department,
--			EID.Condition,
--			--EID.TotalWorkingHour,
--			EID.M_TimeIn as MM_In,
--			EID.M_TimeOut as MM_Out,
--			EID.A_TimeIn as MA_In,
--			EID.A_TimeOut as MA_Out,
--			EID.E_TimeIn as ME_In,
--			EID.E_TimeOut as ME_Out,
--			EID.SM_TimeIn as SM_In,
--			EID.SM_TimeOut as SM_Out,
--			EID.SA_TimeIn as SA_In,
--			EID.SA_TimeOut as SA_Out,
--			EID.UM_TimeIn as UM_In,
--			EID.UM_TimeOut as UM_Out,
--			EID.UA_TimeIn as UA_In,
--			EID.UA_TimeOut as UA_Out,
--			EID.EffectiveDate,
--			EID.UserCreate,
--			EID.DateCreate,
--			EID.UserUpdate,
--			EID.DateUpdate,
--			EID.StaffNo
--		FROM tblsa_new_employee_cardid EID
--			LEFT JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
--			LEFT JOIN tblsa_new_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
--			left join tblsa_divisions CO on EH.Division=CO.ID
--			left join tblsa_departments Dept on EH.Department=Dept.ID
--		WHERE EH.Department=@DeptID
--		order by right(CardID, 4) 
--	end
--	else
--	begin
--		select 
--			EID.CardID,
--			RTRIM(LTRIM(E.FirstName +' ' + E.LastName)) as Name,
--			E.Sex,
--			EH.Position,
--			CO.Division,
--			Dept.Department,
--			EID.Condition,
--			--EID.TotalWorkingHour,
--			EID.M_TimeIn as MM_In,
--			EID.M_TimeOut as MM_Out,
--			EID.A_TimeIn as MA_In,
--			EID.A_TimeOut as MA_Out,
--			EID.E_TimeIn as ME_In,
--			EID.E_TimeOut as ME_Out,
--			EID.SM_TimeIn as SM_In,
--			EID.SM_TimeOut as SM_Out,
--			EID.SA_TimeIn as SA_In,
--			EID.SA_TimeOut as SA_Out,
--			EID.UM_TimeIn as UM_In,
--			EID.UM_TimeOut as UM_Out,
--			EID.UA_TimeIn as UA_In,
--			EID.UA_TimeOut as UA_Out,
--			EID.EffectiveDate,
--			EID.UserCreate,
--			EID.DateCreate,
--			EID.UserUpdate,
--			EID.DateUpdate,
--			EID.StaffNo
--		FROM tblsa_new_employee_cardid EID
--			LEFT JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
--			LEFT JOIN tblsa_new_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
--			left join tblsa_divisions CO on EH.Division=CO.ID
--			left join tblsa_departments Dept on EH.Department=Dept.ID
--		where EID.Mark_Deleted=0 
--		ORDER BY RIGHT(CardID, 4) DESC
--	end
--end
--go

--------20190212
drop procedure SA_ApplyStripCardStatus
go

create procedure SA_ApplyStripCardStatus
	@CardID nvarchar(20),
	@Card bit,
	@UserUpdate nvarchar(100),
	@IsUpdate int output,
	@Msg nvarchar(max) output
as 
begin
	Set @IsUpdate=0
	Set @Msg='Unable to update the selected stripe card.'
	if len(@CardID)>0
	begin
		if @Card=0
		begin
			set @Msg='Card for Employee ID ' + @CardID + ' is unblocked.'
		end
		else
		begin
			set @Msg='Card for Employee ID ' + @CardID + ' is blocked.'
		end

		update tblsa_new_employee_cardid set
			CardExpire=@Card,
			UserUpdate=@UserUpdate,
			DateUpdate=CURRENT_TIMESTAMP
		where CardID=@CardID
		set @IsUpdate=1
	end

	select @IsUpdate, @Msg
end
go


------20190212
drop procedure SA_GetEmployeeInfoDetails --'6646'
go

create procedure SA_GetEmployeeInfoDetails
	@ID nvarchar(20)
as 
begin 
	if(len(@ID)>0)
	begin
		select top 1
			E.StaffNo,
			EID.CardID,
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Name,			
			Phone,
			--Photo,
			EID.JoinDate,
			(Case WHEN ER.StopDate<=cast(GETDATE() as date) THEN 'Resigned' ELSE 'Working' END) as EmpStatus,	
			ER.StopDate,
			CardExpire
			--CAST(datediff(minute, CAST(ISNULL(E.M_TimeIn, '') AS TIME), CAST(ISNULL(E.M_TimeOut, '') AS TIME))/60.0+datediff(minute, CAST(ISNULL(E.A_TimeIn, '') AS TIME), CAST(ISNULL(E.A_TimeOut, '') AS TIME))/60.0+datediff(minute, CAST(ISNULL(E.E_TimeIn, '') AS TIME), CAST(ISNULL(E.E_TimeOut, '') AS TIME))/60.0 AS numeric(10, 3)) as WeekDayWH,
			--CAST(datediff(minute, CAST(ISNULL(E.SM_TimeIn, '') AS TIME), CAST(ISNULL(E.SM_TimeOut, '') AS TIME))/60.0+datediff(minute, CAST(ISNULL(E.SA_TimeIn, '') AS TIME), CAST(ISNULL(E.SA_TimeOut, '') AS TIME))/60.0 AS numeric(10, 3)) as SaturdayWH,
			--CAST(datediff(minute, CAST(ISNULL(E.UM_TimeIn, '') AS TIME), CAST(ISNULL(E.UM_TimeOut, '') AS TIME))/60.0+datediff(minute, CAST(ISNULL(E.UA_TimeIn, '') AS TIME), CAST(ISNULL(E.UA_TimeOut, '') AS TIME))/60.0 AS numeric(10, 3)) as SundayWH,
			--E.UserCreate,
			--E.DateCreate,
			--E.UserUpdate,
			--E.DateUpdate
		FROM tblsa_new_employee_cardid EID
			LEFT JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
			LEFT JOIN tblsa_new_employee_resigns ER ON ER.CardIDNo=EID.ID			
		WHERE EID.CardID=@ID 
			and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null) 
			and (E.Mark_Deleted=0 or E.Mark_Deleted is null) 

	end
	else
	begin
		select
			E.StaffNo,
			EID.CardID,
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Name,			
			EH.Position,
			Phone,
			Photo,
			EID.JoinDate,
			(Case WHEN ER.StopDate<=cast(GETDATE() as date) THEN 'Resigned' ELSE 'Working' END) as EmpStatus,	
			ER.StopDate,
			CardExpire,
			E.UserCreate,
			E.DateCreate,
			E.UserUpdate,
			E.DateUpdate
		FROM tblsa_new_employee_cardid EID
			LEFT JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
			LEFT JOIN tblsa_new_employee_resigns ER ON ER.CardIDNo=EID.ID	
			LEFT JOIN tblsa_new_employee_employment EH ON EH.CardIDNo=EID.ID and EH.TranID=EID.TranID
		WHERE (EID.Mark_Deleted=0 or EID.Mark_Deleted is null) 
			and (E.Mark_Deleted=0 or E.Mark_Deleted is null) 
		order by EID.EffectiveDate desc
	end
end
go


---------20190314

drop procedure SA_GetCardIDInfo --'6646'
go

create procedure SA_GetCardIDInfo
	@ID nvarchar(20)
as 
begin 
	if(len(@ID)>0)
	begin
		select top 1
			E.StaffNo,
			EID.CardID,
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Name,			
			Phone,
			Photo,
			Dept.Department,
			EH.Position,
			ISNULL(EH.Division, 0) as Division,
			EID.JoinDate,
			(Case WHEN ER.StopDate<=cast(GETDATE() as date) THEN 'Resigned' ELSE 'Working' END) as EmpStatus,	
			ER.StopDate,
			CardExpire
		FROM tblsa_new_employee_cardid EID
			INNER JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
			LEFT JOIN tblsa_new_employee_resigns ER ON ER.CardIDNo=EID.ID			
			LEFT JOIN tblsa_new_employee_employment EH ON EH.CardIDNo=EID.ID AND EID.TranID=EH.TranID
			LEFT JOIN tblsa_departments Dept ON Dept.ID=EH.Department
		WHERE EID.CardID=@ID 
			and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null) 
			and (E.Mark_Deleted=0 or E.Mark_Deleted is null) 
	end
	else
	begin
		select
			E.StaffNo,
			EID.CardID,
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Name,			
			EH.Position,
			Phone,
			Photo,
			EID.JoinDate,
			(Case WHEN ER.StopDate<=cast(GETDATE() as date) THEN 'Resigned' ELSE 'Working' END) as EmpStatus,	
			ER.StopDate,
			CardExpire,
			E.UserCreate,
			E.DateCreate,
			E.UserUpdate,
			E.DateUpdate
		FROM tblsa_new_employee_cardid EID
			INNER JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
			LEFT JOIN tblsa_new_employee_resigns ER ON ER.CardIDNo=EID.ID	
			LEFT JOIN tblsa_new_employee_employment EH ON EH.CardIDNo=EID.ID and EH.TranID=EID.TranID
		WHERE (EID.Mark_Deleted=0 or EID.Mark_Deleted is null) 
			and (E.Mark_Deleted=0 or E.Mark_Deleted is null) 
		order by EID.EffectiveDate desc
	end
end
go


---20190212
drop procedure SA_GetContractsToList
go

create procedure SA_GetContractsToList --'6646',2
	@CardID nvarchar(20),
	@ContractID int
as 
begin 
	if(len(@CardID)>0)
	begin
		if @ContractID>0
		begin
			SELECT top 1
				CardID,
				sc.Division,
				ContractStart,
				ContractEnd,
				--(CASE WHEN TypeOfContract=0 THEN 'FDC' WHEN TypeOfContract=1 THEN 'UDC' WHEN TypeOfContract=2 THEN 'PT' ELSE 'Open' END) as TypeOfContract,
				TypeOfContract,
				--(CAST(ProbationPeriod as NVARCHAR) + (CASE WHEN ProbationPeriod=1 THEN ' Month' ELSE ' Months' END)) as ProbationPeriod,
				ProbationPeriod,
				Salary,
				ContractDate,
				AuthorizedBy,
				AuthorizedDate,
				--(CAST(NotificationAlert as NVARCHAR) + (CASE WHEN NotificationAlert=1 THEN ' Day' ELSE ' Days' END)) as NotificationAlert,
				NotificationAlert,
				Remark,
				HasContractForm,
				sc.ContractID,
				sc.UserCreate,
				sc.DateCreate,
				sc.UserUpdate,
				sc.DateUpdate
			FROM tblsa_new_employee_contracts sc
			inner join tblsa_divisions c on c.ID=sc.Division
			WHERE CardID=@CardID 
				and sc.ContractID=@ContractID 
				and (sc.Mark_Deleted=0 or sc.Mark_Deleted IS NULL)
		end
		else
		begin
			SELECT 
				CardID,
				c.Division,
				(CASE WHEN TypeOfContract=0 THEN 'FDC' WHEN TypeOfContract=1 THEN 'UDC' WHEN TypeOfContract=2 THEN 'PT' ELSE 'Open' END) as TypeOfContract,
				(CASE WHEN TypeOfContract=3 THEN 'Unspecified' ELSE CONVERT(VARCHAR, ContractStart, 101) END) as ContractStart,
				(CASE WHEN TypeOfContract=1 or TypeOfContract=3 THEN 'Unspecified' ELSE CONVERT(VARCHAR, ContractEnd, 101) END) as ContractEnd,
				(CAST(ProbationPeriod as NVARCHAR) + (CASE WHEN ProbationPeriod=1 THEN ' Month' ELSE ' Months' END)) as ProbationPeriod,
				Salary,
				CONVERT(VARCHAR, ContractDate, 101) as ContractDate,
				AuthorizedBy,
				CONVERT(VARCHAR, AuthorizedDate, 101) as AuthorizedDate,
				(CAST(NotificationAlert as NVARCHAR) + (CASE WHEN NotificationAlert=1 THEN ' Day' ELSE ' Days' END)) as NotificationAlert,
				Remark,
				HasContractForm,
				sc.ContractID,
				sc.UserCreate,
				sc.DateCreate,
				sc.UserUpdate,
				sc.DateUpdate
			FROM tblsa_new_employee_contracts sc
			inner join tblsa_divisions c on c.ID=sc.Division
			WHERE CardID=@CardID 
				and (sc.Mark_Deleted=0 or sc.Mark_Deleted IS NULL)
			ORDER BY ContractEnd DESC
		end
	end
	else
	begin
		SELECT 
			CardID,
			Division,
			(CASE WHEN TypeOfContract=0 THEN 'FDC' WHEN TypeOfContract=1 THEN 'UDC' WHEN TypeOfContract=2 THEN 'PT' ELSE 'Open' END) as TypeOfContract,
			(CASE WHEN TypeOfContract=3 THEN 'Unspecified' ELSE CONVERT(VARCHAR, ContractStart, 101) END) as ContractStart,
			(CASE WHEN TypeOfContract=1 or TypeOfContract=3 THEN 'Unspecified' ELSE CONVERT(VARCHAR, ContractEnd, 101) END) as ContractEnd,
			(CAST(ProbationPeriod as NVARCHAR) + (CASE WHEN ProbationPeriod=1 THEN ' Month' ELSE ' Months' END)) as ProbationPeriod,
			Salary,
			CONVERT(VARCHAR, ContractDate, 101) as ContractDate,
			AuthorizedBy,
			CONVERT(VARCHAR, AuthorizedDate, 101) as AuthorizedDate,
			(CAST(NotificationAlert as NVARCHAR) + (CASE WHEN NotificationAlert=1 THEN ' Day' ELSE ' Days' END)) as NotificationAlert,
			Remark,
			HasContractForm,
			ContractID,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		FROM tblsa_new_employee_contracts
		WHERE (Mark_Deleted=0 or Mark_Deleted IS NULL)
		ORDER BY ContractEnd DESC
	end
end
go

------20190212
drop procedure SA_SaveEmploymentContract
go

create procedure SA_SaveEmploymentContract
	@ContractID int,
	@CardID nvarchar(20),
	@HasContractForm bit,
	@Division int,
	@TypeOfContract int,
	@ContractStart date,
	@ContractEnd date,
	@ProbationPeriod int,
	@Salary nvarchar(10),
	@ContractDate date,
	@AuthorizedBy nvarchar(100),
	@AuthorizedDate date,
	@NotificationAlert int,	
	@Remark nvarchar(MAX),
	@Attachments nvarchar(MAX),
	@UserCreate nvarchar(100),
	@UserUpdate nvarchar(100),
	@IsAdd int output,
	@Msg nvarchar(max) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'System Error: Cannot performance this operation while the Employee ID is no longer.'
	declare @GetDate as date
	declare @RecID as integer=0

	if(len(@CardID)>0 and len(@AuthorizedBy)>0)
	begin
		if @ContractID=0
		begin
			set @RecID = ISNULL((select top 1 ContractID from tblsa_new_employee_contracts order by rand(ContractID) desc), 0)+1
		end
		else
		begin
			set @RecID=@ContractID
		end
		
		if not exists(select ID
					from tblsa_new_employee_contracts 
					where CardID=@CardID 
						and Division=@Division 
						and (CAST(@ContractStart AS DATE) BETWEEN CAST(ContractStart AS DATE) and CAST(ContractEnd AS DATE) 
						or CAST(@ContractEnd AS DATE) BETWEEN CAST(ContractStart AS DATE) and CAST(ContractEnd AS DATE)) 
						and (Mark_Deleted=0 or Mark_Deleted is null) 
						and ID<>@RecID) 
		begin
			if not exists(select ID from tblsa_new_employee_contracts where CardID=@CardID and ContractID=@RecID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				insert into tblsa_new_employee_contracts(CardID, ContractID, UserCreate, DateCreate) values(@CardID, @RecID, @UserCreate, CURRENT_TIMESTAMP)
				set @Msg = 'Contract for employee id '+ @CardID +' is created successfully and effective from ' + CONVERT(nvarchar(40), @ContractStart) + '  ' + CONVERT(nvarchar(40), @ContractEnd) +'.'
			end	
			else
			begin
				update tblsa_new_employee_contracts set DateUpdate=CURRENT_TIMESTAMP, UserUpdate=@UserUpdate where ContractID=@RecID and CardID=@CardID and Mark_Deleted=0
				set @Msg = 'Contract for employee id: '+ @CardID +' is updated successfully and effective from ' + CONVERT(nvarchar(40), @ContractStart) + '  ' + CONVERT(nvarchar(40), @ContractEnd) +'.'
			end
			
			begin
				update tblsa_new_employee_contracts set
					HasContractForm=@HasContractForm,
					Division=@Division,
					TypeOfContract=@TypeOfContract,
					ContractStart=@ContractStart,
					ContractEnd=@ContractEnd,
					ProbationPeriod=@ProbationPeriod,
					Salary=@Salary,
					ContractDate=@ContractDate,
					AuthorizedBy=@AuthorizedBy,
					AuthorizedDate=@AuthorizedDate,
					NotificationAlert=@NotificationAlert,
					Remark=@Remark,
					Attachments=@Attachments
				where ContractID=@RecID and CardID=@CardID and Mark_Deleted=0
			end

			set @IsAdd = (Select top 1 ID from tblsa_new_employee_contracts where ContractID=@RecID and CardID=@CardID and Mark_Deleted=0)
		end
		else
		begin
			set @Msg = 'System Error: Employee id '+ @CardID +' already signed the contract on ' + CONVERT(nvarchar(40), @ContractDate) + '.'
		end
	end
	else
	begin
		set @Msg = 'System Error: Cannot performance this operation while the employee id is no longer.'
	end

	select @IsAdd, @Msg
end
go


-------20190219
drop procedure SA_GetCardIDByCompany
go

create procedure SA_GetCardIDByCompany
as 
begin 
	set nocount on
	select 
		CardID
	from tblsa_new_employee_cardid EID
		left join tblsa_new_employees E on EID.StaffNo=E.StaffNo
	where (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
		and (E.Mark_Deleted=0 or E.Mark_Deleted is null) 
	ORDER BY RIGHT(CardID, 4) DESC
end
go

-----------20190131
drop procedure SA_GetActiveEmployeeID
go

create procedure SA_GetActiveEmployeeID
as 
begin 
	set nocount on
	select 
		CardID
	from tblsa_new_employee_cardid EID
		left join tblsa_new_employees E on EID.StaffNo=E.StaffNo
	where (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
		and (E.Mark_Deleted=0 or E.Mark_Deleted is null) 
		and Flag=1	 
	ORDER BY RIGHT(CardID, 4) DESC
end
go


------
--------------------------20171020
--drop procedure SA_GetStaffToList
--go

--create procedure SA_GetStaffToList
--as
--begin
--	SELECT
--		EID.StaffNo,
--		CardID,
--		LTRIM(RTRIM(FirstName +' ' + LastName)) as Name,  		
--		Sex,
--		Phone
--	from tblsa_new_employee_cardid EID
--		inner join tblsa_new_employees E on EID.StaffNo=E.StaffNo
--	where (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
--		and (E.Mark_Deleted=0 or E.Mark_Deleted is null)
--	ORDER BY RIGHT(CardID, 4) DESC
--end
--go

--------------------
drop procedure SA_GetEmployeeByIDToList 
go

create procedure SA_GetEmployeeByIDToList 
	@ID nvarchar(20)
as 
begin 
	if(len(@ID)>0)
	begin
		select top 1
			EID.StaffNo,
			CardID,
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Name,		
			Sex,
			--DOB,
			Phone			
		FROM tblsa_new_employee_cardid EID
			inner JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
		where CardID=@ID 
			and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
			and (E.Mark_Deleted=0 or E.Mark_Deleted is null)
		order by right(CardID, 4) desc
	end
	else
	begin
		select 
			EID.StaffNo,
			CardID,
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Name,				
			Sex,
			--DOB,
			Phone			
		FROM tblsa_new_employee_cardid EID
			inner JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
		where (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
			and (E.Mark_Deleted=0 or E.Mark_Deleted is null)
		order by right(CardID, 4) desc
	end
end
go
---------------

--declare @EmpID nvarchar(10)
--exec SA_IsExistEmployeeID '7676', @EmpID output
------------------------
drop procedure SA_IsExistEmployeeID
go

create procedure SA_IsExistEmployeeID
	@CardID nvarchar(20),
	@EmpID nvarchar(10) output
as 
begin
	
	set @EmpID = ''
	if exists(select ID 
				FROM tblsa_new_employee_cardid EID
					LEFT JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
				where CardID=@CardID 
					and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
					and (E.Mark_Deleted=0 or E.Mark_Deleted is null))
	begin
		set @EmpID=(select top 1
						LTRIM(RTRIM(CardID)) 
					FROM tblsa_new_employee_cardid EID
					LEFT JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
				where CardID=@CardID 
					and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
					and (E.Mark_Deleted=0 or E.Mark_Deleted is null)) 
	end

	select @EmpID
end
go

-------------------------------
drop procedure SA_IsEmployeeExistGetName
go

create procedure SA_IsEmployeeExistGetName
	@CardID nvarchar(20),
	@Name nvarchar(100) output
as 
begin
	set @Name = ''
	if exists(select ID 
				FROM tblsa_new_employee_cardid EID
					LEFT JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
				where CardID=@CardID 
					and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
					and (E.Mark_Deleted=0 or E.Mark_Deleted is null))
	begin
		set @Name=(select top 1
						LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) 
					FROM tblsa_new_employee_cardid EID
					LEFT JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
				where CardID=@CardID 
					and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
					and (E.Mark_Deleted=0 or E.Mark_Deleted is null)) 
	end

	select @Name
end
go


----------------------
drop procedure SA_GetEmpIDListByDeptID
go

create procedure SA_GetEmpIDListByDeptID
	@DeptID int
as 
begin
	if @DeptID>0
	begin
		SELECT
			EID.CardID
		FROM tblsa_new_employee_cardid EID
			LEFT JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
			LEFT JOIN tblsa_new_employee_resigns ER ON ER.CardIDNo=EID.ID	
			LEFT JOIN tblsa_new_employee_employment EH ON EH.CardIDNo=EID.ID and EH.TranID=EID.TranID
		WHERE EH.Department=@DeptID
		ORDER BY RIGHT(EID.CardID, 4) DESC
	end
	else
	begin
		SELECT
			EID.CardID
		FROM tblsa_new_employee_cardid EID
			LEFT JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
			LEFT JOIN tblsa_new_employee_resigns ER ON ER.CardIDNo=EID.ID	
			LEFT JOIN tblsa_new_employee_employment EH ON EH.CardIDNo=EID.ID and EH.TranID=EID.TranID
		ORDER BY RIGHT(EID.CardID, 4) DESC
	end
end
go

------------------
--------------20180405
drop procedure SA_IsExistEmployeeIDByDept 
go

create procedure SA_IsExistEmployeeIDByDept
	@CardID nvarchar(20),
	@DeptID int,
	@EmpID nvarchar(10) output,
	@Msg nvarchar(200) output
as 
begin
	set @EmpID = ''
	set @Msg = 'Your search IDs cannot be found in the system.'
	if @DeptID=0
	begin
		if exists(select EID.CardID 
					FROM tblsa_new_employee_cardid EID 
						LEFT JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
					where EID.CardID=@CardID 
						and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
						and (E.Mark_Deleted=0 or E.Mark_Deleted is null))
		begin
			set @EmpID=(select LTRIM(RTRIM(EID.CardID))
						FROM tblsa_new_employee_cardid EID
							LEFT JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
						where EID.CardID=@CardID 
							and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
							and (E.Mark_Deleted=0 or E.Mark_Deleted is null))
			set @Msg = 'Found record with employee id ' + @EmpID + '.'
		end
	end
	else
	begin
		if exists(select EID.CardID 
					FROM tblsa_new_employee_cardid EID	
						LEFT JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
						LEFT JOIN tblsa_new_employee_employment EH ON EH.CardIDNo=EID.ID and EH.TranID=EID.TranID
					where EID.CardID=@CardID 
						and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
						and (E.Mark_Deleted=0 or E.Mark_Deleted is null)
						and EH.Department=@DeptID)
		begin
			set @EmpID=(select LTRIM(RTRIM(EID.CardID))
					FROM tblsa_new_employee_cardid EID						
						LEFT JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
						LEFT JOIN tblsa_new_employee_employment EH ON EH.CardIDNo=EID.ID and EH.TranID=EID.TranID
					where EID.CardID=@CardID 
						and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
						and (E.Mark_Deleted=0 or E.Mark_Deleted is null)
						and EH.Department=@DeptID)
			set @Msg = 'Found record with employee id ' + @EmpID + '.'
		end
	end

	select @EmpID, @Msg
end
go

---------20180405----------------------
drop procedure SA_IsEmployeeExistGetNameByDept
go

create procedure SA_IsEmployeeExistGetNameByDept
	@CardID nvarchar(20),
	@DeptID int,
	@Name nvarchar(100) output
as 
begin
	set @Name = ''

	if @DeptID=0
	begin
		if exists(select EID.CardID 
					FROM tblsa_new_employee_cardid EID 
						LEFT JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
					where EID.CardID=@CardID 
						and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
						and (E.Mark_Deleted=0 or E.Mark_Deleted is null))
		begin
			set @Name=(select LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, '')))
						FROM tblsa_new_employee_cardid EID
							LEFT JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
						where EID.CardID=@CardID 
							and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
							and (E.Mark_Deleted=0 or E.Mark_Deleted is null))			
		end
	end
	else
	begin
		if exists(select EID.CardID 
					FROM tblsa_new_employee_cardid EID	
						LEFT JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
						LEFT JOIN tblsa_new_employee_employment EH ON EH.CardIDNo=EID.ID and EH.TranID=EID.TranID
					where EID.CardID=@CardID 
						and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
						and (E.Mark_Deleted=0 or E.Mark_Deleted is null)
						and EH.Department=@DeptID)
		begin
			set @Name=(select LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, '')))
					FROM tblsa_new_employee_cardid EID						
						LEFT JOIN tblsa_new_employees E on EID.StaffNo=E.StaffNo
						LEFT JOIN tblsa_new_employee_employment EH ON EH.CardIDNo=EID.ID and EH.TranID=EID.TranID
					where EID.CardID=@CardID 
						and (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
						and (E.Mark_Deleted=0 or E.Mark_Deleted is null)
						and EH.Department=@DeptID)
		end
	end

	select @Name
end
go

------------------------------



drop procedure SA_GetLimonName
go

create procedure SA_GetLimonName
	@CardID nvarchar(10)
as
begin
	select top 1 KName from tbl_Staff
	where StaffID=@CardID
end
go


