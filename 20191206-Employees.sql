drop procedure SA_SaveEmployeeProfile
go

create procedure SA_SaveEmployeeProfile 
	@StaffNo int,
	@CardID nvarchar(20),
	@KLastName nvarchar(100),
	@KFirstName nvarchar(100),
	@FirstName nvarchar(100),
	@LastName nvarchar(100),
	@Sex nvarchar(10),
	@DOB date,
	@MaritalStatus nvarchar(50),
	@Nationality int,
	@PlaceOfBirth nvarchar(max),
	@PositionID int,
	@Clinic int,
	@Department int,
	@Section int,
	@Campus int,
	@StartDate date,
	@NSSF nvarchar(30),
	@WorkBookNo nvarchar(30),
	@CurCity int,
	@CurKhan int,
	@CurSangkat int,
	@CurVillage int,
	@CurStreet nvarchar(100),
	@CurHome nvarchar(100),
	@CellPhone nvarchar(100),
	@HomePhone nvarchar(100),
	@Email nvarchar(200),	
	@NationalID nvarchar(50),
	@NationalID_IssueDate date,
	@NationalID_ExpireDate date,	
	@PassportNo nvarchar(50),
	@Passport_IssueDate date,
	@Passport_ExpireDate date,
	@Remark nvarchar(max),
	@EmContactName nvarchar(100),
	@EmRelation int,
	@EmCellPhone nvarchar(100),
	@EmHomePhone nvarchar(100),
	@Note nvarchar(max),
	@IsExistImage tinyint,
	@Photo varbinary(max),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(max) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the some requied info are empty.'
	
	set @KLastName=UPPER(LTRIM(RTRIM(@KLastName)))
	set @KFirstName=UPPER(LTRIM(RTRIM(@KFirstName)))
	set @FirstName=LTRIM(RTRIM(@FirstName))
	set @LastName=LTRIM(RTRIM(@LastName))
	set @PlaceOfBirth=LTRIM(RTRIM(@PlaceOfBirth))	
	set @NSSF=LTRIM(RTRIM(@NSSF))
	set @WorkBookNo=LTRIM(RTRIM(@WorkBookNo))
	set @CurStreet=LTRIM(RTRIM(@CurStreet))
	set @CurHome=LTRIM(RTRIM(@CurHome))
	set @CellPhone=LTRIM(RTRIM(@CellPhone))
	set @HomePhone=LTRIM(RTRIM(@HomePhone))
	set @Email=LTRIM(RTRIM(REPLACE(REPLACE(@Email, CHAR(13), ''), CHAR(10), '')))	
	set @NationalID=LTRIM(RTRIM(@NationalID))
	set @PassportNo=LTRIM(RTRIM(@PassportNo))
	set @Remark=LTRIM(RTRIM(@Remark))
	set @EmContactName=LTRIM(RTRIM(@EmContactName))
	set @EmCellPhone=LTRIM(RTRIM(@EmCellPhone))
	set @EmHomePhone=LTRIM(RTRIM(@EmHomePhone))
	set @Note=LTRIM(RTRIM(@Note))
	
	if(len(@CardID)>0 and len(@LastName)>0 and len(@FirstName)>0)
	begin
		if not exists(select StaffNo from tblsa_employees where FirstName=@FirstName and LastName=@LastName and DOB=@DOB and @StaffNo=0 and Sex=@Sex and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
		begin
			if @StaffNo=0
			begin
				set @StaffNo = ISNULL((select top 1 StaffNo from tblsa_employees order by rand(StaffNo) desc), 0) + 1
			end

			if not exists(select StaffNo from tblsa_employees where StaffNo=@StaffNo and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
			begin
				insert into tblsa_employees(StaffNo, UserCreate, DateCreate) values(@StaffNo, @User, CURRENT_TIMESTAMP)
			end

			update tblsa_employees set
				KLastName=@KLastName,
				KFirstName=@KFirstName,
				FirstName=@FirstName,
				LastName=@LastName,
				Sex=@Sex,
				DOB=@DOB,
				PlaceOfBirth=@PlaceOfBirth,
				MaritalStatus=@MaritalStatus,
				Nationality=@Nationality,
				NSSF=@NSSF,
				WorkBook=@WorkBookNo,
				NationalID=@NationalID,
				NationalID_IssueDate=(CASE WHEN LEN(@NationalID)=0 THEN NULL ELSE @NationalID_IssueDate END),
				NationalID_ExpireDate=(CASE WHEN LEN(@NationalID)=0 THEN NULL ELSE @NationalID_ExpireDate END),				
				PassportNo=@PassportNo,
				Passport_IssueDate=(CASE WHEN LEN(@PassportNo)=0 THEN NULL ELSE @Passport_IssueDate END),
				Passport_ExpireDate=(CASE WHEN LEN(@PassportNo)=0 THEN NULL ELSE @Passport_ExpireDate END),
				CurCity=@CurCity,
				CurKhan=@CurKhan,
				CurSangkat=@CurSangkat,
				CurVillage=@CurVillage,
				CurStreet=@CurStreet,
				CurHome=@CurHome,
				CellPhone=@CellPhone,
				HomePhone=@HomePhone,
				Email=@Email,
				EmContactName=@EmContactName,
				EmRelation=(CASE WHEN LEN(@EmContactName)=0 THEN 0 ELSE @EmRelation END),
				EmCellPhone=@EmCellPhone,
				EmHomePhone=@EmHomePhone,
				Remark=@Remark,
				Note=@Note,
				DateUpdate=CURRENT_TIMESTAMP, 
				UserUpdate=@User
			where StaffNo=@StaffNo and (Mark_Deleted=0 OR Mark_Deleted IS NULL)

			if @IsExistImage=0 
			begin
				update tblsa_employees set Photo=@Photo where StaffNo=@StaffNo and (Mark_Deleted=0 OR Mark_Deleted IS NULL)
			end
			--------------
			if not exists(select ID from tblsa_employee_cardid where StaffNo=@StaffNo and CardID=@CardID and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
			begin
				insert into tblsa_employee_cardid(StaffNo, CardID, AccessCode, StartDate, UserCreate, DateCreate) values(@StaffNo, @CardID, '65e881ac1f03ca658b1dd3aa245d28cc', @StartDate, @User, CURRENT_TIMESTAMP)
				
				set @Msg = 'Employee: '+ LTRIM(RTRIM(ISNULL(@FirstName, '') +' ' + ISNULL(@LastName, ''))) + ' with Card ID: '+ @CardID+' has been registered successfully.'
				set @IsAdd=1
			end
			else
			begin
				update tblsa_employee_cardid set
					@StartDate=@StartDate,
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where StaffNo=@StaffNo and CardID=@CardID and Mark_Deleted=0
				set @Msg = 'Employee: '+ LTRIM(RTRIM(ISNULL(@FirstName, '') +' ' + ISNULL(@LastName, ''))) + ' with Card ID: '+ @CardID+' has been updated successfully.'
				set @IsAdd=2
			end

			if not exists(select CardIDNo 
							from tblsa_employee_employment EH
								inner join tblsa_employee_cardid EID on EID.ID=EH.CardIDNo
							where EID.StaffNo=@StaffNo and EID.Mark_Deleted=0 and EH.Mark_Deleted=0)
			begin
				declare @NewTranID int = ISNULL((select top 1 TranID from tblsa_employee_employment order by rand(TranID) desc), 0)+1
				
				insert into tblsa_employee_employment(TranID, CardIDNo, PositionID, ClinicID, DepartmentID, SectionID, CampusID, Reason, ApprovedBy, ApprovedDate, EffectiveDate, UserCreate, DateCreate) 
				select top 1 @NewTranID, ID, ISNULL(@PositionID, 0), ISNULL(@Clinic, 0), ISNULL(@Department, 0), ISNULL(@Section, 0), ISNULL(@Campus, 0), 'New Staff', 'HRD', CURRENT_TIMESTAMP, @StartDate, @User, CURRENT_TIMESTAMP
				from tblsa_employee_cardid where StaffNo=@StaffNo and CardID=@CardID and Mark_Deleted=0
				
				update tblsa_employee_cardid set TranID=@NewTranID where StaffNo=@StaffNo and CardID=@CardID and Mark_Deleted=0	
			end
				
			if not exists(select CardIDNo 
							from tblsa_employee_resigns ER
								inner join tblsa_employee_cardid EID on EID.ID=ER.CardIDNo
							where EID.StaffNo=@StaffNo and EID.Mark_Deleted=0 and ER.Mark_Deleted=0)
			begin
				insert into tblsa_employee_resigns(CardIDNo, UserCreate, DateCreate) 
				select top 1 ID, @User, CURRENT_TIMESTAMP
				from tblsa_employee_cardid where StaffNo=@StaffNo and CardID=@CardID and (Mark_Deleted=0 OR Mark_Deleted IS NULL)
			end
		end
		else
		begin
			set @Msg = 'Employee: '+ LTRIM(RTRIM(ISNULL(@FirstName, '') +' ' + ISNULL(@LastName, ''))) + ' already exists on the system.'
		end
	end

	select @IsAdd, @Msg
end
go

----------------20190108
--drop procedure SA_GetEmployeeProfile
--go

--create procedure SA_GetEmployeeProfile
--	@ID nvarchar(20)
--as 
--begin 
--	if(len(@ID)>0)
--	begin
--		select top 1
--			EID.StaffNo
--			,EID.CardID
--			,EID.CardExpire
--			,FirstName
--			,LastName
--			,KLastName
--			,KFirstName
--			,LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as EnglishName	
--			,LTRIM(RTRIM(ISNULL(KLastName, '') +' ' + ISNULL(KFirstName, ''))) as KhmerName	
--			,Sex
--			,DOB
--			,PlaceOfBirth
--			,MaritalStatus
--			,Nationality
--			,Photo
--			,NSSF
--			,WorkBook
--			,NationalID
--			,NationalID_IssueDate
--			,NationalID_ExpireDate
--			,PassportNo
--			,Passport_IssueDate
--			,Passport_ExpireDate
--			,CellPhone
--			,HomePhone
--			,Email
--			,CurCity
--			,CurKhan
--			,CurSangkat
--			,CurVillage
--			,CurStreet
--			,CurHome
--			,EmContactName
--			,EmRelation
--			,EmCellPhone
--			,EmHomePhone
--			,E.Remark
--			,P.PositionEn
--			,EH.PositionID
--			,EH.ClinicID
--			,EH.DepartmentID
--			,EH.SectionID
--			,EH.CampusID
--			,Note
--			,(Case WHEN ResignCode not in (9, 0) AND ResignCode IS NOT NULL THEN 'Resigned' ELSE 'Working' END) as EmpStatus	
--			,ISNULL(ResignCode, 0) as ResignCode
--			,EID.StartDate
--			,ER.DateResign
--			,EID.Mark_Deleted
--		FROM tblsa_employee_cardid EID
--			INNER JOIN tblsa_employees E on EID.StaffNo=E.StaffNo			
--			LEFT JOIN tblsa_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
--			INNER JOIN tblsa_ms_positions P on P.PositionID=EH.PositionID
--			INNER JOIN tblsa_employee_resigns ER ON ER.CardIDNo=EID.ID
--		WHERE EID.CardID=@ID
--			AND (EH.Mark_Deleted=0 OR EH.Mark_Deleted IS NULL)
--			and (ER.Mark_Deleted=0 OR ER.Mark_Deleted IS NULL)
--			and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
--	end
--	else
--	begin
--		select
--			EID.StaffNo
--			,EID.CardID
--			,EID.CardExpire
--			,FirstName
--			,LastName
--			,KLastName
--			,KFirstName
--			,LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as EnglishName	
--			,LTRIM(RTRIM(ISNULL(KLastName, '') +' ' + ISNULL(KFirstName, ''))) as KhmerName	
--			,Sex
--			,DOB
--			,PlaceOfBirth
--			,MaritalStatus
--			,Nationality
--			,Photo
--			,NSSF
--			,WorkBook
--			,NationalID
--			,NationalID_IssueDate
--			,NationalID_ExpireDate
--			,PassportNo
--			,Passport_IssueDate
--			,Passport_ExpireDate
--			,CellPhone
--			,HomePhone
--			,Email
--			,CurCity
--			,CurKhan
--			,CurSangkat
--			,CurVillage
--			,CurStreet
--			,CurHome
--			,EmContactName
--			,EmRelation
--			,EmCellPhone
--			,EmHomePhone
--			,E.Remark
--			,P.PositionEn
--			,EH.PositionID
--			,EH.ClinicID
--			,EH.DepartmentID
--			,EH.SectionID
--			,EH.CampusID
--			,Note
--			,(Case WHEN ResignCode not in (9, 0) AND ResignCode IS NOT NULL THEN 'Resigned' ELSE 'Working' END) as EmpStatus	
--			,ISNULL(ResignCode, 0) as ResignCode
--			,EID.StartDate
--			,ER.DateResign
--			,EID.Mark_Deleted as Inactive
--			,EID.UserCreate
--			,EID.DateCreate
--			,EID.UserUpdate
--			,EID.DateUpdate
--		FROM tblsa_employee_cardid EID
--			INNER JOIN tblsa_employees E on EID.StaffNo=E.StaffNo			
--			LEFT JOIN tblsa_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
--			INNER JOIN tblsa_ms_positions P on P.PositionID=EH.PositionID
--			INNER JOIN tblsa_employee_resigns ER ON ER.CardIDNo=EID.ID
--		WHERE (EH.Mark_Deleted=0 OR EH.Mark_Deleted IS NULL)
--			and (ER.Mark_Deleted=0 OR ER.Mark_Deleted IS NULL)
--			and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
--		ORDER BY RIGHT(EID.CardID, 4) DESC
--	end
--end
--go

---------------------------
--drop procedure SA_GetRelationList
--go

--create procedure SA_GetRelationList
--as 
--begin 
--	set nocount on
--	select 
--		ID,
--		RTRIM(Relation) as Relation
--	from tblsa_ms_relation order by Relation
--end
--go


-------------------------
--drop procedure SA_GetNationalityList
--go

--create procedure SA_GetNationalityList
--as 
--begin 
--	set nocount on
--	select 
--		ID,
--		RTRIM(Nationality) as Nationality
--	from tblsa_ms_countries order by Nationality
--end
--go


------------------------------------------
--drop procedure SA_GetCountryList
--go

--create procedure SA_GetCountryList
--as 
--begin 
--	set nocount on
--	select 
--		ID,
--		RTRIM(Country) as Country
--	from tblsa_ms_countries 
--	order by Country
--end
--go

------------------------------------------
--drop procedure SA_GetCityList
--go

--create procedure SA_GetCityList
--as 
--begin 
--	set nocount on
--	select 
--		PID,
--		RTRIM(City) as 'City/Province'
--	from tblsa_ms_provinces order by City
--end
--go

drop procedure SA_DisableEmployeeByID
go

create procedure SA_DisableEmployeeByID
	@StaffNo int,
	@CardID nvarchar(20),
	@Inactive bit,
	@User int,
	@IsAdd int output,
	@Msg nvarchar(200) output
as
begin
set nocount on
	set @IsAdd = 0
	set @Msg = 'System Error: Cannot performance this operation while the code is empty.'

	if exists(select ID from tblsa_employee_cardid where StaffNo=@StaffNo and CardID=@CardID)
	begin	
		update tblsa_employee_cardid set 
			Mark_Deleted=@Inactive, 
			UserUpdate=@User,
			DateUpdate=CURRENT_TIMESTAMP				
		where StaffNo=@StaffNo and CardID=@CardID 
					
		set @IsAdd=1
		if @Inactive=0
		begin
			set @Msg = (select top 1 'Employee: ' +LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) +' with Card ID: '+ @CardID + ' has been restored.' from tblsa_employees where StaffNo=@StaffNo)
		end
		else
		begin
			set @Msg = (select top 1 'Employee: ' +LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) +' with Card ID: '+ @CardID + ' has been removed.' from tblsa_employees where StaffNo=@StaffNo)
		end
	end

	select @IsAdd, @Msg	
end
go

------------20191003
drop procedure SA_GetPositionsByID 
go

create procedure SA_GetPositionsByID
	@ID int,
	@DeptID int
as
begin
	if @DeptID=0
	begin
		if @ID=0
		begin
			select
				PositionEn,
				PositionKh,
				P.DepartmentID,
				D.DepartmentEn,
				P.Remark,
				COUNT(EID.ID) as Staff,
				P.PositionID,
				P.Mark_Deleted as Inactive,
				P.UserCreate,
				P.DateCreate,
				P.UserUpdate,
				P.DateUpdate
			from tblsa_ms_positions P
				INNER JOIN tblsa_ms_departments D on P.DepartmentID=D.DepartmentID
				LEFT JOIN tblsa_employee_employment EH ON D.DepartmentID = EH.DepartmentID and P.PositionID=EH.PositionID
				LEFT JOIN tblsa_employee_cardid EID on EID.ID=EH.CardIDNo
			where (D.Mark_Deleted=0 or D.Mark_Deleted is null)
			group by PositionEn,
				PositionKh,
				P.DepartmentID,
				D.DepartmentEn,
				P.Remark,				
				P.PositionID,
				P.Mark_Deleted,
				P.UserCreate,
				P.DateCreate,
				P.UserUpdate,
				P.DateUpdate
			order by DepartmentEn, PositionEN
		end
		else
		begin
			select top 1			
				PositionEn,
				PositionKh,
				DepartmentID,
				Remark,
				PositionID,
				Mark_Deleted,
				UserCreate,
				DateCreate,
				UserUpdate,
				DateUpdate
			from tblsa_ms_positions		
			where PositionID=@ID
		end
	end
	else
	begin
		if @ID=0
		begin
			select
				PositionEn,
				PositionKh,
				P.DepartmentID,
				D.DepartmentEn,
				P.Remark,
				COUNT(EID.ID) as Staff,
				P.PositionID,
				P.Mark_Deleted as Inactive,
				P.UserCreate,
				P.DateCreate,
				P.UserUpdate,
				P.DateUpdate
			from tblsa_ms_positions P
				INNER JOIN tblsa_ms_departments D on P.DepartmentID=D.DepartmentID
				LEFT JOIN tblsa_employee_employment EH ON D.DepartmentID = EH.DepartmentID and P.PositionID=EH.PositionID
				LEFT JOIN tblsa_employee_cardid EID on EID.ID=EH.CardIDNo
			where D.DepartmentID=@DeptID
				and (D.Mark_Deleted=0 or D.Mark_Deleted is null)	
			group by PositionEn,
				PositionKh,
				P.DepartmentID,
				D.DepartmentEn,
				P.Remark,				
				P.PositionID,
				P.Mark_Deleted,
				P.UserCreate,
				P.DateCreate,
				P.UserUpdate,
				P.DateUpdate
			order by DepartmentEn, PositionEN
		end
		else
		begin
			select top 1			
				PositionEn,
				PositionKh,
				DepartmentID,
				Remark,
				PositionID,
				Mark_Deleted,
				UserCreate,
				DateCreate,
				UserUpdate,
				DateUpdate
			from tblsa_ms_positions		
			where PositionID=@ID
		end
	end
end
go

----------------
drop procedure SA_SavePosition
go

create procedure SA_SavePosition	
	@ID int,
	@DepartmentID int,
	@Position nvarchar(max),
	@PositionKh nvarchar(max),
	@Remark nvarchar(max),
	@User nvarchar(100),	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@Position)>0 and @DepartmentID>0)
	begin
		if @ID=0
		begin
			if not exists(select PositionID from tblsa_ms_positions where DepartmentID=@DepartmentID and PositionEn=@Position and (Mark_Deleted=0 or Mark_Deleted is null))
			begin		
				insert into tblsa_ms_positions(DepartmentID, PositionEn, PositionKh, Remark, Mark_Deleted, UserCreate, DateCreate) 
				values(@DepartmentID, LTRIM(RTRIM(@Position)), LTRIM(RTRIM(@PositionKh)), LTRIM(RTRIM(@Remark)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Position: ' +@Position +' has been added successfully.'
			end
			else
			begin
				set @Msg = 'Position: ' +@Position  +' already exists in the system.'
			end
		end
		else if exists(select PositionID from tblsa_ms_positions where PositionID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		begin
			update tblsa_ms_positions set
				DepartmentID=@DepartmentID,
				PositionEn=LTRIM(RTRIM(@Position)),
				PositionKh=LTRIM(RTRIM(@PositionKh)),
				Remark=LTRIM(RTRIM(@Remark)),
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP
			where PositionID=@ID 
				and (Mark_Deleted=0 or Mark_Deleted is null)
			
			set @IsAdd=2
			set @Msg = 'Position: ' +@Position + ' has been updated successfully.'
		end
	end

	select @IsAdd, @Msg
end
go

----------20191024
drop procedure SA_DisabledPositions
go

create procedure SA_DisabledPositions
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
		if exists(select PositionID from tblsa_ms_positions where PositionID=@TempID )
		begin	
			update tblsa_ms_positions set 
				Mark_Deleted=@Inactive, 
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP				
			where PositionID=@TempID 
					
			set @IsAdd=1
			declare @Position nvarchar(max)=(select top 1 PositionID from tblsa_ms_positions H inner join @TblTempID T on H.PositionID=T.ID WHERE H.PositionID=@TempID)
			set @TempStr=@TempStr +  @Position +', '
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
		set @Msg = 'Positions: ' + @TempStr + ' have been restored successfully.'
	end 
	else 
	begin
		set @Msg = 'Positions: ' + @TempStr + ' have been removed successfully.'
	end

	select @IsAdd, @Msg	
end
go

-------20191025
drop procedure SA_GetCardIDByCompany
go

create procedure SA_GetCardIDByCompany
as 
begin 
	select 
		CardID
	from tblsa_employee_cardid EID
		inner join tblsa_employees E on EID.StaffNo=E.StaffNo
	where (EID.Mark_Deleted=0 or EID.Mark_Deleted is null)
	ORDER BY RIGHT(CardID, 4) DESC
end
go


-------------
drop procedure SA_GetEmployeeProfile
go

create procedure SA_GetEmployeeProfile 
	@CardID nvarchar(10),
	@IsDoctor bit,
	@Flag bit
as
begin
	if @IsDoctor=0
	begin
		if len(@CardID)=0
		begin
			if @Flag=1
			begin
				select
					EID.ID
					,EID.StaffNo
					,EID.CardID
					,EID.CardExpire
					,FirstName
					,LastName
					,KLastName
					,KFirstName
					,LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as EnglishName	
					,LTRIM(RTRIM(ISNULL(KLastName, '') +' ' + ISNULL(KFirstName, ''))) as KhmerName	
					,Sex
					,MaritalStatus
					,DOB
					,FLOOR(DATEDIFF(DAY, [DOB], GETDATE()) / 365.25) AS Age
					,PlaceOfBirth
					,Nationality
					,P.PositionEn
					,S.SectionEn
					,Dept.DepartmentEn								
					,C.ClinicEn
					,CA.CampusEn
					,EID.StartDate
					,NSSF
					,WorkBook
					,NationalID
					,NationalID_IssueDate
					,NationalID_ExpireDate
					,PassportNo
					,Passport_IssueDate
					,Passport_ExpireDate
					,CellPhone
					,HomePhone
					,Email
					,CurHome
					,CurStreet
					,CurVillage
					,CurSangkat
					,CurKhan
					,CurCity
					,EmContactName
					,EmRelation
					,EmCellPhone
					,EmHomePhone
					,E.Remark
					,Note
					,(Case WHEN ResignCode not in (9, 0) AND ResignCode IS NOT NULL THEN 'Resigned' ELSE 'Working' END) as EmpStatus	
					,ER.DateResign
					,EID.Mark_Deleted as Inactive
				FROM tblsa_employee_cardid EID
					INNER JOIN tblsa_employees E on EID.StaffNo=E.StaffNo			
					LEFT JOIN tblsa_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
					LEFT JOIN tblsa_ms_positions P on P.PositionID=EH.PositionID
					LEFT JOIN tblsa_ms_departments Dept on Dept.DepartmentID=EH.DepartmentID
					LEFT JOIN tblsa_ms_clinic C on C.ClinicID=EH.ClinicID
					LEFT JOIN tblsa_ms_sections S on S.SectionID=EH.SectionID
					LEFT JOIN tblsa_ms_campuses CA on CA.CampusID=EH.CampusID
					INNER JOIN tblsa_employee_resigns ER ON ER.CardIDNo=EID.ID
				WHERE IsDoctor=0
					and (ResignCode in (9, 0) OR ResignCode IS NULL)
					and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)				
					and (EH.Mark_Deleted=0 OR EH.Mark_Deleted IS NULL)
					and (ER.Mark_Deleted=0 OR ER.Mark_Deleted IS NULL)
					and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
					and (Dept.Mark_Deleted=0 OR Dept.Mark_Deleted IS NULL)
					and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
					and (S.Mark_Deleted=0 OR S.Mark_Deleted IS NULL)
					and (CA.Mark_Deleted=0 OR CA.Mark_Deleted IS NULL)
				ORDER BY RIGHT(EID.CardID, 4) DESC
			end
			else
			begin
				select
					EID.ID
					,EID.StaffNo
					,EID.CardID
					,EID.CardExpire
					,FirstName
					,LastName
					,KLastName
					,KFirstName
					,LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as EnglishName	
					,LTRIM(RTRIM(ISNULL(KLastName, '') +' ' + ISNULL(KFirstName, ''))) as KhmerName	
					,Sex
					,MaritalStatus
					,DOB
					,FLOOR(DATEDIFF(DAY, [DOB], GETDATE()) / 365.25) AS Age
					,PlaceOfBirth
					,Nationality
					,P.PositionEn
					,S.SectionEn
					,Dept.DepartmentEn								
					,C.ClinicEn
					,CA.CampusEn
					,EID.StartDate
					,NSSF
					,WorkBook
					,NationalID
					,NationalID_IssueDate
					,NationalID_ExpireDate
					,PassportNo
					,Passport_IssueDate
					,Passport_ExpireDate
					,CellPhone
					,HomePhone
					,Email
					,CurHome
					,CurStreet
					,CurVillage
					,CurSangkat
					,CurKhan
					,CurCity
					,EmContactName
					,EmRelation
					,EmCellPhone
					,EmHomePhone
					,E.Remark
					,Note
					,(Case WHEN ResignCode not in (9, 0) AND ResignCode IS NOT NULL THEN 'Resigned' ELSE 'Working' END) as EmpStatus	
					,ER.DateResign
					,EID.Mark_Deleted as Inactive
				FROM tblsa_employee_cardid EID
					INNER JOIN tblsa_employees E on EID.StaffNo=E.StaffNo			
					LEFT JOIN tblsa_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
					LEFT JOIN tblsa_ms_positions P on P.PositionID=EH.PositionID
					LEFT JOIN tblsa_ms_departments Dept on Dept.DepartmentID=EH.DepartmentID
					LEFT JOIN tblsa_ms_clinic C on C.ClinicID=EH.ClinicID
					LEFT JOIN tblsa_ms_sections S on S.SectionID=EH.SectionID
					LEFT JOIN tblsa_ms_campuses CA on CA.CampusID=EH.CampusID
					INNER JOIN tblsa_employee_resigns ER ON ER.CardIDNo=EID.ID
				WHERE (ResignCode in (9, 0) OR ResignCode IS NULL)
					and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)				
					and (EH.Mark_Deleted=0 OR EH.Mark_Deleted IS NULL)
					and (ER.Mark_Deleted=0 OR ER.Mark_Deleted IS NULL)
					and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
					and (Dept.Mark_Deleted=0 OR Dept.Mark_Deleted IS NULL)
					and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
					and (S.Mark_Deleted=0 OR S.Mark_Deleted IS NULL)
					and (CA.Mark_Deleted=0 OR CA.Mark_Deleted IS NULL)
				ORDER BY RIGHT(EID.CardID, 4) DESC
			end
		end
		else
		begin
			select top 1
				EID.StaffNo
				,EID.CardID
				,EID.CardExpire
				,FirstName
				,LastName
				,KLastName
				,KFirstName
				,LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as EnglishName	
				,LTRIM(RTRIM(ISNULL(KLastName, '') +' ' + ISNULL(KFirstName, ''))) as KhmerName	
				,Sex
				,DOB
				,FLOOR(DATEDIFF(DAY, [DOB], GETDATE()) / 365.25) AS Age
				,PlaceOfBirth
				,MaritalStatus
				,Nationality
				,Photo
				,NSSF
				,WorkBook
				,NationalID
				,NationalID_IssueDate
				,NationalID_ExpireDate
				,PassportNo
				,Passport_IssueDate
				,Passport_ExpireDate
				,CellPhone
				,HomePhone
				,Email
				,CurCity
				,CurKhan
				,CurSangkat
				,CurVillage
				,CurStreet
				,CurHome
				,EmContactName
				,EmRelation
				,EmCellPhone
				,EmHomePhone
				,E.Remark
				,P.PositionEn
				,EH.PositionID
				,EH.ClinicID
				,EH.DepartmentID
				,EH.SectionID
				,EH.CampusID
				,Note
				,(Case WHEN ResignCode not in (9, 0) AND ResignCode IS NOT NULL THEN 'Resigned' ELSE 'Working' END) as EmpStatus	
				,ISNULL(ResignCode, 0) as ResignCode
				,EID.StartDate
				,ER.DateResign
				,EID.Mark_Deleted as Inactive
				,EID.UserCreate
				,EID.DateCreate
				,EID.UserUpdate
				,EID.DateUpdate
			FROM tblsa_employee_cardid EID
				INNER JOIN tblsa_employees E on EID.StaffNo=E.StaffNo			
				LEFT JOIN tblsa_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
				LEFT JOIN tblsa_ms_positions P on P.PositionID=EH.PositionID
				INNER JOIN tblsa_employee_resigns ER ON ER.CardIDNo=EID.ID
			WHERE (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
				and (EH.Mark_Deleted=0 OR EH.Mark_Deleted IS NULL)
				and (ER.Mark_Deleted=0 OR ER.Mark_Deleted IS NULL)
				and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
				and EID.CardID=@CardID
			ORDER BY RIGHT(EID.CardID, 4) DESC
		end
	end
	else
	begin
		if len(@CardID)=0
		begin
			select
				EID.ID
				,EID.StaffNo
				,EID.CardID
				,EID.CardExpire
				,FirstName
				,LastName
				,KLastName
				,KFirstName
				,LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as EnglishName	
				,LTRIM(RTRIM(ISNULL(KLastName, '') +' ' + ISNULL(KFirstName, ''))) as KhmerName	
				,Sex
				,MaritalStatus
				,DOB
				,FLOOR(DATEDIFF(DAY, [DOB], GETDATE()) / 365.25) AS Age
				,PlaceOfBirth
				,Nationality
				,P.PositionEn
				,S.SectionEn
				,Dept.DepartmentEn								
				,C.ClinicEn
				,CA.CampusEn
				,EID.StartDate
				,NSSF
				,WorkBook
				,NationalID
				,NationalID_IssueDate
				,NationalID_ExpireDate
				,PassportNo
				,Passport_IssueDate
				,Passport_ExpireDate
				,CellPhone
				,HomePhone
				,Email
				,CurHome
				,CurStreet
				,CurVillage
				,CurSangkat
				,CurKhan
				,CurCity
				,EmContactName
				,EmRelation
				,EmCellPhone
				,EmHomePhone
				,E.Remark
				,Note
				,(Case WHEN ResignCode not in (9, 0) AND ResignCode IS NOT NULL THEN 'Resigned' ELSE 'Working' END) as EmpStatus	
				,ER.DateResign
				,EID.Mark_Deleted as Inactive
			FROM tblsa_employee_cardid EID
				INNER JOIN tblsa_employees E on EID.StaffNo=E.StaffNo			
				LEFT JOIN tblsa_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
				LEFT JOIN tblsa_ms_positions P on P.PositionID=EH.PositionID
				LEFT JOIN tblsa_ms_departments Dept on Dept.DepartmentID=EH.DepartmentID
				LEFT JOIN tblsa_ms_clinic C on C.ClinicID=EH.ClinicID
				LEFT JOIN tblsa_ms_sections S on S.SectionID=EH.SectionID
				LEFT JOIN tblsa_ms_campuses CA on CA.CampusID=EH.CampusID
				INNER JOIN tblsa_employee_resigns ER ON ER.CardIDNo=EID.ID
			WHERE IsDoctor=@IsDoctor
				and (ResignCode in (9, 0) OR ResignCode IS NULL)
				and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
				and (EH.Mark_Deleted=0 OR EH.Mark_Deleted IS NULL)
				and (ER.Mark_Deleted=0 OR ER.Mark_Deleted IS NULL)
				and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
				and (Dept.Mark_Deleted=0 OR Dept.Mark_Deleted IS NULL)
				and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
				and (S.Mark_Deleted=0 OR S.Mark_Deleted IS NULL)
				and (CA.Mark_Deleted=0 OR CA.Mark_Deleted IS NULL)
			ORDER BY RIGHT(EID.CardID, 4) DESC
		end
		else
		begin
			select top 1
				EID.StaffNo
				,EID.CardID
				,EID.CardExpire
				,FirstName
				,LastName
				,KLastName
				,KFirstName
				,LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as EnglishName	
				,LTRIM(RTRIM(ISNULL(KLastName, '') +' ' + ISNULL(KFirstName, ''))) as KhmerName	
				,Sex
				,DOB
				,FLOOR(DATEDIFF(DAY, [DOB], GETDATE()) / 365.25) AS Age
				,PlaceOfBirth
				,MaritalStatus
				,Nationality
				,Photo
				,NSSF
				,WorkBook
				,NationalID
				,NationalID_IssueDate
				,NationalID_ExpireDate
				,PassportNo
				,Passport_IssueDate
				,Passport_ExpireDate
				,CellPhone
				,HomePhone
				,Email
				,CurCity
				,CurKhan
				,CurSangkat
				,CurVillage
				,CurStreet
				,CurHome
				,EmContactName
				,EmRelation
				,EmCellPhone
				,EmHomePhone
				,E.Remark
				,P.PositionEn
				,EH.PositionID
				,EH.ClinicID
				,EH.DepartmentID
				,EH.SectionID
				,EH.CampusID
				,Note
				,(Case WHEN ResignCode not in (9, 0) AND ResignCode IS NOT NULL THEN 'Resigned' ELSE 'Working' END) as EmpStatus	
				,ISNULL(ResignCode, 0) as ResignCode
				,EID.StartDate
				,ER.DateResign
				,EID.Mark_Deleted as Inactive
				,EID.UserCreate
				,EID.DateCreate
				,EID.UserUpdate
				,EID.DateUpdate
			FROM tblsa_employee_cardid EID
				INNER JOIN tblsa_employees E on EID.StaffNo=E.StaffNo			
				LEFT JOIN tblsa_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
				LEFT JOIN tblsa_ms_positions P on P.PositionID=EH.PositionID
				INNER JOIN tblsa_employee_resigns ER ON ER.CardIDNo=EID.ID
			WHERE (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
				and (EH.Mark_Deleted=0 OR EH.Mark_Deleted IS NULL)
				and (ER.Mark_Deleted=0 OR ER.Mark_Deleted IS NULL)
				and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
				and EID.CardID=@CardID
				and IsDoctor=@IsDoctor
			ORDER BY RIGHT(EID.CardID, 4) DESC
		end
	end
end
go

---------20200111
drop procedure SA_AssignAsDoctor
go

create procedure SA_AssignAsDoctor
	@StrID nvarchar(max),
	@IsDoctor bit,
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

		if exists(select ID from tblsa_employee_cardid where ID=@TempID)
		begin	
			update tblsa_employee_cardid set 
				IsDoctor=@IsDoctor, 
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP				
			where ID=@TempID 
					
			set @IsAdd=1
			declare @UpdateData nvarchar(max)=(select top 1 CardID from tblsa_employee_cardid H WHERE H.ID=@TempID)
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
	
	if @IsDoctor=1
	begin
		set @Msg = 'Employee: ' + @TempStr + ' have been assigned as Doctor.'
	end
	else
	begin
		set @Msg = 'Employee: ' + @TempStr + ' have been removed from Doctor list.'
	end

	select @IsAdd, @Msg	
end
go
