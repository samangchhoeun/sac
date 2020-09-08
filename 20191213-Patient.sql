drop procedure SA_GetPatientOccupation
go

create procedure SA_GetPatientOccupation
	@ID int
as 
begin 
	if @ID=0
	begin
		select 
			OccupationID,
			Occupation
		from tblsa_patients_occupation	 
		where (Mark_Deleted=0 or Mark_Deleted is null)
		order by (CASE WHEN Occupation='Miscellaneous' THEN 1 ELSE 0 END), Occupation		
	end
	else
	begin
		select top 1
			OccupationID,
			Occupation
		from tblsa_patients_occupation	 
		where OccupationID=@ID
		order by Occupation
	end
end
go

---------------------
drop procedure SA_GetPatientReminder
go

create procedure SA_GetPatientReminder
	@ID int
as
begin
	if @ID=0
	begin
		select 
			ID,
			Reminder
		from tblsa_patients_appointment_remindertypes		
		where (Mark_Deleted=0 or Mark_Deleted is null)
		order by (CASE WHEN Reminder='None' THEN 1 ELSE 0 END), Reminder		
	end
	else
	begin
		select top 1
			ID,
			Reminder
		from tblsa_patients_appointment_remindertypes			 
		where ID=@ID
		order by Reminder
	end
end
go

------------
drop procedure SA_GetMediaChannel
go

create procedure SA_GetMediaChannel
	@ID int
as
begin
	if @ID=0
	begin
		select 
			ID,
			MediaChannel
		from tblsa_ms_media_channel		
		where (Mark_Deleted=0 or Mark_Deleted is null)
		order by (CASE WHEN MediaChannel='Others' THEN 1 ELSE 0 END), MediaChannel		
	end
	else
	begin
		select top 1
			ID,
			MediaChannel
		from tblsa_ms_media_channel			 
		where ID=@ID
		order by MediaChannel
	end
end
go

------------
drop procedure SA_GetPatientTypes
go

create procedure SA_GetPatientTypes
	@ID int
as
begin
	if @ID=0
	begin
		select 
			ID,
			PatientType
		from tblsa_patients_type		
		where (Mark_Deleted=0 or Mark_Deleted is null)
		order by (CASE WHEN PatientType='Miscellaneous' THEN 1 ELSE 0 END), PatientType		
	end
	else
	begin
		select top 1
			ID,
			PatientType
		from tblsa_patients_type			 
		where ID=@ID
		order by PatientType
	end
end
go

------20191206
--drop procedure SA_GetClinicToListForAdmin
--go

--create procedure SA_GetClinicToListForAdmin
--	@Flag bit
--as 
--begin 
--	if @Flag=0
--	begin
--		select
--			ClinicID,
--			ClinicEn,
--			ClinicKh,
--			ABB,
--			UserCreate,
--			DateCreate,
--			UserUpdate,
--			DateUpdate
--		from tblsa_ms_clinic
--		where (Mark_Deleted=0 or Mark_Deleted is null)			
--		order by ClinicEn
--	end
--	else
--	begin
--		select
--			ClinicID,
--			ClinicEn,
--			ClinicKh,
--			ABB,
--			Mark_Deleted as Inactive,
--			UserCreate,
--			DateCreate,
--			UserUpdate,
--			DateUpdate
--		from tblsa_ms_clinic Div
--		order by ClinicEn
--	end
--end
--go

----------SAC------
--drop procedure SA_GetAllClinicsList
--go

--create procedure SA_GetAllClinicsList
--	@Flag bit
--as 
--begin 
--	if @Flag=0
--	begin
--		select
--			0 as ClinicID, 
--			'*** All clinics' as ClinicEn
--		UNION
--		select 
--			ClinicID,
--			ClinicEn
--		from tblsa_ms_clinic 
--		where Mark_Deleted=0 or Mark_Deleted is null order by ClinicEn
--	end
--	else
--	begin
--		select 
--			ClinicID,
--			ABB as Clinic,
--			ClinicEn
--		from tblsa_ms_clinic 
--		where Mark_Deleted=0 or Mark_Deleted is null 
--		order by ClinicEn	
--	end
--end
--go


---------20191121
drop procedure SA_DisabledClinics
go

create procedure SA_DisabledClinics
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
		declare @NumStaffs int=(select count(EH.ID)
									from tblsa_ms_clinic CL
										LEFT JOIN tblsa_employee_employment EH ON CL.ClinicID = EH.ClinicID
										left join tblsa_employee_cardid EID on EID.ID=EH.CardIDNo				
									where CL.ClinicID=@TempID
										and (CL.Mark_Deleted=0 or CL.Mark_Deleted is null)				
										and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL))
		if exists(select ClinicID from tblsa_ms_clinic where ClinicID=@TempID)
		begin	
			if @Inactive=1 and @NumStaffs>0
			begin				
				declare @NonUpdateData nvarchar(max)=(select top 1 ClinicEn from tblsa_ms_clinic H inner join @TblTempID T on H.ClinicID=T.ID WHERE H.ClinicID=@TempID)
				set @TempStrNotUpdate=@TempStrNotUpdate +  @NonUpdateData +', '
			end
			else
			begin
				update tblsa_ms_clinic set 
					Mark_Deleted=@Inactive, 
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP				
				where ClinicID=@TempID 
					
				set @IsAdd=1
				declare @UpdateData nvarchar(max)=(select top 1 ClinicEn from tblsa_ms_clinic H inner join @TblTempID T on H.ClinicID=T.ID WHERE H.ClinicID=@TempID)
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
		set @Msg = 'Clinics: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		declare @TempSMS nvarchar(max)=''
		if LEN(@TempStr)=0
		begin
			if LEN(@TempStrNotUpdate)>0
			begin
				set @Msg='Clinics: ' +@TempStrNotUpdate +' cannot remove because there are some staff in the clinic.'
			end
		end
		else
		begin
			if LEN(@TempStrNotUpdate)>0
			begin
				set @Msg='Clinics: ' + @TempStr + ' have been removed. Clinics: ' +@TempStrNotUpdate +' cannot remove because there are some staff in the clinic.'
			end
			else
			begin
				set @Msg='Clinics: ' + @TempStr + ' have been removed.'
			end
		end
	end

	select @IsAdd, @Msg	
end
go

------------
drop procedure SA_SaveClinic
go

create procedure SA_SaveClinic
	@ID int,
	@CampusID int,
	@ClinicEn nvarchar(max),
	@ClinicKh nvarchar(max),
	@ABB nvarchar(max),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@ClinicEn)>0 and @CampusID>0)
	begin
		if not exists(select ClinicID from tblsa_ms_clinic where ClinicEn=@ClinicEn and CampusID=@CampusID and ClinicID<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		begin
			if @ID=0
			begin
				insert into tblsa_ms_clinic(CampusID, ClinicEn, ClinicKh, ABB, Mark_Deleted, UserCreate, DateCreate) 
				values(@CampusID, LTRIM(RTRIM(@ClinicEn)), LTRIM(RTRIM(@ClinicKh)), LTRIM(RTRIM(@ABB)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Clinic name: ' +@ClinicEn +' has been added successfully.'
			end
			else if exists(select ClinicID from tblsa_ms_clinic where ClinicID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_ms_clinic set		
					CampusID=@CampusID,
					ClinicEn=LTRIM(RTRIM(@ClinicEn)),
					ClinicKh=LTRIM(RTRIM(@ClinicKh)),
					ABB=LTRIM(RTRIM(@ABB)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where ClinicID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Clinic name: ' +@ClinicEn + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found'
			end
		end
		else
		begin
			set @Msg = 'Clinic name: ' +@ClinicEn  +' already exists in the system.'
		end
	end

	select @IsAdd, @Msg
end
go

----------20191121

--drop procedure SA_GetAllClinicsList
--go

--create procedure SA_GetAllClinicsList
--	@Flag bit
--as 
--begin 
--	if @Flag=0
--	begin
--		select
--			0 as ClinicID, 
--			'*** All clinics' as ClinicEn
--		UNION
--		select 
--			ClinicID,
--			ClinicEn
--		from tblsa_ms_clinic 
--		where Mark_Deleted=0 or Mark_Deleted is null order by ClinicEn
--	end
--	else
--	begin
--		select 
--			ClinicID,
--			ABB as Clinic,
--			ClinicEn
--		from tblsa_ms_clinic 
--		where Mark_Deleted=0 or Mark_Deleted is null 
--		order by ClinicEn	
--	end
--end
--go


drop procedure SA_GetClinicByID
go

create procedure SA_GetClinicByID
	@ID int,
	@isList int
as
begin
	if @ID<>0
	begin
		select top 1			
			ClinicEn,
			ClinicKh,
			ClinicID,
			CampusID,
			ABB,
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_ms_clinic		
		where ClinicID=@ID
	end
	else if @isList=1
	begin
		select distinct
			ClinicID,
			ABB as Clinic,
			ClinicEn
		from tblsa_ms_clinic 
		where Mark_Deleted=0 or Mark_Deleted is null 
		order by ClinicEn	
	end
	else if @isList=2
	begin
		select
			0 as ClinicID, 
			'*** All clinics' as Clinic,
			'*** All clinics' as ClinicEn
		UNION
		select distinct
			ClinicID,
			ABB,
			ClinicEn
		from tblsa_ms_clinic 
		where Mark_Deleted=0 or Mark_Deleted is null 
		order by ClinicEn
	end
	else
	begin
		select distinct
			ABB,
			ClinicEn,
			ClinicKh,
			ClinicID,
			CampusEn,
			C.Mark_Deleted as Inactive,
			U.Name as UserCreate,
			C.DateCreate,
			V.Name as UserUpdate,
			C.DateUpdate
		from tblsa_ms_clinic C
			inner join tblsa_ms_campuses CA on C.CampusID=CA.CampusID
			left join tblsa_set_userlog U on U.UserNo=C.UserCreate
			left join tblsa_set_userlog V on V.UserNo=C.UserUpdate
		where (CA.Mark_Deleted=0 OR CA.Mark_Deleted IS NULL)
			and (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
		order by CampusEn, ClinicEn
	end
end
go


------20191223-----------------
drop procedure SA_SavePatientProfile
go

create procedure SA_SavePatientProfile 
	@PatientID int,
	@FirstName nvarchar(100),
	@LastName nvarchar(100),
	@KLastName nvarchar(100),
	@KFirstName nvarchar(100),
	@Gender nvarchar(10),
	@MaritalStatus nvarchar(50),
	@Nationality nvarchar(50),
	@DOB date,
	@BirthHome nvarchar(300),
	@BirthStreet nvarchar(300),
	@BirthVillage int,
	@BirthSangkat int,
	@BirthKhan int,
	@BirthCity int,
	@CurHome nvarchar(300),
	@CurStreet nvarchar(300),
	@CurVillage int,
	@CurSangkat int,
	@CurKhan int,
	@CurCity int,
	@Occupation int,
	@CellPhone nvarchar(100),
	@HomePhone nvarchar(100),
	@Email nvarchar(200),	
	@NSSF nvarchar(30),
	@PatientTypeID int,
	@CardID nvarchar(50),
	@CorporatedCompany int,
	@CompanyPhone nvarchar(100),
	@CompanyAddress nvarchar(max),
	@EmName nvarchar(100),
	@EmRelation int,
	@EmCellPhone nvarchar(100),
	@EmHomePhone nvarchar(100),
	@RegistrationDate date,
	@RegClinic int,
	@KnownUs nvarchar(max),
	@AppointmentReminder nvarchar(max),
	@Remark nvarchar(max),
	@IsExistImage tinyint,
	@Photo varbinary(max),
	@User nvarchar(100),	
	@IsAdd int output,
	@PatientCode nvarchar(30) output,
	@Msg nvarchar(max) output
as 
begin 
	declare @TempPatientCode nvarchar(20)=''
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the employee id is empty.'
	
	set @KLastName=UPPER(LTRIM(RTRIM(@KLastName)))
	set @KFirstName=UPPER(LTRIM(RTRIM(@KFirstName)))
	set @FirstName=LTRIM(RTRIM(@FirstName))
	set @LastName=LTRIM(RTRIM(@LastName))
	set @BirthHome=LTRIM(RTRIM(@BirthHome))	
	set @BirthStreet=LTRIM(RTRIM(@BirthStreet))	
	set @NSSF=LTRIM(RTRIM(@NSSF))	
	set @CurStreet=LTRIM(RTRIM(@CurStreet))
	set @CurHome=LTRIM(RTRIM(@CurHome))
	set @CellPhone=LTRIM(RTRIM(@CellPhone))
	set @HomePhone=LTRIM(RTRIM(@HomePhone))
	set @Email=LTRIM(RTRIM(REPLACE(REPLACE(@Email, CHAR(13), ''), CHAR(10), '')))	
	set @Remark=LTRIM(RTRIM(@Remark))
	set @EmName=LTRIM(RTRIM(@EmName))
	set @EmCellPhone=LTRIM(RTRIM(@EmCellPhone))
	set @EmHomePhone=LTRIM(RTRIM(@EmHomePhone))
	set @CompanyPhone=LTRIM(RTRIM(@CompanyPhone))
	set @CompanyAddress=LTRIM(RTRIM(@CompanyAddress))
	set @KnownUs=LTRIM(RTRIM(@KnownUs))
	set @AppointmentReminder=LTRIM(RTRIM(@AppointmentReminder))
	set @CardID=LTRIM(RTRIM(@CardID))
	
	if(len(@LastName)>0 and len(@FirstName)>0)
	begin
		--if (select count(PatientID) from tblsa_patients where FirstName=@FirstName and LastName=@LastName and DOB=@DOB and Gender=@Gender and (Mark_Deleted=0 or Mark_Deleted is null))>0 
		if (select count(PatientID) from tblsa_patients where FirstName=@FirstName and LastName=@LastName and DOB=@DOB and Gender=@Gender)>0 
		begin
			--set @PatientCode=(select top 1 PatientCode from tblsa_patients where FirstName=@FirstName and LastName=@LastName and DOB=@DOB and Gender=@Gender and (Mark_Deleted=0 or Mark_Deleted is null))
			set @PatientCode=(select top 1 PatientCode from tblsa_patients where FirstName=@FirstName and LastName=@LastName and DOB=@DOB and Gender=@Gender)
		end
		else
		begin
			set @PatientCode = ISNULL((select top 1 PatientID from tblsa_patients order by rand(PatientID) desc), 0) + 1
			set @PatientCode=CONVERT(NVARCHAR(2), RIGHT(YEAR(GETDATE()), 2)) +REPLICATE('0',7-LEN(RTRIM(@PatientCode))) +RTRIM(@PatientCode)			
		end

		set @TempPatientCode=SUBSTRING(@PatientCode,1,2)+'-' +SUBSTRING(@PatientCode,3,3)+'-'+SUBSTRING(@PatientCode,6,4)
		-------------
		if not exists(select PatientID from tblsa_patients where FirstName=@FirstName and LastName=@LastName and DOB=@DOB and Gender=@Gender and PatientID<>@PatientID)
		--if not exists(select PatientID from tblsa_patients where FirstName=@FirstName and LastName=@LastName and DOB=@DOB and Gender=@Gender and PatientID<>@PatientID and (Mark_Deleted=0 or Mark_Deleted is null))
		begin
			if @PatientID=0
			begin
				insert into tblsa_patients(PatientCode, FirstName, LastName, KFirstName, KLastName, Gender, MaritalStatus, Nationality, DOB, BirthHome, BirthStreet, BirthVillage, BirthSangkat, BirthKhan, BirthCity, CurHome, CurStreet, CurVillage, CurSangkat, CurKhan, CurCity, Occupation, CellPhone, HomePhone, Email, NSSF, PatientTypeID, CardID, CorporatedCompany, CompanyPhone, CompanyAddress, EmName, EmRelation, EmCellPhone, EmHomePhone, RegistrationDate, RegClinic, KnownUs, AppointmentReminder, Remark, Photo, Mark_Deleted, UserCreate, DateCreate) 
				values(@PatientCode, @FirstName, @LastName, @KFirstName, @KLastName, @Gender, @MaritalStatus, @Nationality, @DOB, @BirthHome, @BirthStreet, @BirthVillage, @BirthSangkat, @BirthKhan, @BirthCity, @CurHome, @CurStreet, @CurVillage, @CurSangkat, @CurKhan, @CurCity, @Occupation, @CellPhone, @HomePhone, @Email, @NSSF, @PatientTypeID, @CardID, @CorporatedCompany, @CompanyPhone, @CompanyAddress, @EmName, @EmRelation, @EmCellPhone, @EmHomePhone, @RegistrationDate, @RegClinic, @KnownUs, @AppointmentReminder, @Remark, @Photo, 0, @User, CURRENT_TIMESTAMP) 				
				set @IsAdd=1				
				set @Msg = 'Patient: '+ LTRIM(RTRIM(ISNULL(@FirstName, '') +' ' + ISNULL(@LastName, ''))) + ' has been registered successfully.' +CHAR(10)+CHAR(10) +'This Patient Code is ' +@TempPatientCode +'.'
			end
			else if exists(select PatientID from tblsa_patients where PatientID=@PatientID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_patients set				
					PatientCode=@PatientCode,
					FirstName=@FirstName,
					LastName=@LastName,
					KLastName=@KLastName,
					KFirstName=@KFirstName,
					Gender=@Gender,
					MaritalStatus=@MaritalStatus,
					Nationality=@Nationality,
					DOB=@DOB,
					BirthHome=@BirthHome,
					BirthStreet=@BirthStreet,
					BirthVillage=@BirthVillage,
					BirthSangkat=@BirthSangkat,
					BirthKhan=@BirthKhan,
					CurHome=@CurHome, 
					CurStreet=@CurStreet, 
					CurVillage=@CurVillage, 
					CurSangkat=@CurSangkat, 
					CurKhan=@CurKhan, 
					CurCity=@CurCity, 
					Occupation=@Occupation, 
					CellPhone=@CellPhone, 
					HomePhone=@HomePhone, 
					Email=@Email, 
					NSSF=@NSSF, 
					PatientTypeID=@PatientTypeID,
					CardID=@CardID,
					CorporatedCompany=@CorporatedCompany, 
					CompanyPhone=@CompanyPhone, 
					CompanyAddress=@CompanyAddress, 
					EmName=@EmName, 
					EmRelation=(CASE WHEN LEN(@EmName)=0 THEN 0 ELSE @EmRelation END),
					EmCellPhone=@EmCellPhone, 
					EmHomePhone=@EmHomePhone, 
					RegistrationDate=@RegistrationDate, 
					RegClinic=@RegClinic,
					KnownUs=@KnownUs, 
					AppointmentReminder=@AppointmentReminder, 
					Remark=@Remark,
					DateUpdate=CURRENT_TIMESTAMP, 
					UserUpdate=@User									
				where PatientID=@PatientID 
					and (Mark_Deleted=0 or Mark_Deleted is null)

				if @IsExistImage=0 
				begin
					update tblsa_patients set Photo=@Photo 
					where PatientID=@PatientID 
						and (Mark_Deleted=0 or Mark_Deleted is null)
				end
				set @IsAdd=2
				
				set @Msg = 'Patient: '+ LTRIM(RTRIM(ISNULL(@FirstName, '') +' ' + ISNULL(@LastName, ''))) + ' has been updated successfully.' +CHAR(10)+CHAR(10) +'This Patient Code is ' +@TempPatientCode +'.'
			end
			else if exists(select PatientID from tblsa_patients where PatientID=@PatientID)
			begin
				set @Msg = 'Cannot make update this patient probably he/she already removed or deactived from the system.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'Patient: '+ LTRIM(RTRIM(ISNULL(@FirstName, '') +' ' + ISNULL(@LastName, ''))) +' already exists on the system.'
		end

	end

	select @IsAdd, @PatientCode, @Msg
end
go


----------20191228
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

-----------------------
DROP FUNCTION SA_GetPatientCode
GO

CREATE FUNCTION SA_GetPatientCode(
	@Code nvarchar(20)
)
RETURNS NVARCHAR(20)
AS
BEGIN
	DECLARE @PatientCode NVARCHAR(20)=''

	IF LEN(@Code)<=7
	BEGIN
		SET @PatientCode=REPLICATE('0',7-LEN(RTRIM(@Code)))+RTRIM(@Code)	
	END
	ELSE IF LEN(@Code)=9
	BEGIN
		SET @PatientCode=RIGHT(@Code, 7)
	END

	RETURN @PatientCode
END
GO
----------------20190108

DROP FUNCTION SA_FormatPTCode
go

CREATE FUNCTION SA_FormatPTCode(
	@Code nvarchar(20)
)
RETURNS NVARCHAR(20)
AS
BEGIN
	RETURN SUBSTRING(@Code,1,2)+'-' +SUBSTRING(@Code,3,3)+'-'+SUBSTRING(@Code,6,4)
END
GO

select dbo.SA_GetPatientCode('190000001')

declare @T nvarchar(20)='190000001'
select SUBSTRING(@T,1,2)+'-' +SUBSTRING(@T,3,3)+'-'+SUBSTRING(@T,6,4)

---------------------------
drop procedure SA_GetPatientProfile
go

create procedure SA_GetPatientProfile 
	@PatientCode nvarchar(20)
as 
begin 
	
	if(len(@PatientCode)>0)
	begin
		--SET @PatientCode=dbo.SA_GetPatientCode(@PatientCode)
		select top 1
			[PatientID]
			,[PatientCode]
			,[FirstName]
			,[LastName]
			,[KFirstName]
			,[KLastName]
			,LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as EnglishName	
			,LTRIM(RTRIM(ISNULL(KLastName, '') +' ' + ISNULL(KFirstName, ''))) as KhmerName	
			,[Gender]
			,[MaritalStatus]
			,[Nationality]
			,[DOB]
			,FLOOR(DATEDIFF(DAY, [DOB], GETDATE()) / 365.25) AS Age
			,[BirthHome]
			,[BirthStreet]
			,[BirthVillage]
			,[BirthSangkat]
			,[BirthKhan]
			,[BirthCity]
			,[CurHome]
			,[CurStreet]
			,[CurVillage]
			,[CurSangkat]
			,[CurKhan]
			,[CurCity]
			,[City]
			,'#'+CurHome+', St. '+CurStreet +', ' +VillageEn +', ' +SangkatEn +', ' +KhanEn +', ' +City as PTAddress
			,P.[Occupation]
			,O.Occupation as PTOccupation			
			,[CellPhone]
			,[HomePhone]
			,[Email]
			,[NSSF]
			,PT.[PatientType]
			,P.PatientTypeID
			,P.PatientID
			,[CardID]
			,[CorporatedCompany]
			,[CompanyPhone]
			,[CompanyAddress]
			,[EmName]
			,[EmRelation]
			,[EmCellPhone]
			,[EmHomePhone]
			,[RegistrationDate]
			,[KnownUs]
			,[AppointmentReminder]
			,[Remark]
			,[Photo]
			,P.[Mark_Deleted]
			,P.[UserCreate]
			,P.[DateCreate]
			,P.[UserUpdate]
			,P.[DateUpdate]
		FROM tblsa_patients P
			inner join tblsa_patients_type PT on P.PatientTypeID=PT.ID
			inner join tblsa_ms_location_provinces LP on P.CurCity=LP.PID
			left join tblsa_patients_occupation O on P.Occupation=O.OccupationID
			left join tblsa_ms_location_khan LK on P.CurKhan=LK.KhanID
			left join tblsa_ms_location_sangkat LS on P.CurSangkat=LS.SangkatID
			left join tblsa_ms_location_village LV on P.CurSangkat=LV.VillageID
		--WHERE RIGHT(PatientCode, 7)=@PatientCode
		WHERE PatientCode=@PatientCode
			and (LK.Mark_Deleted=0 OR LK.Mark_Deleted IS NULL)
			and (LS.Mark_Deleted=0 OR LS.Mark_Deleted IS NULL)
			and (LV.Mark_Deleted=0 OR LV.Mark_Deleted IS NULL)
	end
	else
	begin
		select distinct
			[PatientID]
			,[PatientCode]
			,[FirstName]
			,[LastName]
			,[KFirstName]
			,[KLastName]
			,LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as EnglishName	
			,LTRIM(RTRIM(ISNULL(KLastName, '') +' ' + ISNULL(KFirstName, ''))) as KhmerName	
			,[Gender]
			,[MaritalStatus]
			,[Nationality]
			,FLOOR(DATEDIFF(DAY, [DOB], GETDATE()) / 365.25) AS Age
			,[DOB]
			,[BirthHome]
			,[BirthStreet]
			,[BirthVillage]
			,[BirthSangkat]
			,[BirthKhan]
			,[BirthCity]
			,[CurHome]
			,[CurStreet]
			,[CurVillage]
			,[CurSangkat]
			,[CurKhan]
			,[CurCity]
			,'#'+CurHome+', St. '+CurStreet +', ' +VillageEn +', ' +SangkatEn +', ' +KhanEn +', ' +City as PTAddress
			,P.[Occupation]
			,O.Occupation as PTOccupation
			,[CellPhone]
			,[HomePhone]			
			,[Email]
			,[NSSF]
			,[PatientTypeID]
			,[CardID]
			,[CorporatedCompany]
			,[CompanyPhone]
			,[CompanyAddress]
			,[EmName]
			,[EmRelation]
			,[EmCellPhone]
			,[EmHomePhone]
			,[RegistrationDate]
			,[KnownUs]
			,[AppointmentReminder]
			,[Remark]
			,[Photo]
			,P.[Mark_Deleted]
			,P.[UserCreate]
			,P.[DateCreate]
			,P.[UserUpdate]
			,P.[DateUpdate]
		FROM tblsa_patients P
			inner join tblsa_ms_location_provinces LP on P.CurCity=LP.PID
			left join tblsa_patients_occupation O on P.Occupation=O.OccupationID
			left join tblsa_ms_location_khan LK on P.CurKhan=LK.KhanID
			left join tblsa_ms_location_sangkat LS on P.CurSangkat=LS.SangkatID
			left join tblsa_ms_location_village LV on P.CurSangkat=LV.VillageID
		WHERE PatientCode=@PatientCode
			and (LK.Mark_Deleted=0 OR LK.Mark_Deleted IS NULL)
			and (LS.Mark_Deleted=0 OR LS.Mark_Deleted IS NULL)
			and (LV.Mark_Deleted=0 OR LV.Mark_Deleted IS NULL)
		ORDER BY [PatientCode]
	end
end
go

-----------------

---20191228

drop procedure SA_DisablePatientByID
go

create procedure SA_DisablePatientByID
	@PatientID int,
	@PatientCode nvarchar(20),
	@Inactive bit,
	@User int,
	@IsAdd int output,
	@Msg nvarchar(200) output
as
begin
set nocount on
	set @IsAdd = 0
	set @Msg = 'System Error: Cannot performance this operation while the code is empty.'

	if exists(select PatientID from tblsa_patients where PatientID=@PatientID)
	begin	
		update tblsa_patients set 
			Mark_Deleted=@Inactive, 
			UserUpdate=@User,
			DateUpdate=CURRENT_TIMESTAMP				
		where PatientID=@PatientID 
					
		set @IsAdd=1
		if @Inactive=0
		begin
			set @Msg = (select top 1 'Patient: ' +LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) +' with Patient Code: '+ @PatientCode + ' has been restored.' from tblsa_patients where PatientID=@PatientID)
		end
		else
		begin
			set @Msg = (select top 1 'Patient: ' +LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) +' with Patient Code: '+ @PatientCode + ' has been removed.' from tblsa_patients where PatientID=@PatientID)
		end
	end

	select @IsAdd, @Msg	
end
go

--------------------
drop procedure SA_GetPatientCodeList
go

create procedure SA_GetPatientCodeList
as
begin
	select 
		PatientCode
	from tblsa_patients 
	where (Mark_Deleted=0 or Mark_Deleted IS NULL)
	order by PatientCode
end
go

--20191230
drop procedure SA_SavePatientVisit
go

create procedure SA_SavePatientVisit 
	@VisitCode int,
	@PatientCode nvarchar(15),
	@Patient nvarchar(100),
	@MembershipType nvarchar(100),
	@DateIn datetime,
	@ClinicID int,
	@CheckInToDoctor int,
	@ReasonOfVisit nvarchar(max),
	@RegClinic int,
	@User nvarchar(100),	
	@IsAdd int output,
	@PTCodePrint nvarchar(15) output,
	@Msg nvarchar(max) output
as 
begin 
	set @PTCodePrint=SUBSTRING(@PatientCode,1,2)+'-' +SUBSTRING(@PatientCode,3,3)+'-'+SUBSTRING(@PatientCode,6,4)
	declare @NumIn int=0
	declare @VisitStatus nvarchar(100)=''
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while some patient info is empty.'
		
	if(len(@PatientCode)>0 and @ClinicID>0 and @CheckInToDoctor>0)
	begin
		if not exists(select VisitCode from tblsa_patients_visit where CAST(DateIn as DATETIME)=CAST(@DateIn as DATETIME) and CheckInToDoctor=@CheckInToDoctor and ClinicID=@ClinicID and PatientCode=@PatientCode and VisitCode<>@VisitCode and (IsCancelled=0 OR IsCancelled IS NULL))
		--if not exists(select VisitCode from tblsa_patients_visit where CAST(DateIn as DATETIME)=CAST(@DateIn as DATETIME) and CheckInToDoctor=@CheckInToDoctor and ClinicID=@ClinicID and PatientCode=@PatientCode and VisitCode<>@VisitCode and (Mark_Deleted=0 OR Mark_Deleted IS NULL) and (IsCancelled=0 OR IsCancelled IS NULL))
		begin
			if @VisitCode=0
			begin
				if (select max(NumIn) from tblsa_patients_visit where PatientCode=@PatientCode and CAST(DateIn as DATE)=CAST(@DateIn as DATE) and (Mark_Deleted=0 OR Mark_Deleted IS NULL) and (IsCancelled=0 OR IsCancelled IS NULL))=NULL
				begin
					set @NumIn=1
				end
				else
				begin
					set @NumIn=ISNULL((select max(ISNULL(NumIn, 0)) from tblsa_patients_visit where PatientCode=@PatientCode and CAST(DateIn as DATE)=CAST(@DateIn as DATE) and (Mark_Deleted=0 OR Mark_Deleted IS NULL) and (IsCancelled=0 OR IsCancelled IS NULL)), 0)+1
				end

				insert into tblsa_patients_visit(PatientCode, NumIn, MembershipType, ClinicID, CheckInToDoctor, DateIn, ReasonForVisit, IsCancelled, Mark_Deleted, RegClinic, UserCreate, DateCreate)
				select @PatientCode, @NumIn, @MembershipType, @ClinicID, @CheckInToDoctor, @DateIn, @ReasonOfVisit, 0, 0, @RegClinic, @User, CURRENT_TIMESTAMP
				set @IsAdd=2
				set @Msg= (select top 1 'Patient, ' +@PTCodePrint +' is checked-in at clinic: ' +ABB +' on ' +CONVERT(NVARCHAR, @DateIn, 22) +'.' from tblsa_ms_clinic where ClinicID=@ClinicID and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
			end
			else if exists(select VisitCode from tblsa_patients_visit where VisitCode=@VisitCode and (Mark_Deleted=0 OR Mark_Deleted IS NULL) and (IsCancelled=0 OR IsCancelled IS NULL))
			begin
				update tblsa_patients_visit set		
					ClinicID=@ClinicID,
					CheckInToDoctor=@CheckInToDoctor,
					DateIn=@DateIn,
					MembershipType=@MembershipType,
					ReasonForVisit=@ReasonOfVisit,
					RegClinic=@RegClinic,
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where VisitCode=@VisitCode 
					and (Mark_Deleted=0 OR Mark_Deleted IS NULL) 
					and (IsCancelled=0 OR IsCancelled IS NULL)

				set @IsAdd=3
				set @Msg= (select top 1 'Patient, ' +@PTCodePrint +' is modified check-in at clinic: ' +ABB +' on ' +CONVERT(NVARCHAR, @DateIn, 22) +'.' from tblsa_ms_clinic where ClinicID=@ClinicID and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
			end
			else if exists(select VisitCode from tblsa_patients_visit where VisitCode=@VisitCode)
			begin
				set @Msg = 'Cannot make update this patient has been removed or deactived from the system.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg= 'This patient, ' +@PTCodePrint +' already exists checked-in on the system.'
		end
	end
	
	select @IsAdd, @PTCodePrint, @Msg
end
go

----20200103
drop procedure SA_IsMultiCheckedInPerDay
go

create procedure SA_IsMultiCheckedInPerDay
	@PatientCode nvarchar(20),
	@DateIn datetime
as
begin
	SELECT VisitCode FROM tblsa_patients_visit Where CAST(DateIn AS DATE)=CAST(GETDATE() AS DATE) and PatientCode=@PatientCode and (Mark_Deleted=0 OR Mark_Deleted IS NULL) and (IsCancelled=0 OR IsCancelled IS NULL)
end
go


----20200106
drop procedure SA_IsCheckedIn
go

create procedure SA_IsCheckedIn 
	@PatientCode nvarchar(15),
	@DateIn datetime
as 
begin 
	SELECT VisitCode FROM tblsa_patients_visit Where DateIn IS NOT NULL and DateOut IS NULL and CAST(DateIn as DATETIME)=CAST(@DateIn as DATETIME) and PatientCode=@PatientCode and (Mark_Deleted=0 OR Mark_Deleted IS NULL) and (IsCancelled=0 OR IsCancelled IS NULL)
end
go


--select CONVERT(NVARCHAR, GETDATE(), 22)

drop procedure SA_GetPatientCheckInList
go

create procedure SA_GetPatientCheckInList
	@ClinicID int,
	@VisitCode int,
	@IsAdmin bit
as
begin
	if @ClinicID<>0
	begin
		if @VisitCode<>0
		begin
			select top 1
				VisitCode,
				P.PatientCode,
				LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as EnglishName,
				Gender,
				FLOOR(DATEDIFF(DAY, [DOB], GETDATE()) / 365.25) AS Age,
				DOB,
				ReasonForVisit,
				DateIn,
				DateOut,
				ClinicID,
				NumIn,
				VisitedDoctor,
				PTComplain,
				DRProgressNote,
				PTDiagnosis,
				VisitStatus,
				TreatmentBy,
				TreatmentDate,
				CheckInToDoctor,
				MembershipType,
				IsCancelled,
				V.Mark_Deleted
			from tblsa_patients P
				inner join tblsa_patients_visit V on P.PatientCode=V.PatientCode
			where VisitCode=@VisitCode
		end
		else
		begin
			if @IsAdmin=1
			begin
				select distinct
					dbo.SA_FormatPTCode(P.PatientCode) as PatientCode,
					LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as EnglishName,
					Gender,
					DOB,
					FLOOR(DATEDIFF(DAY, [DOB], GETDATE()) / 365.25) AS Age,
					VisitCode,
					NumIn,
					ClinicEn,
					ReasonForVisit,
					--CONVERT(NVARCHAR, DateIn, 22) as DateCheckIn,
					DateIn as DateCheckIn,
					V.IsCancelled,
					V.Mark_Deleted as Inactive,					
					U.Name as UserCreate,
					V.DateCreate,
					M.Name as UserUpdate,
					V.DateUpdate
				from tblsa_patients P
					inner join tblsa_patients_visit V on P.PatientCode=V.PatientCode
					inner join tblsa_ms_clinic C on C.ClinicID=V.ClinicID
					left join tblsa_set_userlog U on U.UserNo=V.UserCreate
					left join tblsa_set_userlog M on M.UserNo=V.UserUpdate
				where V.ClinicID=@ClinicID
					and DateIn IS NOT NULL 
					and DateOut IS NULL 
					and (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL) 					
					and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL) 
				order by DateCheckIn Desc
			end
			else
			begin
				select distinct
					dbo.SA_FormatPTCode(P.PatientCode) as PatientCode,
					LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as EnglishName,
					Gender,
					DOB,
					FLOOR(DATEDIFF(DAY, [DOB], GETDATE()) / 365.25) AS Age,
					VisitCode,
					NumIn,
					ClinicEn,
					ReasonForVisit,
					--CONVERT(NVARCHAR, DateIn, 22) as DateCheckIn,
					DateIn as DateCheckIn,
					V.IsCancelled,
					--V.Mark_Deleted as Inactive,					
					U.Name as UserCreate,
					V.DateCreate,
					M.Name as UserUpdate,
					V.DateUpdate
				from tblsa_patients P
					inner join tblsa_patients_visit V on P.PatientCode=V.PatientCode
					inner join tblsa_ms_clinic C on C.ClinicID=V.ClinicID
					left join tblsa_set_userlog U on U.UserNo=V.UserCreate
					left join tblsa_set_userlog M on M.UserNo=V.UserUpdate
				where V.ClinicID=@ClinicID
					and DateIn IS NOT NULL 
					and DateOut IS NULL 
					and (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL) 					
					and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL) 
				order by DateCheckIn Desc
			end
		end
	end
	else
	begin
		if @VisitCode<>0
		begin
			select top 1
				VisitCode,
				P.PatientCode,
				LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as EnglishName,
				Gender,
				FLOOR(DATEDIFF(DAY, [DOB], GETDATE()) / 365.25) AS Age,
				DOB,				
				ReasonForVisit,
				DateIn,
				DateOut,
				ClinicID,
				NumIn,
				VisitedDoctor,
				PTComplain,
				DRProgressNote,
				PTDiagnosis,
				VisitStatus,
				TreatmentBy,
				TreatmentDate,
				CheckInToDoctor,
				MembershipType,
				IsCancelled,
				V.Mark_Deleted
			from tblsa_patients P
				inner join tblsa_patients_visit V on P.PatientCode=V.PatientCode
			where VisitCode=@VisitCode
		end
		else
		begin
			if @IsAdmin=1
			begin
				select distinct
					dbo.SA_FormatPTCode(P.PatientCode) as PatientCode,
					LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as EnglishName,
					Gender,
					DOB,
					FLOOR(DATEDIFF(DAY, [DOB], GETDATE()) / 365.25) AS Age,
					VisitCode,
					NumIn,
					ClinicEn,
					ReasonForVisit,
					--CONVERT(NVARCHAR, DateIn, 22) as DateCheckIn,
					DateIn as DateCheckIn,
					V.IsCancelled,
					V.Mark_Deleted as Inactive,
					U.Name as UserCreate,
					V.DateCreate,
					M.Name as UserUpdate,
					V.DateUpdate
				from tblsa_patients P
					inner join tblsa_patients_visit V on P.PatientCode=V.PatientCode
					inner join tblsa_ms_clinic C on C.ClinicID=V.ClinicID
					left join tblsa_set_userlog U on U.UserNo=V.UserCreate
					left join tblsa_set_userlog M on M.UserNo=V.UserUpdate
				where DateIn IS NOT NULL 
					and DateOut IS NULL 
					and (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL) 					
					and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL) 
				order by DateCheckIn Desc
			end
			else
			begin
				select distinct
					dbo.SA_FormatPTCode(P.PatientCode) as PatientCode,
					LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as EnglishName,
					Gender,
					DOB,
					FLOOR(DATEDIFF(DAY, [DOB], GETDATE()) / 365.25) AS Age,
					VisitCode,
					NumIn,
					ClinicEn,
					ReasonForVisit,
					--CONVERT(NVARCHAR, DateIn, 22) as DateCheckIn,
					DateIn as DateCheckIn,
					V.IsCancelled,
					--V.Mark_Deleted as Inactive,									
					U.Name as UserCreate,
					V.DateCreate,
					M.Name as UserUpdate,
					V.DateUpdate
				from tblsa_patients P
					inner join tblsa_patients_visit V on P.PatientCode=V.PatientCode
					inner join tblsa_ms_clinic C on C.ClinicID=V.ClinicID
					left join tblsa_set_userlog U on U.UserNo=V.UserCreate
					left join tblsa_set_userlog M on M.UserNo=V.UserUpdate
				where DateIn IS NOT NULL 
					and DateOut IS NULL 
					and (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL) 					
					and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL) 
				order by DateCheckIn Desc
			end
		end
	end
end
go

------20200112-----------
--drop procedure SA_GetDoctorsToList
--go

--create procedure SA_GetDoctorsToList
--	@Flag int
--as
--begin
--	if @Flag=0
--	begin
--		select
--			0 as ID, 
--			'*** All doctors' as Doctor,
--			'*** All' as DrType
--		UNION
--		select
--			EID.ID,
--			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Doctor,
--			P.PositionEn as DrType
--		from tblsa_employee_cardid EID
--			INNER join tblsa_employees E on E.StaffNo=EID.StaffNo
--			LEFT JOIN tblsa_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
--			LEFT JOIN tblsa_ms_positions P on P.PositionID=EH.PositionID
--			INNER JOIN tblsa_employee_resigns ER ON ER.CardIDNo=EID.ID
--		where IsDoctor=1
--			and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
--			and (ResignCode in (9, 0) OR ResignCode IS NULL)
--			and (ER.Mark_Deleted=0 OR ER.Mark_Deleted IS NULL)
--			and (EH.Mark_Deleted=0 OR EH.Mark_Deleted IS NULL)
--			and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
--		order by Doctor
--	end
--	else
--	begin
--		select
--			EID.ID,
--			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Doctor,
--			P.PositionEn as DrType
--		from tblsa_employee_cardid EID
--			INNER join tblsa_employees E on E.StaffNo=EID.StaffNo
--			LEFT JOIN tblsa_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
--			LEFT JOIN tblsa_ms_positions P on P.PositionID=EH.PositionID
--			INNER JOIN tblsa_employee_resigns ER ON ER.CardIDNo=EID.ID
--		where IsDoctor=1
--			and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
--			and (ResignCode in (9, 0) OR ResignCode IS NULL)
--			and (ER.Mark_Deleted=0 OR ER.Mark_Deleted IS NULL)
--			and (EH.Mark_Deleted=0 OR EH.Mark_Deleted IS NULL)
--			and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
--		order by Doctor
--	end
--end
--go

------------------20200102
drop procedure SA_RemovePatientVisit
go

create procedure SA_RemovePatientVisit
	@StrID nvarchar(max),
	@IsCancell bit,
	@IsRemove bit,	
	@FlagRemove bit,
	@User int,
	@IsUpdate int output,
	@Msg nvarchar(max) output
as
begin
	set @IsUpdate=0
	set @Msg='There is no selected patients to perform action.'
	DECLARE @TempStr nvarchar(max)=''

	DECLARE @TblTempID TABLE(ID int)
	INSERT INTO @TblTempID SELECT Name FROM dbo.SA_SplitString(@StrID, ',')

	DECLARE @TempID NVARCHAR(10)
	DECLARE DB_CURSOR CURSOR FOR SELECT ID from @TblTempID
	OPEN DB_CURSOR 
	
	FETCH NEXT FROM DB_CURSOR INTO @TempID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		if exists(select VisitCode from tblsa_patients_visit where VisitCode=@TempID)
		begin			
			update tblsa_patients_visit set
				IsCancelled=(CASE @FlagRemove WHEN 1 THEN IsCancelled ELSE @IsCancell END),
				Mark_Deleted=(CASE @FlagRemove WHEN 1 THEN @IsRemove ELSE Mark_Deleted END),
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP
			where VisitCode=@TempID
			set @IsUpdate=1				
			set @TempStr=@TempStr +(select top 1 SUBSTRING(PatientCode,1,2)+'-' +SUBSTRING(PatientCode,3,3)+'-'+SUBSTRING(PatientCode,6,4) from tblsa_patients_visit where VisitCode=@TempID) +', ' 						
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
		if @FlagRemove=1
		begin
			if @IsRemove=0
			begin
				set @Msg='Patients with Code: ' + @TempStr + ' has been restored.'	
			end
			else
			begin
				set @Msg='Patients with Code: ' + @TempStr + ' has been removed.'	
			end
		end
		else
		begin
			if @IsCancell=0
			begin
				set @Msg='Patients with Code: ' + @TempStr + ' has been reactivated.'	
			end
			else
			begin
				set @Msg='Patients with Code: ' + @TempStr + ' has been cancelled.'	
			end
		end
	end
	
	select @IsUpdate, @Msg	
end
go

--FORMAT DATE AND TIME
--SELECT FORMAT(getdate(), 'MMM dd yyyy')
--SELECT CONVERT(VARCHAR(12), SYSDATETIME(), 107) AS [Mon DD, YYYY]

--select CONVERT(varchar(15),CAST(SYSDATETIME() AS TIME),100)

--SELECT GetDate() AS Example, 
--substring(convert(varchar(20), GetDate(), 9), 13, 5) + ' ' + 
--substring(convert(varchar(30), GetDate(), 9), 25, 2)

--declare @T as datetime='2019-10-12 1:32:00'
--SELECT REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar,@T,100),7)),7),'AM',' AM'),'PM',' PM')
--SELECT REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar,getdate(),100),7)),7),'AM',' AM'),'PM',' PM')
-----20200103
drop procedure SA_CheckPatientReminder
go

create procedure SA_CheckPatientReminder
	@ClinicID int,
	@ReminderCode int
as
begin	
	if @ClinicID<>0
	begin
		if @ReminderCode>0
		begin
			SELECT TOP 1 
				[ReminderCode]
				,R.[PatientCode]
				,LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as PatientName
				,Gender
				,FLOOR(DATEDIFF(DAY, [DOB], GETDATE()) / 365.25) AS Age
				,DOB
				,[PTReminder]
				,CellPhone
				,City
				,P.CurCity
				,R.[ClinicID]
				--,[CampusID]
				,[IsReminderTo]
				,CONVERT(VARCHAR(12), DateToReminder, 107) AS DateReminder
				,REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar, DateToReminder,100),7)),7),'AM',' AM'),'PM',' PM') as TimeReminder
				,[ReminderToUsername]
				,[DateToReminder]
				,U.Name as [UserCreate]
				,R.[DateCreate]
				,M.Name as [UserUpdate]
				,R.[DateUpdate]
			FROM MJQEWarehouse.dbo.tblsa_patients_appointment_reminder R
				inner join tblsa_patients P on R.PatientCode=P.PatientCode
				inner join tblsa_ms_clinic C on R.ClinicID=C.ClinicID
				left join tblsa_set_userlog A on A.UserNo=R.ReminderToUsername
				left join tblsa_set_userlog U on U.UserNo=R.UserCreate
				left join tblsa_set_userlog M on M.UserNo=R.UserUpdate
				inner join tblsa_ms_location_provinces L on L.PID=P.CurCity
			Where ReminderCode=@ReminderCode				
				and R.ClinicID=@ClinicID
				and (R.Mark_Deleted=0 OR R.Mark_Deleted IS NULL)
			order by R.DateCreate desc
		end
		else
		begin
			SELECT distinct
				ReminderCode
				,dbo.SA_FormatPTCode(P.PatientCode) as PatientCode
				,LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as PatientName
				,Gender
				,FLOOR(DATEDIFF(DAY, [DOB], GETDATE()) / 365.25) AS Age
				,DOB
				,PTReminder
				,R.ClinicID
				,C.ClinicEn
				--,CampusID
				,IsReminderTo
				,U.Name as ReminderToUsername				
				,CONVERT(VARCHAR(12), DateToReminder, 107) AS DateReminder
				,REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar, DateToReminder,100),7)),7),'AM',' AM'),'PM',' PM') as TimeReminder
				,DateToReminder
				,R.Mark_Deleted as Inactive
				,U.Name as [UserCreate]
				,R.[DateCreate]
				,M.Name as [UserUpdate]
				,R.[DateUpdate]
			FROM MJQEWarehouse.dbo.tblsa_patients_appointment_reminder R
				inner join tblsa_patients P on R.PatientCode=P.PatientCode
				inner join tblsa_ms_clinic C on R.ClinicID=C.ClinicID
				left join tblsa_set_userlog A on A.UserNo=R.ReminderToUsername
				left join tblsa_set_userlog U on U.UserNo=R.UserCreate
				left join tblsa_set_userlog M on M.UserNo=R.UserUpdate
			Where R.ClinicID=@ClinicID
				--and (R.Mark_Deleted=0 OR R.Mark_Deleted IS NULL)
			order by R.DateCreate desc
		end
	end
	else
	begin
		if @ReminderCode>0
		begin
			SELECT TOP 1 
				[ReminderCode]
				,R.[PatientCode]
				,LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as PatientName
				,Gender
				,FLOOR(DATEDIFF(DAY, [DOB], GETDATE()) / 365.25) AS Age
				,DOB
				,[PTReminder]
				,CellPhone
				,City
				,P.CurCity
				,R.[ClinicID]
				--,[CampusID]
				,[IsReminderTo]
				,[ReminderToUsername]
				,CONVERT(VARCHAR(12), DateToReminder, 107) AS DateReminder
				,REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar, DateToReminder,100),7)),7),'AM',' AM'),'PM',' PM') as TimeReminder
				,[DateToReminder]
				,U.Name as [UserCreate]
				,R.[DateCreate]
				,M.Name as [UserUpdate]
				,R.[DateUpdate]
			FROM MJQEWarehouse.dbo.tblsa_patients_appointment_reminder R
				inner join tblsa_patients P on R.PatientCode=P.PatientCode
				inner join tblsa_ms_clinic C on R.ClinicID=C.ClinicID
				left join tblsa_set_userlog A on A.UserNo=R.ReminderToUsername
				left join tblsa_set_userlog U on U.UserNo=R.UserCreate
				left join tblsa_set_userlog M on M.UserNo=R.UserUpdate
				inner join tblsa_ms_location_provinces L on L.PID=P.CurCity
			Where ReminderCode=@ReminderCode				
				and (R.Mark_Deleted=0 OR R.Mark_Deleted IS NULL)
			order by R.DateCreate desc
		end
		else
		begin
			SELECT distinct
				ReminderCode
				,dbo.SA_FormatPTCode(P.PatientCode) as PatientCode
				,LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as PatientName
				,Gender
				,FLOOR(DATEDIFF(DAY, [DOB], GETDATE()) / 365.25) AS Age
				,DOB
				,PTReminder
				,R.ClinicID
				,C.ClinicEn
				--,CampusID
				,IsReminderTo
				,U.Name as ReminderToUsername				
				,CONVERT(VARCHAR(12), DateToReminder, 107) AS DateReminder
				,REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar,DateToReminder,100),7)),7),'AM',' AM'),'PM',' PM') as TimeReminder
				,DateToReminder
				,R.Mark_Deleted as Inactive
				,U.Name as [UserCreate]
				,R.[DateCreate]
				,M.Name as [UserUpdate]
				,R.[DateUpdate]
			FROM MJQEWarehouse.dbo.tblsa_patients_appointment_reminder R
				inner join tblsa_patients P on R.PatientCode=P.PatientCode
				inner join tblsa_ms_clinic C on R.ClinicID=C.ClinicID
				left join tblsa_set_userlog A on A.UserNo=R.ReminderToUsername
				left join tblsa_set_userlog U on U.UserNo=R.UserCreate
				left join tblsa_set_userlog M on M.UserNo=R.UserUpdate
			--Where (R.Mark_Deleted=0 OR R.Mark_Deleted IS NULL)
			order by R.DateCreate desc
		end
	end
end
go


---------
drop procedure SA_CheckPatientReminderAlert
go

create procedure SA_CheckPatientReminderAlert
	@ClinicID int,
	@PatientCode nvarchar(20)
as
begin	
	if @ClinicID<>0
	begin
		if len(@PatientCode)>0
		begin
			SELECT TOP 1 
				[ReminderCode]
				,R.[PatientCode]
				,R.[PTReminder]
				,LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as PatientName
				,R.[ClinicID]
				--,[CampusID]
				,[IsReminderTo]
				,[ReminderToUsername]
				,CONVERT(VARCHAR(12), DateToReminder, 107) AS DateRemind
				,REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar, DateToReminder,100),7)),7),'AM',' AM'),'PM',' PM') as TimeReminder
				,[DateToReminder]
				,U.Name as UserCreate
				,R.DateCreate
				,M.Name as UserUpdate
				,R.DateUpdate
			FROM MJQEWarehouse.dbo.tblsa_patients_appointment_reminder R
				inner join tblsa_patients P on R.PatientCode=P.PatientCode
				inner join tblsa_ms_clinic C on R.ClinicID=C.ClinicID
				left join tblsa_set_userlog U on U.UserNo=R.UserCreate
				left join tblsa_set_userlog M on M.UserNo=R.UserUpdate
			Where R.PatientCode=@PatientCode				
				and R.ClinicID=@ClinicID
				and (R.Mark_Deleted=0 OR R.Mark_Deleted IS NULL)
			order by DateCreate desc
		end
		else
		begin
			SELECT distinct
				ReminderCode
				,dbo.SA_FormatPTCode(P.PatientCode) as PatientCode
				,LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as PatientName
				,Gender
				,FLOOR(DATEDIFF(DAY, [DOB], GETDATE()) / 365.25) AS Age
				,DOB
				,PTReminder
				,R.ClinicID
				,C.ClinicEn
				--,CampusID
				,IsReminderTo
				,ReminderToUsername				
				,CONVERT(VARCHAR(12), DateToReminder, 107) AS DateRemind
				,REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar, DateToReminder,100),7)),7),'AM',' AM'),'PM',' PM') as TimeReminder
				,DateToReminder
				,R.Mark_Deleted as Inactive
				,U.Name as UserCreate
				,R.DateCreate
				,M.Name as UserUpdate
				,R.DateUpdate
			FROM MJQEWarehouse.dbo.tblsa_patients_appointment_reminder R
				inner join tblsa_patients P on R.PatientCode=P.PatientCode
				inner join tblsa_ms_clinic C on R.ClinicID=C.ClinicID
				left join tblsa_set_userlog U on U.UserNo=R.UserCreate
				left join tblsa_set_userlog M on M.UserNo=R.UserUpdate
			Where R.ClinicID=@ClinicID
				and (R.Mark_Deleted=0 OR R.Mark_Deleted IS NULL)
			order by R.DateCreate desc
		end
	end
	else
	begin
		if len(@PatientCode)>0
		begin
			SELECT TOP 1 
				[ReminderCode]
				,R.[PatientCode]
				,R.[PTReminder]
				,LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as PatientName
				,R.[ClinicID]
				--,[CampusID]
				,[IsReminderTo]
				,[ReminderToUsername]
				,CONVERT(VARCHAR(12), DateToReminder, 107) AS DateRemind
				,REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar, DateToReminder,100),7)),7),'AM',' AM'),'PM',' PM') as TimeReminder
				,[DateToReminder]
				,U.Name as UserCreate
				,R.DateCreate
				,M.Name as UserUpdate
				,R.DateUpdate
			FROM MJQEWarehouse.dbo.tblsa_patients_appointment_reminder R
				inner join tblsa_patients P on R.PatientCode=P.PatientCode
				inner join tblsa_ms_clinic C on R.ClinicID=C.ClinicID
				left join tblsa_set_userlog U on U.UserNo=R.UserCreate
				left join tblsa_set_userlog M on M.UserNo=R.UserUpdate
			Where R.PatientCode=@PatientCode				
				and (R.Mark_Deleted=0 OR R.Mark_Deleted IS NULL)
			order by DateCreate desc
		end
		else
		begin
			SELECT distinct
				ReminderCode
				,dbo.SA_FormatPTCode(P.PatientCode) as PatientCode
				,LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as PatientName
				,Gender
				,FLOOR(DATEDIFF(DAY, [DOB], GETDATE()) / 365.25) AS Age
				,DOB
				,PTReminder
				,R.ClinicID
				,C.ClinicEn
				--,CampusID
				,IsReminderTo
				,ReminderToUsername				
				,CONVERT(VARCHAR(12), DateToReminder, 107) AS DateRemind
				,REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar,DateToReminder,100),7)),7),'AM',' AM'),'PM',' PM') as TimeReminder
				,DateToReminder
				,R.Mark_Deleted as Inactive
				,U.Name as UserCreate
				,R.DateCreate
				,M.Name as UserUpdate
				,R.DateUpdate
			FROM MJQEWarehouse.dbo.tblsa_patients_appointment_reminder R
				inner join tblsa_patients P on R.PatientCode=P.PatientCode
				inner join tblsa_ms_clinic C on R.ClinicID=C.ClinicID
				left join tblsa_set_userlog U on U.UserNo=R.UserCreate
				left join tblsa_set_userlog M on M.UserNo=R.UserUpdate
			Where (R.Mark_Deleted=0 OR R.Mark_Deleted IS NULL)
			order by R.DateCreate desc
		end
	end
end
go


-----------------------------

drop procedure SA_DisablePatientReminder
go

create procedure SA_DisablePatientReminder
	@StrID nvarchar(max),	
	@Inactive bit,
	@User int,
	@IsUpdate int output,
	@Msg nvarchar(max) output
as
begin
	set @IsUpdate=0
	set @Msg='There is no selected patients to perform action.'
	DECLARE @TempStr nvarchar(max)=''

	DECLARE @TblTempID TABLE(ID int)
	INSERT INTO @TblTempID SELECT Name FROM dbo.SA_SplitString(@StrID, ',')

	DECLARE @TempID NVARCHAR(10)
	DECLARE DB_CURSOR CURSOR FOR SELECT ID from @TblTempID
	OPEN DB_CURSOR 
	
	FETCH NEXT FROM DB_CURSOR INTO @TempID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		if exists(select ReminderCode from tblsa_patients_appointment_reminder where ReminderCode=@TempID)
		begin			
			update tblsa_patients_appointment_reminder set				
				Mark_Deleted=@Inactive,
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP
			where ReminderCode=@TempID
			set @IsUpdate=1				
			set @TempStr=@TempStr +(select top 1 SUBSTRING(PatientCode,1,2)+'-' +SUBSTRING(PatientCode,3,3)+'-'+SUBSTRING(PatientCode,6,4) from tblsa_patients_appointment_reminder where ReminderCode=@TempID) +', ' 						
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
		if @Inactive=0
		begin
			set @Msg='Patient Code: ' + @TempStr + ' has been reset the reminder.'	
		end
		else
		begin
			set @Msg='Patient Code: ' + @TempStr + ' has been cancelled the reminder.'	
		end
	end
	
	select @IsUpdate, @Msg	
end
go

--20191230
drop procedure SA_SavePatientReminder
go

create procedure SA_SavePatientReminder 
	@ReminderCode int,
	@PatientCode nvarchar(15),
	@Patient nvarchar(100),
	@ClinicID int,
	@PTReminder nvarchar(max),	
	@IsReminderTo bit,
	@ReminderToUsername int,
	@DateToReminder datetime,
	@User nvarchar(100),	
	@IsAdd int output,
	@PTCodePrint nvarchar(15) output,
	@Msg nvarchar(max) output
as 
begin 
	set @PTCodePrint=SUBSTRING(@PatientCode,1,2)+'-' +SUBSTRING(@PatientCode,3,3)+'-'+SUBSTRING(@PatientCode,6,4)
	declare @NumIn int=0
	declare @VisitStatus nvarchar(100)=''
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while some patient info is empty.'
		
	if(len(@PatientCode)>0 and len(@PTReminder)>0)
	begin
		if not exists(select ReminderCode from tblsa_patients_appointment_reminder where CAST(DateToReminder as DATETIME)=CAST(@DateToReminder as DATETIME) and PatientCode=@PatientCode and ReminderCode<>@ReminderCode)
		--if not exists(select ReminderCode from tblsa_patients_appointment_reminder where CAST(DateToReminder as DATETIME)=CAST(@DateToReminder as DATETIME) and PatientCode=@PatientCode and ReminderCode<>@ReminderCode and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
		begin
			if @ReminderCode=0
			begin
				insert into tblsa_patients_appointment_reminder(PatientCode, PTReminder, ClinicID, IsReminderTo, ReminderToUsername, DateToReminder, Mark_Deleted, UserCreate, DateCreate)
				select @PatientCode, RTRIM(LTRIM(@PTReminder)), @ClinicID, @IsReminderTo, @ReminderToUsername, @DateToReminder, 0, @User, CURRENT_TIMESTAMP
				set @IsAdd=2
				set @Msg= 'An appointment has been set for patient, ' +@PTCodePrint +' on ' +CONVERT(NVARCHAR, @DateToReminder, 100) +'.'
			end
			else if exists(select ReminderCode from tblsa_patients_appointment_reminder where ReminderCode=@ReminderCode and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
			begin
				update tblsa_patients_appointment_reminder set		
					ClinicID=@ClinicID,
					PTReminder=RTRIM(LTRIM(@PTReminder)),
					IsReminderTo=@IsReminderTo,
					ReminderToUsername=@ReminderToUsername,
					DateToReminder=@DateToReminder,
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where ReminderCode=@ReminderCode 
					and (Mark_Deleted=0 OR Mark_Deleted IS NULL) 				

				set @IsAdd=3
				set @Msg= 'An appointment has been reset for patient, ' +@PTCodePrint +' on ' +CONVERT(NVARCHAR, @DateToReminder, 100) +'.'
			end
			else if exists(select ReminderCode from tblsa_patients_appointment_reminder where ReminderCode=@ReminderCode)
			begin
				set @Msg = 'Cannot make update this patient has been removed or deactived from the system.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg= 'The appointment is already set for patient, ' +@PTCodePrint +' on ' +CONVERT(NVARCHAR, @DateToReminder, 100) +'.'
		end
	end
	select @IsAdd, @PTCodePrint, @Msg
end
go

-------------
drop procedure SA_GetBMICategories
go

create procedure SA_GetBMICategories
	@Score float
as
begin
	if @Score>0
	begin
		declare @i int=(select max(ID) from tblsa_ms_bmi_categories)
		while @i>=1
		begin
			if (select count(ID) from tblsa_ms_bmi_categories where Score<=@Score and ID=@i)>0
			begin
				select top 1
					@i,
					ID
					,[Classification]
					,[BodyMassIndexScore]
				FROM [MJQEWarehouse].[dbo].[tblsa_ms_bmi_categories] 
				where Score<=@Score and ID=@i
				ORDER BY Score
				break
			end
			set @i-=1
		end
	end
	else
	begin
		SELECT 
			ID
			,[Classification]
			,[BodyMassIndexScore]
		FROM [MJQEWarehouse].[dbo].[tblsa_ms_bmi_categories] 
		ORDER BY ID
	end
end
go


---------------
----20200112-----------
drop procedure SA_GetDoctorsToList
go

create procedure SA_GetDoctorsToList
	@ID int,
	@isList int
as
begin
	if  @isList=0 and @ID<>0
	begin
		select distinct
			EID.ID,
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Doctor,
			P.PositionEn as DrType
		from tblsa_employee_cardid EID
			INNER join tblsa_employees E on E.StaffNo=EID.StaffNo
			LEFT JOIN tblsa_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
			LEFT JOIN tblsa_ms_positions P on P.PositionID=EH.PositionID
			INNER JOIN tblsa_employee_resigns ER ON ER.CardIDNo=EID.ID
		where IsDoctor=1
			and EID.ID=@ID
			and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
			and (ResignCode in (9, 0) OR ResignCode IS NULL)
			and (ER.Mark_Deleted=0 OR ER.Mark_Deleted IS NULL)
			and (EH.Mark_Deleted=0 OR EH.Mark_Deleted IS NULL)
			and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
		order by P.PositionEn, Doctor
	end
	else if @isList=1 
	begin
		select distinct
			EID.ID,
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Doctor,
			P.PositionEn as DrType
		from tblsa_employee_cardid EID
			INNER join tblsa_employees E on E.StaffNo=EID.StaffNo
			LEFT JOIN tblsa_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
			LEFT JOIN tblsa_ms_positions P on P.PositionID=EH.PositionID
			INNER JOIN tblsa_employee_resigns ER ON ER.CardIDNo=EID.ID
		where IsDoctor=1
			and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
			and (ResignCode in (9, 0) OR ResignCode IS NULL)
			and (ER.Mark_Deleted=0 OR ER.Mark_Deleted IS NULL)
			and (EH.Mark_Deleted=0 OR EH.Mark_Deleted IS NULL)
			and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
		order by P.PositionEn, Doctor
	end
	else if @isList=2
	begin
		select
			0 as ID, 
			'*** All doctors' as Doctor,
			'*** All' as DrType
		UNION
		select distinct
			EID.ID,
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Doctor,
			P.PositionEn as DrType
		from tblsa_employee_cardid EID
			INNER join tblsa_employees E on E.StaffNo=EID.StaffNo
			LEFT JOIN tblsa_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
			LEFT JOIN tblsa_ms_positions P on P.PositionID=EH.PositionID
			INNER JOIN tblsa_employee_resigns ER ON ER.CardIDNo=EID.ID
		where IsDoctor=1
			and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
			and (ResignCode in (9, 0) OR ResignCode IS NULL)
			and (ER.Mark_Deleted=0 OR ER.Mark_Deleted IS NULL)
			and (EH.Mark_Deleted=0 OR EH.Mark_Deleted IS NULL)
			and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
		order by DrType, Doctor
	end
	else if @isList=3 and @ID<>0
	begin
		select distinct
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Doctor
		from tblsa_employee_cardid EID
			INNER join tblsa_employees E on E.StaffNo=EID.StaffNo
			LEFT JOIN tblsa_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
			LEFT JOIN tblsa_ms_positions P on P.PositionID=EH.PositionID
			INNER JOIN tblsa_employee_resigns ER ON ER.CardIDNo=EID.ID
		where IsDoctor=1
			and EID.ID=@ID
			and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
			and (ResignCode in (9, 0) OR ResignCode IS NULL)
			and (ER.Mark_Deleted=0 OR ER.Mark_Deleted IS NULL)
			and (EH.Mark_Deleted=0 OR EH.Mark_Deleted IS NULL)
			and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
		order by Doctor
	end
	else if @isList=3 and @ID=0
	begin
		select distinct
			LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as Doctor
		from tblsa_employee_cardid EID
			INNER join tblsa_employees E on E.StaffNo=EID.StaffNo
			LEFT JOIN tblsa_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
			LEFT JOIN tblsa_ms_positions P on P.PositionID=EH.PositionID
			INNER JOIN tblsa_employee_resigns ER ON ER.CardIDNo=EID.ID
		where IsDoctor=1
			and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
			and (ResignCode in (9, 0) OR ResignCode IS NULL)
			and (ER.Mark_Deleted=0 OR ER.Mark_Deleted IS NULL)
			and (EH.Mark_Deleted=0 OR EH.Mark_Deleted IS NULL)
			and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
		order by Doctor
	end
end
go



drop procedure SA_GetDoctorID
go

create procedure SA_GetDoctorID
	@Doctor nvarchar(100)
as
begin
	select distinct
		EID.ID			
	from tblsa_employee_cardid EID
		INNER join tblsa_employees E on E.StaffNo=EID.StaffNo
		LEFT JOIN tblsa_employee_employment EH ON EID.ID=EH.CardIDNo AND EID.TranID=EH.TranID 
		LEFT JOIN tblsa_ms_positions P on P.PositionID=EH.PositionID
		INNER JOIN tblsa_employee_resigns ER ON ER.CardIDNo=EID.ID
	where IsDoctor=1
		and LOWER(LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))))=LOWER(@Doctor)
		and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
		and (ResignCode in (9, 0) OR ResignCode IS NULL)
		and (ER.Mark_Deleted=0 OR ER.Mark_Deleted IS NULL)
		and (EH.Mark_Deleted=0 OR EH.Mark_Deleted IS NULL)
		and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)	
end
go

----------------
drop procedure SA_CheckPatientFollowup
go

create procedure SA_CheckPatientFollowup	
	@ID int,
	@DoctorID int,
	@SelDate date,
	@PatientCode nvarchar(20),
	@NoDate bit
as
begin	
	if @ID=0 
	begin		
		if @NoDate=0
		begin
			if @DoctorID<>0
			begin
				if len(@PatientCode)>0
				begin
					SELECT TOP 1 
						R.TranID
						,dbo.SA_FormatPTCode(R.PatientCode) as PatientCodeF
						,R.PatientCode
						,R.DateTimeFU
						,LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName
						,P.Gender
						,FLOOR(DATEDIFF(DAY, P.DOB, GETDATE()) / 365.25) AS Age
						,P.DOB
						,C.ClinicEn
						,LTRIM(RTRIM(ISNULL(E.FirstName, '') +' ' + ISNULL(E.LastName, ''))) as Doctor
						,R.ClinicID
						,P.CellPhone
						,L.City
						,DoctorID
						,TypeFU
						,R.Note
						,IsConfirmed				
						,CONVERT(VARCHAR(12), DateTimeFU, 107) AS DateFU
						,REPLACE(REPLACE(LTRIM(RIGHT(CONVERT(varchar, DateTimeFU,100),7)),'AM',' AM'),'PM',' PM') as TimeFU
						,U.Name as UserCreate
						,R.DateCreate
						,M.Name as UserUpdate
						,R.DateUpdate
					FROM MJQEWarehouse.dbo.tblsa_patients_follow_up R
						inner join tblsa_patients P on R.PatientCode=P.PatientCode
						left join tblsa_employee_cardid EID on EID.ID=R.DoctorID
						inner join tblsa_employees E on EID.StaffNo=E.StaffNo
						left join tblsa_ms_clinic C on R.ClinicID=C.ClinicID
						left join tblsa_set_userlog U on U.UserNo=R.UserCreate
						left join tblsa_set_userlog M on M.UserNo=R.UserUpdate
						inner join tblsa_ms_location_provinces L on L.PID=P.CurCity
					Where R.PatientCode=@PatientCode				
						and R.DoctorID=@DoctorID
						and CAST(DateTimeFU as DATE)=CAST(@SelDate as DATE)						
						and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
						and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
						and (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
						and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
					order by DateTimeFU desc
				end
				else
				begin
					SELECT distinct
						R.TranID
						,dbo.SA_FormatPTCode(R.PatientCode) as PatientCode
						,R.DateTimeFU
						,LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName
						,P.Gender
						,FLOOR(DATEDIFF(DAY, P.DOB, GETDATE()) / 365.25) AS Age
						,P.DOB
						,LTRIM(RTRIM(ISNULL(E.FirstName, '') +' ' + ISNULL(E.LastName, ''))) as Doctor
						,T.AppointmentType as TypeFU
						,R.Note
						,C.ClinicEn
						,IsConfirmed
						,R.Mark_Deleted as Inactive
						,CONVERT(VARCHAR(12), DateTimeFU, 107) AS DateFU
						,REPLACE(REPLACE(LTRIM(RIGHT(CONVERT(varchar, DateTimeFU,100),7)),'AM',' AM'),'PM',' PM') as TimeFU
						,U.Name as UserCreate
						,R.DateCreate
						,M.Name as UserUpdate
						,R.DateUpdate
					FROM MJQEWarehouse.dbo.tblsa_patients_follow_up R
						inner join tblsa_patients P on R.PatientCode=P.PatientCode
						inner join tblsa_patients_appointment_types T on R.TypeFU=T.ID
						left join tblsa_employee_cardid EID on EID.ID=R.DoctorID
						inner join tblsa_employees E on EID.StaffNo=E.StaffNo
						left join tblsa_ms_clinic C on R.ClinicID=C.ClinicID
						left join tblsa_set_userlog U on U.UserNo=R.UserCreate
						left join tblsa_set_userlog M on M.UserNo=R.UserUpdate
					Where R.DoctorID=@DoctorID
						and CAST(DateTimeFU as DATE)=CAST(@SelDate as DATE)						
						and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
						and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
						and (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
						and (T.Mark_Deleted=0 OR T.Mark_Deleted IS NULL)
						and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
					order by R.DateTimeFU desc
				end
			end
			else
			begin
				if len(@PatientCode)>0
				begin
					SELECT TOP 1 
						R.TranID
						,dbo.SA_FormatPTCode(R.PatientCode) as PatientCodeF
						,R.PatientCode
						,R.DateTimeFU
						,LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName
						,P.Gender
						,FLOOR(DATEDIFF(DAY, P.DOB, GETDATE()) / 365.25) AS Age
						,P.DOB
						,C.ClinicEn
						,LTRIM(RTRIM(ISNULL(E.FirstName, '') +' ' + ISNULL(E.LastName, ''))) as Doctor
						,R.ClinicID
						,P.CellPhone
						,L.City
						,DoctorID
						,TypeFU
						,R.Note
						,IsConfirmed				
						,CONVERT(VARCHAR(12), DateTimeFU, 107) AS DateFU
						,REPLACE(REPLACE(LTRIM(RIGHT(CONVERT(varchar, DateTimeFU,100),7)),'AM',' AM'),'PM',' PM') as TimeFU
						,U.Name as UserCreate
						,R.DateCreate
						,M.Name as UserUpdate
						,R.DateUpdate
					FROM MJQEWarehouse.dbo.tblsa_patients_follow_up R
						inner join tblsa_patients P on R.PatientCode=P.PatientCode
						left join tblsa_employee_cardid EID on EID.ID=R.DoctorID
						inner join tblsa_employees E on EID.StaffNo=E.StaffNo
						left join tblsa_ms_clinic C on R.ClinicID=C.ClinicID
						left join tblsa_set_userlog U on U.UserNo=R.UserCreate
						left join tblsa_set_userlog M on M.UserNo=R.UserUpdate
						inner join tblsa_ms_location_provinces L on L.PID=P.CurCity
					Where R.PatientCode=@PatientCode				
						and CAST(DateTimeFU as DATE)=CAST(@SelDate as DATE)						
						and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
						and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
						and (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
						and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
					order by DateTimeFU desc
				end
				else
				begin
					SELECT distinct
						R.TranID
						,dbo.SA_FormatPTCode(R.PatientCode) as PatientCode
						,R.DateTimeFU
						,LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName
						,P.Gender
						,FLOOR(DATEDIFF(DAY, P.DOB, GETDATE()) / 365.25) AS Age
						,P.DOB
						,LTRIM(RTRIM(ISNULL(E.FirstName, '') +' ' + ISNULL(E.LastName, ''))) as Doctor
						,T.AppointmentType as TypeFU
						,R.Note
						,C.ClinicEn
						,IsConfirmed		
						,R.Mark_Deleted as Inactive
						,CONVERT(VARCHAR(12), DateTimeFU, 107) AS DateFU
						,REPLACE(REPLACE(LTRIM(RIGHT(CONVERT(varchar, DateTimeFU,100),7)),'AM',' AM'),'PM',' PM') as TimeFU
						,U.Name as UserCreate
						,R.DateCreate
						,M.Name as UserUpdate
						,R.DateUpdate
					FROM MJQEWarehouse.dbo.tblsa_patients_follow_up R
						inner join tblsa_patients P on R.PatientCode=P.PatientCode
						inner join tblsa_patients_appointment_types T on R.TypeFU=T.ID
						left join tblsa_employee_cardid EID on EID.ID=R.DoctorID
						inner join tblsa_employees E on EID.StaffNo=E.StaffNo
						left join tblsa_ms_clinic C on R.ClinicID=C.ClinicID
						left join tblsa_set_userlog U on U.UserNo=R.UserCreate
						left join tblsa_set_userlog M on M.UserNo=R.UserUpdate
					Where CAST(DateTimeFU as DATE)=CAST(@SelDate as DATE)						
						and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
						and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
						and (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
						and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
						and (T.Mark_Deleted=0 OR T.Mark_Deleted IS NULL)
					order by R.DateTimeFU desc
				end
			end
		end
		else
		begin
			if len(@PatientCode)<>0
			begin
				SELECT distinct
					R.TranID
					,dbo.SA_FormatPTCode(R.PatientCode) as PatientCode
					,R.DateTimeFU
					,LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName
					,P.Gender
					,FLOOR(DATEDIFF(DAY, P.DOB, GETDATE()) / 365.25) AS Age
					,P.DOB
					,LTRIM(RTRIM(ISNULL(E.FirstName, '') +' ' + ISNULL(E.LastName, ''))) as Doctor
					,T.AppointmentType as TypeFU
					,R.Note
					,C.ClinicEn
					,IsConfirmed	
					,R.Mark_Deleted as Inactive
					,CONVERT(VARCHAR(12), DateTimeFU, 107) AS DateFU
					,REPLACE(REPLACE(LTRIM(RIGHT(CONVERT(varchar, DateTimeFU,100),7)),'AM',' AM'),'PM',' PM') as TimeFU
					,U.Name as UserCreate
					,R.DateCreate
					,M.Name as UserUpdate
					,R.DateUpdate
				FROM MJQEWarehouse.dbo.tblsa_patients_follow_up R
					inner join tblsa_patients P on R.PatientCode=P.PatientCode
					inner join tblsa_patients_appointment_types T on R.TypeFU=T.ID
					left join tblsa_employee_cardid EID on EID.ID=R.DoctorID
					inner join tblsa_employees E on EID.StaffNo=E.StaffNo
					left join tblsa_ms_clinic C on R.ClinicID=C.ClinicID
					left join tblsa_set_userlog U on U.UserNo=R.UserCreate
					left join tblsa_set_userlog M on M.UserNo=R.UserUpdate
				Where R.PatientCode=@PatientCode					
					and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
					and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
					and (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
					and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
					and (T.Mark_Deleted=0 OR T.Mark_Deleted IS NULL)
				order by R.DateTimeFU desc
			end
			else
			begin
				SELECT distinct
					R.TranID
					,dbo.SA_FormatPTCode(R.PatientCode) as PatientCode
					,R.DateTimeFU
					,LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName
					,P.Gender
					,FLOOR(DATEDIFF(DAY, P.DOB, GETDATE()) / 365.25) AS Age
					,P.DOB
					,LTRIM(RTRIM(ISNULL(E.FirstName, '') +' ' + ISNULL(E.LastName, ''))) as Doctor
					,T.AppointmentType as TypeFU
					,R.Note
					,C.ClinicEn
					,IsConfirmed	
					,R.Mark_Deleted as Inactive
					,CONVERT(VARCHAR(12), DateTimeFU, 107) AS DateFU
					,REPLACE(REPLACE(LTRIM(RIGHT(CONVERT(varchar, DateTimeFU,100),7)),'AM',' AM'),'PM',' PM') as TimeFU
					,U.Name as UserCreate
					,R.DateCreate
					,M.Name as UserUpdate
					,R.DateUpdate
				FROM MJQEWarehouse.dbo.tblsa_patients_follow_up R
					inner join tblsa_patients P on R.PatientCode=P.PatientCode
					inner join tblsa_patients_appointment_types T on R.TypeFU=T.ID
					left join tblsa_employee_cardid EID on EID.ID=R.DoctorID
					inner join tblsa_employees E on EID.StaffNo=E.StaffNo
					left join tblsa_ms_clinic C on R.ClinicID=C.ClinicID
					left join tblsa_set_userlog U on U.UserNo=R.UserCreate
					left join tblsa_set_userlog M on M.UserNo=R.UserUpdate
				Where (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
					and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
					and (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
					and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
					and (T.Mark_Deleted=0 OR T.Mark_Deleted IS NULL)
				order by R.DateTimeFU desc
			end
		end
	end	
	else
	begin
		SELECT TOP 1 
			R.TranID
			,dbo.SA_FormatPTCode(R.PatientCode) as PatientCodeF
			,R.PatientCode
			,R.DateTimeFU
			,LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName
			,P.Gender
			,FLOOR(DATEDIFF(DAY, P.DOB, GETDATE()) / 365.25) AS Age
			,P.DOB
			,C.ClinicEn
			,LTRIM(RTRIM(ISNULL(E.FirstName, '') +' ' + ISNULL(E.LastName, ''))) as Doctor
			,R.ClinicID
			,P.CellPhone
			,L.City
			,DoctorID
			,TypeFU
			,R.Note
			,IsConfirmed	
			,R.Mark_Deleted as Inactive
			,CONVERT(VARCHAR(12), DateTimeFU, 107) AS DateFU
			,REPLACE(REPLACE(LTRIM(RIGHT(CONVERT(varchar, DateTimeFU,100),7)),'AM',' AM'),'PM',' PM') as TimeFU
			,U.Name as UserCreate
			,R.DateCreate
			,M.Name as UserUpdate
			,R.DateUpdate
		FROM MJQEWarehouse.dbo.tblsa_patients_follow_up R
			inner join tblsa_patients P on R.PatientCode=P.PatientCode
			left join tblsa_employee_cardid EID on EID.ID=R.DoctorID
			inner join tblsa_employees E on EID.StaffNo=E.StaffNo
			left join tblsa_ms_clinic C on R.ClinicID=C.ClinicID
			left join tblsa_set_userlog U on U.UserNo=R.UserCreate
			left join tblsa_set_userlog M on M.UserNo=R.UserUpdate
			inner join tblsa_ms_location_provinces L on L.PID=P.CurCity
		Where R.TranID=@ID										
			and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
			and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
			and (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
			and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
		order by DateTimeFU desc
	end
end
go

------------
drop procedure SA_SavePatientFollowUp
go

create procedure SA_SavePatientFollowUp 
	@ID int,
	@PatientCode nvarchar(15),
	@DateTimeFU datetime,
	@DoctorID int,
	@ClinicID int,
	@TypeFU int,
	@Note nvarchar(max),
	@IsConfirmed int,
	@User nvarchar(100),	
	@IsAdd int output,
	@PTCodePrint nvarchar(15) output,
	@Msg nvarchar(max) output
as 
begin 
	set @PTCodePrint=SUBSTRING(@PatientCode,1,2)+'-' +SUBSTRING(@PatientCode,3,3)+'-'+SUBSTRING(@PatientCode,6,4)
	declare @NumIn int=0
	declare @VisitStatus nvarchar(100)=''
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while some patient info is empty.'
		
	if(len(@PatientCode)>0 and @DoctorID>0 and @ClinicID>0)
	begin
		if not exists(select TranID from tblsa_patients_follow_up where CAST(DateTimeFU as DATETIME)=CAST(@DateTimeFU as DATETIME) and PatientCode=@PatientCode and TranID<>@ID and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
		begin
			if @ID=0
			begin
				insert into tblsa_patients_follow_up(PatientCode, DateTimeFU, DoctorID, ClinicID, TypeFU, Note, IsConfirmed, Mark_Deleted, UserCreate, DateCreate)
				select @PatientCode, @DateTimeFU, @DoctorID, @ClinicID, @TypeFU, LTRIM(RTRIM(@Note)), @IsConfirmed, 0, @User, CURRENT_TIMESTAMP
				set @IsAdd=2
				set @Msg= 'Patient, ' +@PTCodePrint +' has been scheduled to follow up on ' +CONVERT(NVARCHAR, @DateTimeFU, 100) +'.'
			end
			else if exists(select TranID from tblsa_patients_follow_up where TranID=@ID and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
			begin
				update tblsa_patients_follow_up set		
					PatientCode=@PatientCode,
					DateTimeFU=@DateTimeFU,
					ClinicID=@ClinicID,
					DoctorID=@DoctorID,
					TypeFU=@TypeFU,
					Note=LTRIM(RTRIM(@Note)),
					IsConfirmed=@IsConfirmed,					
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where TranID=@ID 
					and (Mark_Deleted=0 OR Mark_Deleted IS NULL) 				

				set @IsAdd=3
				set @Msg= 'Patient, ' +@PTCodePrint +' has been re-scheduled to follow up on ' +CONVERT(NVARCHAR, @DateTimeFU, 100) +'.'
			end
			else if exists(select TranID from tblsa_patients_follow_up where TranID=@ID)
			begin
				set @Msg = 'Cannot make update this patient has been removed or deactived from the system.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg= 'Patient, ' +@PTCodePrint +' already has follow up schedule on ' +CONVERT(NVARCHAR, @DateTimeFU, 100) +' on the system.'
		end
	end
	select @IsAdd, @PTCodePrint, @Msg
end
go

-----------------------------

drop procedure SA_DisablePatientFollowUp
go

create procedure SA_DisablePatientFollowUp
	@StrID nvarchar(max),	
	@Inactive bit,
	@IsPermanent bit,
	@User int,
	@IsUpdate int output,
	@Msg nvarchar(max) output
as
begin
	set @IsUpdate=0
	set @Msg='There is no selected patients to perform action.'
	DECLARE @TempStr nvarchar(max)=''

	DECLARE @TblTempID TABLE(ID int)
	INSERT INTO @TblTempID SELECT Name FROM dbo.SA_SplitString(@StrID, ',')

	DECLARE @TempID NVARCHAR(10)
	DECLARE DB_CURSOR CURSOR FOR SELECT ID from @TblTempID
	OPEN DB_CURSOR 
	
	FETCH NEXT FROM DB_CURSOR INTO @TempID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		if exists(select TranID from tblsa_patients_follow_up where TranID=@TempID)
		begin	
			if @IsPermanent=0
			begin
				update tblsa_patients_follow_up set				
					Mark_Deleted=@Inactive,
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where TranID=@TempID
				set @IsUpdate=1				
				set @TempStr=@TempStr +(select top 1 SUBSTRING(PatientCode,1,2)+'-' +SUBSTRING(PatientCode,3,3)+'-'+SUBSTRING(PatientCode,6,4) from tblsa_patients_follow_up where TranID=@TempID) +', ' 						
			end
			else
			begin
				delete from tblsa_patients_follow_up where TranID=@TempID
				set @IsUpdate=2
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
	if @IsUpdate=1
	begin
		if @Inactive=0
		begin
			set @Msg='Patient Code: ' + @TempStr + ' has been reset the follow up schedule.'	
		end
		else
		begin
			set @Msg='Patient Code: ' + @TempStr + ' has been cancelled the follow up schedule.'	
		end
	end
	else if @IsUpdate=2
	begin
		set @Msg='Patient Code: ' + @TempStr + ' has been removed permanently.'	
	end
	
	select @IsUpdate, @Msg	
end
go

----------
drop procedure SA_GetPatientAppointmentType
go

create procedure SA_GetPatientAppointmentType
	@ID int
as
begin
	if @ID=0
	begin
		select 
			ID,
			AppointmentType
		from tblsa_patients_appointment_types		
		where (Mark_Deleted=0 or Mark_Deleted is null)
		order by (CASE WHEN AppointmentType='Others' THEN 1 ELSE 0 END), AppointmentType		
	end
	else
	begin
		select top 1
			ID,
			AppointmentType
		from tblsa_patients_appointment_types			 
		where ID=@ID
		order by AppointmentType
	end
end
go


-----------------------
drop procedure SA_GetPatientWaitingForVitalSign
go

create procedure SA_GetPatientWaitingForVitalSign
	@VisitCode int,
	@ClinicID int,
	@SelDate datetime,
	@IsNoDate bit
as
begin
	if @VisitCode<>0
	begin
		SELECT distinct
			V.VisitCode
			,dbo.SA_FormatPTCode(P.PatientCode) as PatientCode						
			,LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName
			,Gender
			,DOB
			,FLOOR(DATEDIFF(DAY, P.DOB, GETDATE()) / 365.25) AS Age
			--,CONVERT(NVARCHAR, DateIn, 22) as DateCheckIn
			,DateIn as DateCheckIn
			,RTRIM(LTRIM(RIGHT(CONVERT(varchar, DateIn, 22),11))) as TimeIn
			,Substring(cast(convert(NVARCHAR, Datein, 100) AS NVARCHAR), 12, 8) AS TimeVisit
			,ClinicID
		FROM tblsa_patients P
			INNER JOIN tblsa_patients_visit V ON P.PatientCode=V.PatientCode
		WHERE V.VisitCode=@VisitCode
			AND (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
			AND (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL)
		ORDER BY DateCheckIn desc	
	end
	else
	begin
		if @IsNoDate=0
		begin
			if @ClinicID<>0
			begin
				SELECT distinct
					V.VisitCode
					,dbo.SA_FormatPTCode(P.PatientCode) as PatientCode						
					,LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName
					,Gender
					--,CONVERT(NVARCHAR, DateIn, 22) as DateCheckIn
					,DateIn as DateCheckIn
					,RTRIM(LTRIM(RIGHT(CONVERT(varchar, DateIn, 22),11))) as TimeIn
					,Substring(cast(convert(NVARCHAR, Datein, 100) AS NVARCHAR), 12, 8) AS TimeVisit
				FROM tblsa_patients P
					INNER JOIN tblsa_patients_visit V ON P.PatientCode=V.PatientCode
				WHERE V.VisitCode NOT IN (SELECT VisitCode FROM tblsa_patients_vitalsign WHERE (Mark_Deleted=0 OR Mark_Deleted IS NULL)) 
					AND CAST(DateIn AS DATE)=CAST(GETDATE() AS DATE)
					and V.ClinicID=@ClinicID
					and DateOut IS NULL 
					AND (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
					AND (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL)
				ORDER BY DateCheckIn desc		
			end
			else
			begin
				SELECT distinct
					V.VisitCode
					,dbo.SA_FormatPTCode(P.PatientCode) as PatientCode						
					,LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName 
					,Gender
					--,CONVERT(NVARCHAR, DateIn, 22) as DateCheckIn
					,DateIn as DateCheckIn
					,RTRIM(LTRIM(RIGHT(CONVERT(varchar, DateIn, 22),11))) as TimeIn
					,Substring(cast(convert(NVARCHAR, Datein, 100) AS NVARCHAR), 12, 8) AS TimeVisit
				FROM tblsa_patients P
					INNER JOIN tblsa_patients_visit V ON P.PatientCode=V.PatientCode
				WHERE V.VisitCode NOT IN (SELECT VisitCode FROM tblsa_patients_vitalsign WHERE (Mark_Deleted=0 OR Mark_Deleted IS NULL)) 
					AND CAST(DateIn AS DATE)=CAST(GETDATE() AS DATE)			
					and DateOut IS NULL 
					AND (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
					AND (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL)
				ORDER BY DateCheckIn desc		
			end
		end
		else
		begin
			if @ClinicID<>0
			begin				
				SELECT distinct
					V.VisitCode
					,dbo.SA_FormatPTCode(P.PatientCode) as PatientCode						
					,LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName
					,Gender
					--,CONVERT(NVARCHAR, DateIn, 22) as DateCheckIn
					,DateIn as DateCheckIn
					,RTRIM(LTRIM(RIGHT(CONVERT(varchar, DateIn, 22),11))) as TimeIn
					,Substring(cast(convert(NVARCHAR, Datein, 100) AS NVARCHAR), 12, 8) AS TimeVisit
				FROM tblsa_patients P
					INNER JOIN tblsa_patients_visit V ON P.PatientCode=V.PatientCode
				WHERE V.VisitCode NOT IN (SELECT VisitCode FROM tblsa_patients_vitalsign WHERE (Mark_Deleted=0 OR Mark_Deleted IS NULL)) 
					--AND CAST(DateIn AS DATE)=CAST(GETDATE() AS DATE)
					and V.ClinicID=@ClinicID
					and DateOut IS NULL 
					AND (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
					AND (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL)
				ORDER BY DateCheckIn desc		
			end
			else
			begin
				SELECT distinct
					V.VisitCode
					,dbo.SA_FormatPTCode(P.PatientCode) as PatientCode						
					,LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName 
					,Gender
					--,CONVERT(NVARCHAR, DateIn, 22) as DateCheckIn
					,DateIn as DateCheckIn
					,RTRIM(LTRIM(RIGHT(CONVERT(varchar, DateIn, 22),11))) as TimeIn
					,Substring(cast(convert(NVARCHAR, Datein, 100) AS NVARCHAR), 12, 8) AS TimeVisit
				FROM tblsa_patients P
					INNER JOIN tblsa_patients_visit V ON P.PatientCode=V.PatientCode
				WHERE V.VisitCode NOT IN (SELECT VisitCode FROM tblsa_patients_vitalsign WHERE (Mark_Deleted=0 OR Mark_Deleted IS NULL)) 
					--AND CAST(DateIn AS DATE)=CAST(GETDATE() AS DATE)			
					and DateOut IS NULL 
					AND (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
					AND (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL)
				ORDER BY DateCheckIn desc		
			end
		end
	end
end
go


------20200123
drop procedure SA_SavePatientVisitSign
go

create procedure SA_SavePatientVisitSign 
	@VitalCode int,
	@VisitCode int,
	@PatientCode nvarchar(15),
	@Weight float,
	@Height float,
	@Temperature float,
	@BPM nvarchar(100),
	@bpLeft float,
	@bpRight float,
	@Pulse float,
	@Respiration float,
	@SaO2 float,
	@DateVitalSign datetime,
	@ChiefComplaint nvarchar(max),
	@User nvarchar(100),	
	@IsAdd int output,
	@PTCodePrint nvarchar(15) output,
	@Msg nvarchar(max) output
as 
begin 
	set @PTCodePrint=@PatientCode
	set @PatientCode=REPLACE(@PatientCode, '-', '')
	--set @PTCodePrint=SUBSTRING(@PatientCode,1,2)+'-' +SUBSTRING(@PatientCode,3,3)+'-'+SUBSTRING(@PatientCode,6,4)
	declare @NumIn int=0
	declare @VisitStatus nvarchar(100)=''
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while some patient info is empty.'
		
	if(len(@PatientCode)>0 and @VisitCode>0)
	begin
		--if not exists(select VitalCode from tblsa_patients_vitalsign where PatientCode=@PatientCode and VisitCode=@VisitCode and VitalCode<>@VitalCode and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
		if not exists(select VitalCode from tblsa_patients_vitalsign where PatientCode=@PatientCode and VisitCode=@VisitCode and VitalCode<>@VitalCode)
		begin
			if @VitalCode=0
			begin
				insert into tblsa_patients_vitalsign(VisitCode, PatientCode, Weight, Height, Temperature, BPM, bpLeft, bpRight, Pulse, Respiration, SaO2, DateVitalSign, ChiefComplaint, Mark_Deleted, UserCreate, DateCreate)
				select @VisitCode, LTRIM(RTRIM(@PatientCode)), @Weight, @Height, @Temperature, LTRIM(RTRIM(@BPM)), @bpLeft, @bpRight, @Pulse, @Respiration, @SaO2, @DateVitalSign, LTRIM(RTRIM(@ChiefComplaint)), 0, @User, CURRENT_TIMESTAMP
				set @IsAdd=2
				set @Msg= 'Patient, ' +@PTCodePrint +' is set the vital sign on ' +CONVERT(NVARCHAR, @DateVitalSign, 22) +'.'
			end
			else if exists(select VisitCode from tblsa_patients_vitalsign where VitalCode=@VitalCode and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
			begin
				update tblsa_patients_vitalsign set		
					VisitCode=@VisitCode,
					PatientCode=LTRIM(RTRIM(@PatientCode)),
					Weight=@Weight,
					Height=@Height,
					Temperature=@Temperature,
					BPM=LTRIM(RTRIM(@BPM)),
					bpLeft=@bpLeft,
					bpRight=@bpRight,
					Pulse=@Pulse,
					Respiration=@Respiration,
					SaO2=@SaO2,
					DateVitalSign=@DateVitalSign,
					ChiefComplaint=LTRIM(RTRIM(@ChiefComplaint)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where VitalCode=@VitalCode 
					and (Mark_Deleted=0 OR Mark_Deleted IS NULL) 

				set @IsAdd=3
				set @Msg= 'Patient, ' +@PTCodePrint +' is updated the vital sign on ' +CONVERT(NVARCHAR, @DateVitalSign, 22) +'.'
			end
			else if exists(select VisitCode from tblsa_patients_vitalsign where VitalCode=@VitalCode)
			begin
				set @Msg = 'Cannot make update this patient has been removed or deactived from the system.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg= 'This patient, ' +@PTCodePrint +' already exists set the vital sign on the system.'
		end
	end
	
	select @IsAdd, @PTCodePrint, @Msg
end
go

------------------
drop procedure SA_GetPatientVitalSignForView 
go

create procedure SA_GetPatientVitalSignForView
	@VitalCode int,
	@VisitCode int,
	@PatientCode nvarchar(20)	
as
begin
	if @VitalCode<>0
	begin
		SELECT distinct			
			V.VisitCode
			,dbo.SA_FormatPTCode(V.PatientCode) as PatientCode						
			,LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName
			,Gender
			,DOB
			,FLOOR(DATEDIFF(DAY, P.DOB, GETDATE()) / 365.25) AS Age
			,CONVERT(NVARCHAR, (CASE WHEN DateVitalSign IS NULL THEN DateIn ELSE DateVitalSign END), 22) as DateVitalSign
			,RTRIM(LTRIM(RIGHT(CONVERT(varchar, (CASE WHEN DateVitalSign IS NULL THEN DateIn ELSE DateVitalSign END), 22),11))) as TimeIn
			,ClinicEn
			,Height
			,Weight
			,Temperature
			,BPM
			,bpLeft
			,bpRight
			,Pulse
			,Respiration
			,SaO2
			,ChiefComplaint
			,VitalCode
			,S.Mark_Deleted as Inactive
			,U.Name as UserCreate
			,S.DateCreate
			,M.Name as UserUpdate
			,S.DateUpdate
		FROM tblsa_patients_visit V
			left JOIN tblsa_patients_vitalsign S ON V.VisitCode=S.VisitCode
			inner join tblsa_patients P on V.PatientCode=P.PatientCode	
			inner join tblsa_ms_clinic C on C.ClinicID=V.ClinicID
			left join tblsa_set_userlog U on U.UserNo=S.UserCreate
			left join tblsa_set_userlog M on M.UserNo=S.UserUpdate
		WHERE S.VitalCode=@VitalCode
			AND (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL)
			AND (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
			--AND (S.Mark_Deleted=0 OR S.Mark_Deleted IS NULL)
		ORDER BY DateVitalSign desc	
	end
	else if @VisitCode<>0
	begin
		SELECT distinct		
			V.VisitCode
			,dbo.SA_FormatPTCode(V.PatientCode) as PatientCode						
			,LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName
			,Gender
			,DOB
			,FLOOR(DATEDIFF(DAY, P.DOB, GETDATE()) / 365.25) AS Age
			,CONVERT(NVARCHAR, (CASE WHEN DateVitalSign IS NULL THEN DateIn ELSE DateVitalSign END), 22) as DateVitalSign
			,RTRIM(LTRIM(RIGHT(CONVERT(varchar, (CASE WHEN DateVitalSign IS NULL THEN DateIn ELSE DateVitalSign END), 22),11))) as TimeIn
			,ClinicEn
			,Height
			,Weight
			,Temperature
			,BPM
			,bpLeft
			,bpRight
			,Pulse
			,Respiration
			,SaO2
			,ChiefComplaint
			,VitalCode
			,S.Mark_Deleted as Inactive
			,U.Name as UserCreate
			,S.DateCreate
			,M.Name as UserUpdate
			,S.DateUpdate
		FROM tblsa_patients_visit V
			left JOIN tblsa_patients_vitalsign S ON V.VisitCode=S.VisitCode
			inner join tblsa_patients P on V.PatientCode=P.PatientCode	
			inner join tblsa_ms_clinic C on C.ClinicID=V.ClinicID
			left join tblsa_set_userlog U on U.UserNo=S.UserCreate
			left join tblsa_set_userlog M on M.UserNo=S.UserUpdate
		WHERE V.VisitCode=@VisitCode
			AND (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL)
			AND (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
			--AND (S.Mark_Deleted=0 OR S.Mark_Deleted IS NULL)
		ORDER BY DateVitalSign desc	
	end
	else if len(@PatientCode)<>0
	begin
		SELECT distinct		
			V.VisitCode
			,dbo.SA_FormatPTCode(V.PatientCode) as PatientCode						
			,LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName
			,Gender
			,DOB
			,FLOOR(DATEDIFF(DAY, P.DOB, GETDATE()) / 365.25) AS Age
			,CONVERT(NVARCHAR, (CASE WHEN DateVitalSign IS NULL THEN DateIn ELSE DateVitalSign END), 22) as DateVitalSign
			,RTRIM(LTRIM(RIGHT(CONVERT(varchar, (CASE WHEN DateVitalSign IS NULL THEN DateIn ELSE DateVitalSign END), 22),11))) as TimeIn
			,ClinicEn
			,Height
			,Weight
			,Temperature
			,BPM
			,bpLeft
			,bpRight
			,Pulse
			,Respiration
			,SaO2
			,ChiefComplaint
			,VitalCode
			,S.Mark_Deleted as Inactive
			,U.Name as UserCreate
			,S.DateCreate
			,M.Name as UserUpdate
			,S.DateUpdate
		FROM tblsa_patients_visit V
			left JOIN tblsa_patients_vitalsign S ON V.VisitCode=S.VisitCode
			inner join tblsa_patients P on V.PatientCode=P.PatientCode	
			inner join tblsa_ms_clinic C on C.ClinicID=V.ClinicID
			left join tblsa_set_userlog U on U.UserNo=S.UserCreate
			left join tblsa_set_userlog M on M.UserNo=S.UserUpdate
		WHERE S.PatientCode=@PatientCode
			AND (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL)
			AND (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
			--AND (S.Mark_Deleted=0 OR S.Mark_Deleted IS NULL)
		ORDER BY DateVitalSign desc	
	end
	else
	begin
		SELECT distinct			
			V.VisitCode
			,dbo.SA_FormatPTCode(V.PatientCode) as PatientCode						
			,LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName
			,Gender
			,DOB
			,FLOOR(DATEDIFF(DAY, P.DOB, GETDATE()) / 365.25) AS Age
			,CONVERT(NVARCHAR, (CASE WHEN DateVitalSign IS NULL THEN DateIn ELSE DateVitalSign END), 22) as DateVitalSign
			,RTRIM(LTRIM(RIGHT(CONVERT(varchar, (CASE WHEN DateVitalSign IS NULL THEN DateIn ELSE DateVitalSign END), 22),11))) as TimeIn
			,ClinicEn
			,Height
			,Weight
			,Temperature
			,BPM
			,bpLeft
			,bpRight
			,Pulse
			,Respiration
			,SaO2
			,ChiefComplaint
			,VitalCode
			,S.Mark_Deleted as Inactive
			,U.Name as UserCreate
			,S.DateCreate
			,M.Name as UserUpdate
			,S.DateUpdate
		FROM tblsa_patients_visit V
			left JOIN tblsa_patients_vitalsign S ON V.VisitCode=S.VisitCode
			inner join tblsa_patients P on V.PatientCode=P.PatientCode	
			inner join tblsa_ms_clinic C on C.ClinicID=V.ClinicID
			left join tblsa_set_userlog U on U.UserNo=S.UserCreate
			left join tblsa_set_userlog M on M.UserNo=S.UserUpdate
		WHERE (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL)
			AND (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
			--AND (S.Mark_Deleted=0 OR S.Mark_Deleted IS NULL)
		ORDER BY DateVitalSign desc	
	end
end
go


------------------
drop procedure SA_GetPatientVitalSign
go

create procedure SA_GetPatientVitalSign
	@VitalCode int,
	@PatientCode nvarchar(20)	
as
begin
	if @VitalCode<>0
	begin
		SELECT distinct		
			V.VisitCode
			,dbo.SA_FormatPTCode(P.PatientCode) as PatientCode						
			,LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName
			,Gender
			,DOB
			,FLOOR(DATEDIFF(DAY, P.DOB, GETDATE()) / 365.25) AS Age
			--,CONVERT(NVARCHAR, DateVitalSign, 22) as DateVitalSign
			,DateVitalSign
			,RTRIM(LTRIM(RIGHT(CONVERT(varchar, DateVitalSign, 22),11))) as TimeIn
			,ClinicEn
			,Height
			,Weight
			,Temperature
			,BPM
			,bpLeft
			,bpRight
			,Pulse
			,Respiration
			,SaO2
			,ChiefComplaint
			,VitalCode
			,S.Mark_Deleted as Inactive
			,U.Name as UserCreate
			,S.DateCreate
			,M.Name as UserUpdate
			,S.DateUpdate
		FROM tblsa_patients_vitalsign S
			INNER JOIN tblsa_patients_visit V ON V.VisitCode=S.VisitCode
			inner join tblsa_patients P on S.PatientCode=P.PatientCode	
			inner join tblsa_ms_clinic C on C.ClinicID=V.ClinicID
			left join tblsa_set_userlog U on U.UserNo=S.UserCreate
			left join tblsa_set_userlog M on M.UserNo=S.UserUpdate
		WHERE S.VitalCode=@VitalCode
			AND (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL)
			AND (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
			--AND (S.Mark_Deleted=0 OR S.Mark_Deleted IS NULL)
		ORDER BY DateVitalSign desc	
	end
	else if len(@PatientCode)<>0
	begin
		SELECT distinct			
			V.VisitCode
			,dbo.SA_FormatPTCode(P.PatientCode) as PatientCode						
			,LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName
			,Gender
			,DOB
			,FLOOR(DATEDIFF(DAY, P.DOB, GETDATE()) / 365.25) AS Age
			--,CONVERT(NVARCHAR, DateVitalSign, 22) as DateVitalSign
			,DateVitalSign
			,RTRIM(LTRIM(RIGHT(CONVERT(varchar, DateVitalSign, 22),11))) as TimeIn
			,ClinicEn
			,Height
			,Weight
			,Temperature
			,BPM
			,bpLeft
			,bpRight
			,Pulse
			,Respiration
			,SaO2
			,ChiefComplaint
			,VitalCode
			,S.Mark_Deleted as Inactive
			,U.Name as UserCreate
			,S.DateCreate
			,M.Name as UserUpdate
			,S.DateUpdate
		FROM tblsa_patients_vitalsign S
			INNER JOIN tblsa_patients_visit V ON V.VisitCode=S.VisitCode
			inner join tblsa_patients P on S.PatientCode=P.PatientCode	
			inner join tblsa_ms_clinic C on C.ClinicID=V.ClinicID
			left join tblsa_set_userlog U on U.UserNo=S.UserCreate
			left join tblsa_set_userlog M on M.UserNo=S.UserUpdate
		WHERE S.PatientCode=@PatientCode
			AND (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL)
			AND (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
			--AND (S.Mark_Deleted=0 OR S.Mark_Deleted IS NULL)
		ORDER BY DateVitalSign desc	
	end
	else
	begin
		SELECT distinct			
			V.VisitCode
			,dbo.SA_FormatPTCode(P.PatientCode) as PatientCode						
			,LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName
			,Gender
			,DOB
			,FLOOR(DATEDIFF(DAY, P.DOB, GETDATE()) / 365.25) AS Age
			--,CONVERT(NVARCHAR, DateVitalSign, 22) as DateVitalSign
			,DateVitalSign
			,RTRIM(LTRIM(RIGHT(CONVERT(varchar, DateVitalSign, 22),11))) as TimeIn
			,ClinicEn
			,Height
			,Weight
			,Temperature
			,BPM
			,bpLeft
			,bpRight
			,Pulse
			,Respiration
			,SaO2
			,ChiefComplaint
			,VitalCode
			,S.Mark_Deleted as Inactive
			,U.Name as UserCreate
			,S.DateCreate
			,M.Name as UserUpdate
			,S.DateUpdate
		FROM tblsa_patients_vitalsign S
			INNER JOIN tblsa_patients_visit V ON V.VisitCode=S.VisitCode
			inner join tblsa_patients P on S.PatientCode=P.PatientCode	
			inner join tblsa_ms_clinic C on C.ClinicID=V.ClinicID
			left join tblsa_set_userlog U on U.UserNo=S.UserCreate
			left join tblsa_set_userlog M on M.UserNo=S.UserUpdate
		WHERE (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL)
			AND (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
			--AND (S.Mark_Deleted=0 OR S.Mark_Deleted IS NULL)
		ORDER BY DateVitalSign desc	
	end
end
go

-----------
drop procedure SA_IsSelPatientCheckIn
go

create procedure SA_IsSelPatientCheckIn
	@VisitCode int,
	@PatientCode nvarchar(20)
as
begin
	if @VisitCode<>0
	begin
		select distinct
			ClinicEn
		from tblsa_patients_visit V
			inner join tblsa_ms_clinic C on V.ClinicID=C.ClinicID
		where VisitCode=@VisitCode
			and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
			and (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL)
		order by ClinicEn
	end
	else if len(@PatientCode)<>0
	begin
		select 
			ClinicEn
		from tblsa_patients_visit V
			inner join tblsa_ms_clinic C on V.ClinicID=C.ClinicID
		where DateIn IS NOT NULL 
			and DateOut IS NULL
			and PatientCode=@PatientCode
			and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
			and (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL)
		order by DateIn desc
	end
end
go

--------
drop procedure SA_DisablePatientVitalSign
go

create procedure SA_DisablePatientVitalSign
	@StrID nvarchar(max),	
	@Inactive bit,
	@IsPermanent bit,
	@User int,
	@IsUpdate int output,
	@Msg nvarchar(max) output
as
begin
	set @IsUpdate=0
	set @Msg='There is no selected patients to perform action.'
	DECLARE @TempStr nvarchar(max)=''

	DECLARE @TblTempID TABLE(ID int)
	INSERT INTO @TblTempID SELECT Name FROM dbo.SA_SplitString(@StrID, ',')

	DECLARE @TempID NVARCHAR(10)
	DECLARE DB_CURSOR CURSOR FOR SELECT ID from @TblTempID
	OPEN DB_CURSOR 
	
	FETCH NEXT FROM DB_CURSOR INTO @TempID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		if exists(select VitalCode from tblsa_patients_vitalsign where VitalCode=@TempID)
		begin	
			if @IsPermanent=0
			begin
				update tblsa_patients_vitalsign set				
					Mark_Deleted=@Inactive,
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where VitalCode=@TempID
				set @IsUpdate=1				
				set @TempStr=@TempStr +(select top 1 SUBSTRING(PatientCode,1,2)+'-' +SUBSTRING(PatientCode,3,3)+'-'+SUBSTRING(PatientCode,6,4) from tblsa_patients_vitalsign where VitalCode=@TempID) +', ' 						
			end
			else
			begin
				delete from tblsa_patients_vitalsign where VitalCode=@TempID
				set @IsUpdate=2
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
	if @IsUpdate=1
	begin
		if @Inactive=0
		begin
			set @Msg='Vital sign for patient: ' + @TempStr + ' has been restore.'	
		end
		else
		begin
			set @Msg='Vital sign for patient: ' + @TempStr + ' has been removed.'	
		end
	end
	else if @IsUpdate=2
	begin
		set @Msg='Vital sign for patient: ' + @TempStr + ' has been removed permanently.'	
	end
	
	select @IsUpdate, @Msg	
end
go


---20200125
drop procedure SA_GetPatientVisitList
go

create procedure SA_GetPatientVisitList
	@PatientCode nvarchar(20)
as
begin
	if len(@PatientCode)<>0
	begin
		select distinct
			dbo.SA_FormatPTCode(P.PatientCode) as PatientCode,
			LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName,
			P.Gender,
			FLOOR(DATEDIFF(DAY, P.[DOB], GETDATE()) / 365.25) AS Age,
			P.DOB,
			CONVERT(NVARCHAR, DateIn, 22) as DateIn,
			CONVERT(NVARCHAR, DateOut, 22) as DateOut,
			NumIn,
			ClinicEn,
			PTComplain,
			DRProgressNote,
			ReasonForVisit,
			V.IsCancelled,
			VisitCode,
			PTDiagnosis,
			VisitedDoctor,
			VisitStatus,
			TreatmentBy,
			TreatmentDate,
			LTRIM(RTRIM(ISNULL(E.FirstName, '') +' ' + ISNULL(E.LastName, ''))) as CheckInToDoctor,
			MembershipType,
			U.Name as UserCreate,
			V.DateCreate,
			M.Name as UserUpdate,
			V.DateUpdate
		from tblsa_patients P
			inner join tblsa_patients_visit V on P.PatientCode=V.PatientCode
			inner join tblsa_ms_clinic C on C.ClinicID=V.ClinicID
			left join tblsa_employee_cardid EID on EID.ID=V.CheckInToDoctor
			left join tblsa_employees E on EID.StaffNo=E.StaffNo
			left join tblsa_set_userlog U on U.UserNo=V.UserCreate
			left join tblsa_set_userlog M on M.UserNo=V.UserUpdate
		where P.PatientCode=@PatientCode
			and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL) 
			and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL) 					
			and (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL) 					
			and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL) 
		order by DateIn Desc
	end
	else
	begin
		select distinct
			dbo.SA_FormatPTCode(P.PatientCode) as PatientCode,
			LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName,
			P.Gender,
			FLOOR(DATEDIFF(DAY, P.[DOB], GETDATE()) / 365.25) AS Age,
			P.DOB,
			CONVERT(NVARCHAR, DateIn, 22) as DateIn,
			CONVERT(NVARCHAR, DateOut, 22) as DateOut,
			NumIn,
			ClinicEn,
			PTComplain,
			DRProgressNote,
			ReasonForVisit,
			V.IsCancelled,
			VisitCode,
			PTDiagnosis,
			VisitedDoctor,
			VisitStatus,
			TreatmentBy,
			TreatmentDate,
			LTRIM(RTRIM(ISNULL(E.FirstName, '') +' ' + ISNULL(E.LastName, ''))) as CheckInToDoctor,
			MembershipType,
			U.Name as UserCreate,
			V.DateCreate,
			M.Name as UserUpdate,
			V.DateUpdate
		from tblsa_patients P
			inner join tblsa_patients_visit V on P.PatientCode=V.PatientCode
			inner join tblsa_ms_clinic C on C.ClinicID=V.ClinicID
			left join tblsa_employee_cardid EID on EID.ID=V.CheckInToDoctor
			left join tblsa_employees E on EID.StaffNo=E.StaffNo
			left join tblsa_set_userlog U on U.UserNo=V.UserCreate
			left join tblsa_set_userlog M on M.UserNo=V.UserUpdate
		where (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL) 
			and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL) 					
			and (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL) 					
			and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL) 
		order by DateIn Desc
	end
end
go

----20200126
drop procedure SA_GetPatientWaitingforTreatment
go

create procedure SA_GetPatientWaitingforTreatment
	@PatientCode nvarchar(15),
	@Doctor int
as
begin
	if len(@PatientCode)<>0
	begin
		if @Doctor<>0
		begin
			select distinct
				dbo.SA_FormatPTCode(P.PatientCode) as PatientCode,
				LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName,
				P.Gender,
				FLOOR(DATEDIFF(DAY, P.[DOB], GETDATE()) / 365.25) AS Age,
				P.DOB,
				S.Weight,
				S.Height,
				S.Temperature,
				S.BPM,
				--S.bpLeft,
				--S.bpRight,
				S.Pulse,
				S.Respiration,
				S.SaO2,
				CONVERT(NVARCHAR, DateIn, 22) as DateIn,
				S.ChiefComplaint,
				M.Name as InputBy,
				C.ClinicEn,
				V.DateCreate,
				N.Name as UserUpdate,
				V.DateUpdate,
				V.VisitCode,
				S.VitalCode
			from tblsa_patients P
				inner join tblsa_patients_visit V on P.PatientCode=V.PatientCode
				left join tblsa_patients_vitalsign S on V.VisitCode=S.VisitCode
				inner join tblsa_ms_clinic C on C.ClinicID=V.ClinicID
				left join tblsa_employee_cardid EID on EID.ID=V.CheckInToDoctor
				left join tblsa_employees E on EID.StaffNo=E.StaffNo
				left join tblsa_set_userlog M on M.UserNo=V.UserCreate
				left join tblsa_set_userlog N on N.UserNo=V.UserUpdate
			where P.PatientCode=@PatientCode
				and V.CheckInToDoctor=@Doctor
				and VisitedDoctor IS NULL
				and (CAST(DateVitalSign AS DATE)=CAST(GETDATE() AS DATE)
				OR CAST(DateIn AS DATE)=CAST(GETDATE() AS DATE))
				and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
				and (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL)
				and (S.Mark_Deleted=0 OR S.Mark_Deleted IS NULL)
				and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
				and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
				and (M.Mark_Deleted=0 OR M.Mark_Deleted IS NULL)
			ORDER BY DateIn Desc
		end
		else
		begin
			select distinct
				dbo.SA_FormatPTCode(P.PatientCode) as PatientCode,
				LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName,
				P.Gender,
				FLOOR(DATEDIFF(DAY, P.[DOB], GETDATE()) / 365.25) AS Age,
				P.DOB,
				S.Weight,
				S.Height,
				S.Temperature,
				S.BPM,
				--S.bpLeft,
				--S.bpRight,
				S.Pulse,
				S.Respiration,
				S.SaO2,
				CONVERT(NVARCHAR, DateIn, 22) as DateIn,
				S.ChiefComplaint,
				M.Name as InputBy,
				C.ClinicEn,
				V.DateCreate,
				N.Name as UserUpdate,
				V.DateUpdate,
				V.VisitCode,
				S.VitalCode
			from tblsa_patients P
				inner join tblsa_patients_visit V on P.PatientCode=V.PatientCode
				left join tblsa_patients_vitalsign S on V.VisitCode=S.VisitCode
				inner join tblsa_ms_clinic C on C.ClinicID=V.ClinicID
				left join tblsa_employee_cardid EID on EID.ID=V.CheckInToDoctor
				left join tblsa_employees E on EID.StaffNo=E.StaffNo
				left join tblsa_set_userlog M on M.UserNo=V.UserCreate
				left join tblsa_set_userlog N on N.UserNo=V.UserUpdate
			where P.PatientCode=@PatientCode
				and VisitedDoctor IS NULL
				and (CAST(DateVitalSign AS DATE)=CAST(GETDATE() AS DATE)
				OR CAST(DateIn AS DATE)=CAST(GETDATE() AS DATE))
				and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
				and (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL)
				and (S.Mark_Deleted=0 OR S.Mark_Deleted IS NULL)
				and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
				and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
				and (M.Mark_Deleted=0 OR M.Mark_Deleted IS NULL)
			ORDER BY DateIn Desc
		end
	end
	else
	begin
		if @Doctor<>0
		begin
			select distinct
				dbo.SA_FormatPTCode(P.PatientCode) as PatientCode,
				LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName,
				P.Gender,
				FLOOR(DATEDIFF(DAY, P.[DOB], GETDATE()) / 365.25) AS Age,
				P.DOB,
				S.Weight,
				S.Height,
				S.Temperature,
				S.BPM,
				--S.bpLeft,
				--S.bpRight,
				S.Pulse,
				S.Respiration,
				S.SaO2,
				CONVERT(NVARCHAR, DateIn, 22) as DateIn,
				S.ChiefComplaint,
				M.Name as InputBy,
				C.ClinicEn,
				V.DateCreate,
				N.Name as UserUpdate,
				V.DateUpdate,
				V.VisitCode,
				S.VitalCode
			from tblsa_patients P
				inner join tblsa_patients_visit V on P.PatientCode=V.PatientCode
				left join tblsa_patients_vitalsign S on V.VisitCode=S.VisitCode
				inner join tblsa_ms_clinic C on C.ClinicID=V.ClinicID
				left join tblsa_employee_cardid EID on EID.ID=V.CheckInToDoctor
				left join tblsa_employees E on EID.StaffNo=E.StaffNo
				left join tblsa_set_userlog M on M.UserNo=V.UserCreate
				left join tblsa_set_userlog N on N.UserNo=V.UserUpdate
			where V.CheckInToDoctor=@Doctor
				and VisitedDoctor IS NULL
				and (CAST(DateVitalSign AS DATE)=CAST(GETDATE() AS DATE)
				OR CAST(DateIn AS DATE)=CAST(GETDATE() AS DATE))
				and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
				and (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL)
				and (S.Mark_Deleted=0 OR S.Mark_Deleted IS NULL)
				and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
				and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
				and (M.Mark_Deleted=0 OR M.Mark_Deleted IS NULL)
			ORDER BY DateIn Desc
		end
		else
		begin
			select distinct
				dbo.SA_FormatPTCode(P.PatientCode) as PatientCode,
				LTRIM(RTRIM(ISNULL(P.FirstName, '') +' ' + ISNULL(P.LastName, ''))) as PatientName,
				P.Gender,
				FLOOR(DATEDIFF(DAY, P.[DOB], GETDATE()) / 365.25) AS Age,
				P.DOB,
				S.Weight,
				S.Height,
				S.Temperature,
				S.BPM,
				--S.bpLeft,
				--S.bpRight,
				S.Pulse,
				S.Respiration,
				S.SaO2,
				CONVERT(NVARCHAR, DateIn, 22) as DateIn,
				S.ChiefComplaint,
				M.Name as InputBy,
				C.ClinicEn,
				V.DateCreate,
				N.Name as UserUpdate,
				V.DateUpdate,
				V.VisitCode,
				S.VitalCode
			from tblsa_patients P
				inner join tblsa_patients_visit V on P.PatientCode=V.PatientCode
				left join tblsa_patients_vitalsign S on V.VisitCode=S.VisitCode
				inner join tblsa_ms_clinic C on C.ClinicID=V.ClinicID
				left join tblsa_employee_cardid EID on EID.ID=V.CheckInToDoctor
				left join tblsa_employees E on EID.StaffNo=E.StaffNo
				left join tblsa_set_userlog M on M.UserNo=V.UserCreate
				left join tblsa_set_userlog N on N.UserNo=V.UserUpdate
			where VisitedDoctor IS NULL
				and (CAST(DateVitalSign AS DATE)=CAST(GETDATE() AS DATE)
				OR CAST(DateIn AS DATE)=CAST(GETDATE() AS DATE))
				and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
				and (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL)
				and (S.Mark_Deleted=0 OR S.Mark_Deleted IS NULL)
				and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL)
				and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
				and (M.Mark_Deleted=0 OR M.Mark_Deleted IS NULL)
			ORDER BY DateIn Desc
		end
	end
end
go

---20200127
drop procedure SA_GetPatientTreatmentHistory
go

create procedure SA_GetPatientTreatmentHistory
	@PatientCode nvarchar(15),
	@VisitCode int
as
begin
	if len(@PatientCode)<>0
	begin
		select distinct
			dbo.SA_FormatPTCode(P.PatientCode) as PatientCode,
			CONVERT(NVARCHAR, DateIn, 22) as DateIn,
			CONVERT(NVARCHAR, DateOut, 22) as DateOut,
			NumIn,
			ClinicEn,
			PTComplain,
			DRProgressNote,
			ReasonForVisit,
			PTDiagnosis,
			VisitedDoctor,
			VisitStatus,
			TreatmentBy,
			TreatmentDate,
			LTRIM(RTRIM(ISNULL(E.FirstName, '') +' ' + ISNULL(E.LastName, ''))) as CheckInToDoctor,
			MembershipType,
			Height,
			Weight,
			V.ClinicID,
			V.VisitCode,
			S.VitalCode
		from tblsa_patients P
			inner join tblsa_patients_visit V on P.PatientCode=V.PatientCode
			inner join tblsa_patients_vitalsign S on V.VisitCode=S.VisitCode
			inner join tblsa_ms_clinic C on C.ClinicID=V.ClinicID
			left join tblsa_employee_cardid EID on EID.ID=V.CheckInToDoctor
			left join tblsa_employees E on EID.StaffNo=E.StaffNo
		where P.PatientCode=@PatientCode
			and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL) 
			and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL) 					
			and (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL) 					
			and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
			and (S.Mark_Deleted=0 OR S.Mark_Deleted IS NULL) 
		order by DateIn Desc
	end
	else if @VisitCode<>0
	begin
		select distinct
			dbo.SA_FormatPTCode(P.PatientCode) as PatientCode,
			CONVERT(NVARCHAR, DateIn, 22) as DateIn,
			CONVERT(NVARCHAR, DateOut, 22) as DateOut,
			NumIn,
			ClinicEn,
			PTComplain,
			DRProgressNote,
			ReasonForVisit,
			PTDiagnosis,
			VisitedDoctor,
			VisitStatus,
			TreatmentBy,
			TreatmentDate,
			LTRIM(RTRIM(ISNULL(E.FirstName, '') +' ' + ISNULL(E.LastName, ''))) as CheckInToDoctor,
			MembershipType,
			Height,
			Weight,
			V.ClinicID,
			V.VisitCode,
			S.VitalCode
		from tblsa_patients P
			inner join tblsa_patients_visit V on P.PatientCode=V.PatientCode
			inner join tblsa_patients_vitalsign S on V.VisitCode=S.VisitCode
			inner join tblsa_ms_clinic C on C.ClinicID=V.ClinicID
			left join tblsa_employee_cardid EID on EID.ID=V.CheckInToDoctor
			left join tblsa_employees E on EID.StaffNo=E.StaffNo
		where V.VisitCode=@VisitCode
			and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL) 
			and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL) 					
			and (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL) 					
			and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
			and (S.Mark_Deleted=0 OR S.Mark_Deleted IS NULL) 
		order by DateIn Desc
	end
	else
	begin
		select distinct
			dbo.SA_FormatPTCode(P.PatientCode) as PatientCode,
			CONVERT(NVARCHAR, DateIn, 22) as DateIn,
			CONVERT(NVARCHAR, DateOut, 22) as DateOut,
			NumIn,
			ClinicEn,
			PTComplain,
			DRProgressNote,
			ReasonForVisit,
			PTDiagnosis,
			VisitedDoctor,
			VisitStatus,
			TreatmentBy,
			TreatmentDate,
			LTRIM(RTRIM(ISNULL(E.FirstName, '') +' ' + ISNULL(E.LastName, ''))) as CheckInToDoctor,
			MembershipType,
			Height,
			Weight,
			V.ClinicID,
			V.VisitCode,
			S.VitalCode
		from tblsa_patients P
			inner join tblsa_patients_visit V on P.PatientCode=V.PatientCode
			inner join tblsa_patients_vitalsign S on V.VisitCode=S.VisitCode
			inner join tblsa_ms_clinic C on C.ClinicID=V.ClinicID
			left join tblsa_employee_cardid EID on EID.ID=V.CheckInToDoctor
			left join tblsa_employees E on EID.StaffNo=E.StaffNo
		where V.VisitCode=@VisitCode
			and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL) 
			and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL) 					
			and (V.Mark_Deleted=0 OR V.Mark_Deleted IS NULL) 					
			and (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
			and (S.Mark_Deleted=0 OR S.Mark_Deleted IS NULL) 
		order by DateIn Desc
	end
end
go


--20191230
--drop procedure SA_UpdatePatientVisit
--go

--create procedure SA_UpdatePatientVisit 
--	@VisitCode int,
--	@PatientCode nvarchar(15),
--	@VisitedDoctor int,
--	@ClinicID int,
--	@PTComplaint nvarchar(max),
--	@DRProgressNote nvarchar(max),
--	@User int,	
--	@IsAdd int output,
--	@PTCodePrint nvarchar(15) output,
--	@Msg nvarchar(max) output
--as 
--begin 
--	set @PTCodePrint=SUBSTRING(@PatientCode,1,2)+'-' +SUBSTRING(@PatientCode,3,3)+'-'+SUBSTRING(@PatientCode,6,4)
--	declare @NumIn int=0	
--	set @IsAdd = 0
--	set @Msg = 'Cannot performance this operation while some patient info is empty.'
		
--	if(len(@PatientCode)>0 and @VisitCode>0 and @VisitedDoctor>0 and Len(@DRProgressNote)<>0)
--	begin
--		if exists(select VisitCode from tblsa_patients_visit where PatientCode=@PatientCode and VisitCode=@VisitCode)
--		begin
--			update tblsa_patients_visit set		
				
--				ClinicID=@ClinicID,
--				VisitedDoctor=@VisitedDoctor,
--				PTComplain=LTRIM(RTRIM(@PTComplaint)),
--				DRProgressNote=LTRIM(RTRIM(@DRProgressNote)),
--				TreatmentBy=@User,
--				TreatmentDate=CURRENT_TIMESTAMP,
--				UserUpdate=@User,
--				DateUpdate=CURRENT_TIMESTAMP
--			where VisitCode=@VisitCode 
--				and (Mark_Deleted=0 OR Mark_Deleted IS NULL) 
--				and (IsCancelled=0 OR IsCancelled IS NULL)

--			set @IsAdd=1
--			set @Msg= (select top 1 'Patient, ' +@PTCodePrint +' has bee treatment at clinic: ' +ABB +' on ' +CONVERT(NVARCHAR, CURRENT_TIMESTAMP, 22) +'.' from tblsa_ms_clinic where ClinicID=@ClinicID and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
--		end
--		else
--		begin
--			set @Msg = 'Cannot make update due to the code is not found or has been removed.'
--		end
--	end
	
--	select @IsAdd, @PTCodePrint, @Msg
--end
--go

drop procedure SA_UpdatePatientVisit
go

create procedure SA_UpdatePatientVisit 
	@VisitCode int,
	@PatientCode nvarchar(15),
	@VisitedDoctor int,
	@ClinicID int,
	@PTComplaint nvarchar(max),
	@DRProgressNote nvarchar(max),
	@User int
as 
begin 
	update tblsa_patients_visit set		
		ClinicID=@ClinicID,
		VisitedDoctor=@VisitedDoctor,
		PTComplain=LTRIM(RTRIM(@PTComplaint)),
		DRProgressNote=LTRIM(RTRIM(@DRProgressNote)),
		TreatmentBy=@User,
		TreatmentDate=CURRENT_TIMESTAMP,
		UserUpdate=@User,
		DateUpdate=CURRENT_TIMESTAMP
	where VisitCode=@VisitCode and PatientCode=@PatientCode
		and (Mark_Deleted=0 OR Mark_Deleted IS NULL) 
		and (IsCancelled=0 OR IsCancelled IS NULL)
end
go

-------------
drop procedure SA_GetDiagnosisByDxCode
go

create procedure SA_GetDiagnosisByDxCode
	@DxCode nvarchar(100),
	@Flag bit
as
begin
	if @Flag<>0
	begin
		SELECT DiagnosisCode, DxEn, DxGroup, DxCode FROM tblsa_ms_diagnosis WHERE DxCode=@DxCode and (Mark_Deleted=0 OR Mark_Deleted IS NULL)
	end
	else
	begin
		SELECT DxCode FROM tblsa_ms_diagnosis WHERE (Mark_Deleted=0 OR Mark_Deleted IS NULL) ORDER BY DxCode
	end
end
go


--------------
drop procedure SA_GetDataForBMI
go

create procedure SA_GetDataForBMI
	@PatientCode nvarchar(15)
as
begin
	SELECT TOP 1 
		VitalCode,
		VisitCode,
		Weight,
		Height
	FROM tblsa_patients_vitalsign WHERE PatientCode=@PatientCode
		AND (Weight IS NOT NULL AND Height IS NOT NULL) 
	ORDER BY VitalCode DESC
end
go

---------------20200130
--DROP TYPE PatientDiagnosis
--go

--CREATE TYPE PatientDiagnosis AS TABLE(
--	ID int NULL,
--	DiagnosisCode int NULL,
--	DxCode nvarchar(20) NULL, 
--	Diagnosis nvarchar(200) NULL, 
--	DxGroup nvarchar(200) NULL, 
--	DxNote nvarchar(max) NULL, 
--	DxGroupID int NULL,
--	DxDateTime datetime
--)
--go

-----------------
DROP PROCEDURE SAC_BulkInsertDx
GO

CREATE PROC SAC_BulkInsertDx
	@DxInfo PatientDiagnosis READONLY,
	@VisitCode int,
	@PatientCode nvarchar(15),
	@VisitedDoctor int,
	@ClinicID int,
	@PTComplaint nvarchar(max),
	@DRProgressNote nvarchar(max),
	@User int
AS
BEGIN
	exec SA_UpdatePatientVisit @VisitCode, @PatientCode, @VisitedDoctor, @ClinicID, @PTComplaint, @DRProgressNote, @User
	
	--delete from tblsa_patients_diagnosis where PatientCode=@PatientCode and VisitCode=@VisitCode
	update tblsa_patients_diagnosis set Mark_Deleted=1 where PatientCode=@PatientCode and VisitCode=@VisitCode;
	WITH records AS (SELECT * FROM @DxInfo)
		MERGE tblsa_patients_diagnosis pd
	USING records rec ON rec.DiagnosisCode=pd.DiagnosisCode and pd.PatientCode=@PatientCode and pd.VisitCode=@VisitCode
	WHEN MATCHED 
		THEN UPDATE SET
			pd.PatientCode=LTRIM(RTRIM(@PatientCode)),
			pd.VisitCode=@VisitCode,
			pd.DiagnosisCode=rec.DiagnosisCode,
			pd.DxNote=LTRIM(RTRIM(rec.DxNote)),
			pd.DxTimeStamp=rec.DxDateTime,
			pd.Mark_Deleted=0,
			pd.UserUpdate=@User,
			pd.DateUpdate=CURRENT_TIMESTAMP
	WHEN NOT MATCHED
		THEN INSERT (PatientCode,
				VisitCode, 
				DiagnosisCode, 
				DxNote, 
				DxTimeStamp, 
				Mark_Deleted,
				UserCreate, 
				DateCreate)
			VALUES (LTRIM(RTRIM(@PatientCode)),
				@VisitCode,
				rec.DiagnosisCode,
				LTRIM(RTRIM(rec.DxNote)),
				rec.DxDateTime,
				0,
				@User,
				CURRENT_TIMESTAMP);
END
GO


---------------
--DROP PROCEDURE SAC_BulkRemoveOldDx
--go

--CREATE PROC SAC_BulkRemoveOldDx	
--	@VisitCode int,
--	@PatientCode nvarchar(15)
--AS
--begin
--	delete from tblsa_patients_diagnosis where PatientCode=@PatientCode and VisitCode=@VisitCode
--end
--go

--truncate table tblsa_patients_diagnosis
drop procedure SA_GetPatientDiagnosis
go

create procedure SA_GetPatientDiagnosis
	@PatientCode nvarchar(15),
	@VisitCode int
as
begin
	if len(@PatientCode)<>0
	begin
		if @VisitCode<>0 
		begin
			select distinct
				ID,
				PatientCode,
				VisitCode,
				pd.DiagnosisCode,
				DxCode,
				DxEn as Diagnosis,
				DxNote,
				DxTimeStamp,
				DxGroupEn,
				DxGroup as DxGroupID
			from tblsa_patients_diagnosis pd
				inner join tblsa_ms_diagnosis d on pd.DiagnosisCode=d.DiagnosisCode
				inner join tblsa_ms_diagnosis_groups g on d.DxGroup=g.Code
			where PatientCode=@PatientCode
				and pd.VisitCode=@VisitCode
				and (pd.Mark_Deleted=0 OR pd.Mark_Deleted IS NULL)
				and (d.Mark_Deleted=0 OR d.Mark_Deleted IS NULL)
				and (g.Mark_Deleted=0 OR g.Mark_Deleted IS NULL)
			order by DxGroup, DxCode
		end
		else
		begin
			select distinct
				ID,
				PatientCode,
				VisitCode,
				pd.DiagnosisCode,
				DxCode,
				DxEn as Diagnosis,
				DxNote,
				DxTimeStamp,
				DxGroupEn,
				DxGroup as DxGroupID
			from tblsa_patients_diagnosis pd
				inner join tblsa_ms_diagnosis d on pd.DiagnosisCode=d.DiagnosisCode
				inner join tblsa_ms_diagnosis_groups g on d.DxGroup=g.Code
			where PatientCode=@PatientCode				
				and (pd.Mark_Deleted=0 OR pd.Mark_Deleted IS NULL)
				and (d.Mark_Deleted=0 OR d.Mark_Deleted IS NULL)
				and (g.Mark_Deleted=0 OR g.Mark_Deleted IS NULL)
			order by DxGroup, DxCode
		end
	end
	else
	begin
		if @VisitCode<>0 
		begin
			select distinct
				ID,
				PatientCode,
				VisitCode,
				pd.DiagnosisCode,
				DxCode,
				DxEn as Diagnosis,
				DxNote,
				DxTimeStamp,
				DxGroupEn,
				DxGroup as DxGroupID
			from tblsa_patients_diagnosis pd
				inner join tblsa_ms_diagnosis d on pd.DiagnosisCode=d.DiagnosisCode
				inner join tblsa_ms_diagnosis_groups g on d.DxGroup=g.Code
			where pd.VisitCode=@VisitCode
				and (pd.Mark_Deleted=0 OR pd.Mark_Deleted IS NULL)
				and (d.Mark_Deleted=0 OR d.Mark_Deleted IS NULL)
				and (g.Mark_Deleted=0 OR g.Mark_Deleted IS NULL)
			order by DxGroup, DxCode
		end
		else
		begin
			select distinct
				ID,
				PatientCode,
				VisitCode,
				pd.DiagnosisCode,
				DxCode,
				DxEn as Diagnosis,
				DxNote,
				DxTimeStamp,
				DxGroupEn,
				DxGroup as DxGroupID
			from tblsa_patients_diagnosis pd
				inner join tblsa_ms_diagnosis d on pd.DiagnosisCode=d.DiagnosisCode
				inner join tblsa_ms_diagnosis_groups g on d.DxGroup=g.Code
			where (pd.Mark_Deleted=0 OR pd.Mark_Deleted IS NULL)
				and (d.Mark_Deleted=0 OR d.Mark_Deleted IS NULL)
				and (g.Mark_Deleted=0 OR g.Mark_Deleted IS NULL)
			order by DxGroup, DxCode
		end
	end
end
go