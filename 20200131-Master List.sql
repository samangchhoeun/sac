drop procedure SA_SaveCorporateClient
go

create procedure SA_SaveCorporateClient
	@ID int,	
	@Client nvarchar(max),
	@Des nvarchar(max),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@Client)>0)
	begin
		--if not exists(select ID from tblsa_cashier_corporate_clients where CorporateClient=@Client and ID<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		if not exists(select ID from tblsa_cashier_corporate_clients where CorporateClient=@Client and ID<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_cashier_corporate_clients(CorporateClient, Description, Mark_Deleted, UserCreate, DateCreate) 
				values(LTRIM(RTRIM(@Client)), LTRIM(RTRIM(@Des)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Corporate client: ' +@Client +' has been added successfully.'
			end
			else if exists(select ID from tblsa_cashier_corporate_clients where ID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_cashier_corporate_clients set				
					CorporateClient=LTRIM(RTRIM(@Client)),
					Description=LTRIM(RTRIM(@Des)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where ID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Corporate client: ' +@Client + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'Corporate client: ' +@Client  +' already exists in the system.'
		end
	end

	select @IsAdd, @Msg
end
go


---------20191121
drop procedure SA_DisabledClients
go

create procedure SA_DisabledClients
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

		if exists(select ID from tblsa_cashier_corporate_clients where ID=@TempID)
		begin	
			update tblsa_cashier_corporate_clients set 
					Mark_Deleted=@Inactive, 
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP				
				where ID=@TempID 
					
				set @IsAdd=1
				declare @UpdateData nvarchar(max)=(select top 1 CorporateClient from tblsa_cashier_corporate_clients H WHERE H.ID=@TempID)
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
		set @Msg = 'Corporate client: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		set @Msg='Corporate client: ' + @TempStr + ' have been removed.'
	end

	select @IsAdd, @Msg	
end
go

----------20191121
drop procedure SA_GetCorporateClientsByID
go

create procedure SA_GetCorporateClientsByID
	@ID int,
	@isList int
as
begin
	if @ID<>0
	begin
		select top 1			
			ID,
			CorporateClient,
			[Description],								
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_cashier_corporate_clients		
		where ID=@ID
	end
	else if @isList=1
	begin
		select distinct
			ID,
			CorporateClient		
		from tblsa_cashier_corporate_clients CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by CorporateClient
		
	end
	else if @isList=2
	begin
		select
			0 as ID, 			
			'*** All clients' as CorporateClient
		UNION
		select distinct
			ID,
			CorporateClient		
		from tblsa_cashier_corporate_clients CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by CorporateClient
	end
	else 
	begin
		select distinct
			ID
			,CorporateClient
			,Description
			,CC.Mark_Deleted as Inactive
			,U.Name as UserCreate
			,CC.DateCreate
			,V.Name as UserUpdate
			,CC.DateUpdate
		from tblsa_cashier_corporate_clients CC		
			LEFT JOIN tblsa_set_userlog U on U.UserNo=CC.UserCreate
			LEFT JOIN tblsa_set_userlog V on V.UserNo=CC.UserUpdate
		order by CC.Mark_Deleted, CorporateClient
	end
end
go


--drop procedure SA_GetCorporateClientsByID
--go

--create procedure SA_GetCorporateClientsByID
--	@ID int,
--	@Flag int
--as
--begin
--	if @Flag=0
--	begin
--		if @ID<>0
--		begin
--			select top 1			
--				ID,
--				CorporateClient,
--				[Description],								
--				Mark_Deleted,
--				UserCreate,
--				DateCreate,
--				UserUpdate,
--				DateUpdate
--			from tblsa_cashier_corporate_clients		
--			where ID=@ID
--		end
--		else
--		begin
--			select
--				ID
--				,CorporateClient
--				,[Description]			
--				,CC.Mark_Deleted as Inactive
--				,U.Name as UserCreate
--				,CC.DateCreate
--				,V.Name as UserUpdate
--				,CC.DateUpdate
--			from tblsa_cashier_corporate_clients CC		
--				LEFT JOIN tblsa_set_userlog U on U.UserNo=CC.UserCreate
--				LEFT JOIN tblsa_set_userlog V on V.UserNo=CC.UserUpdate
--			order by CorporateClient
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
--				Mark_Deleted,
--				UserCreate,
--				DateCreate,
--				UserUpdate,
--				DateUpdate
--			from tblsa_cashier_corporate_clients	
--			where ID=@ID
--		end
--		else
--		begin
--			select
--				ID,
--				CorporateClient		
--			from tblsa_cashier_corporate_clients CC				
--			where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
--			order by CorporateClient
--		end
--	end
--end
--go


-------------------
drop procedure SA_GetCorporateClientsBaseBalanceByID
go

create procedure SA_GetCorporateClientsBaseBalanceByID
	@ID int
as
begin
	if @ID=0
	begin
		SELECT distinct
			CorporateBalCode
			--,CorporateClientID
			,CorporateClient
			,BaseBalance
			,EffectiveDate
			,Note
			,IsExpired
			,BB.Mark_Deleted as Inactive
			,U.Name as UserCreate
			,BB.DateCreate
			,V.Name as UserUpdate
			,BB.DateUpdate
		FROM tblsa_cashier_corperate_clients_base_balance BB
			inner join tblsa_cashier_corporate_clients CC on BB.CorporateClientID=CC.ID
			LEFT JOIN tblsa_set_userlog U on U.UserNo=BB.UserCreate
			LEFT JOIN tblsa_set_userlog V on V.UserNo=BB.UserUpdate
		--where (BB.Mark_Deleted=0 OR BB.Mark_Deleted IS NULL)
		--	and (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		ORDER BY BB.Mark_Deleted, CorporateClient
	end
	else
	begin
		SELECT top 1
			CorporateBalCode
			,CorporateClientID
			,CorporateClient
			,BaseBalance
			,EffectiveDate
			,Note
			,IsExpired
			,BB.Mark_Deleted as Inactive
			,BB.UserCreate
			,BB.DateCreate
			,BB.UserUpdate
			,BB.DateUpdate
		FROM tblsa_cashier_corperate_clients_base_balance BB
			inner join tblsa_cashier_corporate_clients CC on BB.CorporateClientID=CC.ID
		where CorporateBalCode=@ID
	end
end
go

-----------20200113
drop procedure SA_SaveCorporateClientBaseBalance
go

create procedure SA_SaveCorporateClientBaseBalance
	@ID int,	
	@Client int,
	@BaseBalance float,
	@EffectiveDate date,
	@IsExpired bit,
	@Note nvarchar(max),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(@Client>0 and @BaseBalance>=0)
	begin
		--if not exists(select CorporateBalCode from tblsa_cashier_corperate_clients_base_balance where CorporateClientID=@Client and CorporateBalCode<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		if not exists(select CorporateBalCode from tblsa_cashier_corperate_clients_base_balance where CorporateClientID=@Client and CorporateBalCode<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_cashier_corperate_clients_base_balance(CorporateClientID, BaseBalance, EffectiveDate, IsExpired, Note, Mark_Deleted, UserCreate, DateCreate) 
				values(ISNULL(@Client, 0), ISNULL(@BaseBalance,0), @EffectiveDate, @IsExpired, LTRIM(RTRIM(@Note)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = (select 'Corporate client: ' +CorporateClient + ' has been set base balance to '+CONVERT(NVARCHAR(10), @BaseBalance)+'.'+CHAR(10)+CHAR(10)+'The change will be effective from ' +CONVERT(NVARCHAR, @EffectiveDate, 100) +'.' from tblsa_cashier_corporate_clients where ID=@Client and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
			end
			else if exists(select CorporateBalCode from tblsa_cashier_corperate_clients_base_balance where CorporateBalCode=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_cashier_corperate_clients_base_balance set				
					CorporateClientID=ISNULL(@Client, 0),
					BaseBalance=ISNULL(@BaseBalance,0),
					EffectiveDate=@EffectiveDate,
					IsExpired=@IsExpired,
					Note=LTRIM(RTRIM(@Note)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where CorporateBalCode=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = (select 'Corporate client: ' +CorporateClient + ' has been updated base balance to '+CONVERT(NVARCHAR(10), @BaseBalance)+'.'+CHAR(10)+CHAR(10)+'The change will be effective from ' +CONVERT(NVARCHAR, @EffectiveDate, 100) +'.' from tblsa_cashier_corporate_clients where ID=@Client and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg =  +@Client  
			set @Msg = (select 'Corporate client base balance: ' +CorporateClient +' already exists in the system.' from tblsa_cashier_corporate_clients where ID=@Client and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
		end
	end

	select @IsAdd, @Msg
end
go

---------20191121
drop procedure SA_RemoveClientBaseBalance
go

create procedure SA_RemoveClientBaseBalance
	@StrID nvarchar(max),
	@IsExpire bit,
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
		if exists(select CorporateBalCode from tblsa_cashier_corperate_clients_base_balance where CorporateBalCode=@TempID)
		begin			
			update tblsa_cashier_corperate_clients_base_balance set
				IsExpired=(CASE @FlagRemove WHEN 1 THEN IsExpired ELSE @IsExpire END),
				Mark_Deleted=(CASE @FlagRemove WHEN 1 THEN @IsRemove ELSE Mark_Deleted END),
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP
			where CorporateBalCode=@TempID
			set @IsUpdate=1				
			set @TempStr=@TempStr +(select top 1 CorporateClient +' (Base Balance='+CONVERT(NVARCHAR(10), BaseBalance)+') :: Effective date: '+CONVERT(NVARCHAR, EffectiveDate, 100)
									FROM tblsa_cashier_corperate_clients_base_balance BB
										inner join tblsa_cashier_corporate_clients CC on BB.CorporateClientID=CC.ID
									where CorporateBalCode=@TempID) +', '	
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
				set @Msg='Membership base balance: ' + @TempStr + ' has been restored.'	
			end
			else
			begin
				set @Msg='Membership base balance: ' + @TempStr + ' has been removed.'	
			end
		end
		else
		begin
			if @IsExpire=0
			begin
				set @Msg='Membership base balance: ' + @TempStr + ' has been reset the expiration.'	
			end
			else
			begin
				set @Msg='Membership base balance: ' + @TempStr + ' has been set the expiration.'	
			end
		end
	end
	
	select @IsUpdate, @Msg	
end
go

---------------
drop procedure SA_SaveDiagnosisGroup
go

create procedure SA_SaveDiagnosisGroup
	@ID int,	
	@DxGroupEn nvarchar(max),
	@DxGroupKn nvarchar(max),
	@Des nvarchar(max),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@DxGroupEn)>0)
	begin
		--if not exists(select Code from tblsa_ms_diagnosis_groups where DxGroupEn=@DxGroupEn and Code<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		if not exists(select Code from tblsa_ms_diagnosis_groups where DxGroupEn=@DxGroupEn and Code<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_ms_diagnosis_groups(DxGroupEn, DxGroupKh, Description, Mark_Deleted, UserCreate, DateCreate) 
				values(UPPER(LTRIM(RTRIM(@DxGroupEn))), LTRIM(RTRIM(@DxGroupKn)), LTRIM(RTRIM(@Des)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Diagnosis group: ' +@DxGroupEn +' has been added successfully.'
			end
			else if exists(select Code from tblsa_ms_diagnosis_groups where Code=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_ms_diagnosis_groups set				
					DxGroupEn=UPPER(LTRIM(RTRIM(@DxGroupEn))),
					DxGroupKh=LTRIM(RTRIM(@DxGroupKn)),
					Description=LTRIM(RTRIM(@Des)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where Code=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Diagnosis group: ' +@DxGroupEn + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'Diagnosis group: ' +@DxGroupEn  +' already exists in the system.'
		end
	end

	select @IsAdd, @Msg
end
go

--------------
drop procedure SA_GetDiagnosisGroupByID
go

create procedure SA_GetDiagnosisGroupByID
	@ID int,
	@isList int
as
begin
	if @ID<>0
	begin
		select top 1			
			Code,
			DxGroupEn,
			DxGroupKh,
			[Description],								
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_ms_diagnosis_groups		
		where Code=@ID
	end
	else if @isList=1
	begin
		select distinct
			Code,
			DxGroupEn		
		from tblsa_ms_diagnosis_groups CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by DxGroupEn
	end
	else if @isList=2
	begin
		select
			0 as Code, 			
			'*** All Dx group' as DxGroupEn
		UNION
		select distinct
			Code,
			DxGroupEn		
		from tblsa_ms_diagnosis_groups CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by DxGroupEn
	end
	else
	begin 
		select distinct
			Code,
			DxGroupEn,
			DxGroupKh,
			[Description],				
			CC.Mark_Deleted as Inactive,
			U.Name as UserCreate,
			CC.DateCreate,
			V.Name as UserUpdate,
			CC.DateUpdate
		from tblsa_ms_diagnosis_groups CC	
			LEFT join tblsa_set_userlog U on U.UserNo=CC.UserCreate
			LEFT join tblsa_set_userlog V on V.UserNo=CC.UserUpdate
		order by CC.Mark_Deleted, DxGroupEn
	end
end
go

------------
---------20191121
drop procedure SA_DisabledDiagnosisGroup
go

create procedure SA_DisabledDiagnosisGroup
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

		if exists(select Code from tblsa_ms_diagnosis_groups where Code=@TempID)
		begin	
			update tblsa_ms_diagnosis_groups set 
				Mark_Deleted=@Inactive, 
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP				
			where Code=@TempID 
					
			set @IsAdd=1
			declare @UpdateData nvarchar(max)=(select top 1 DxGroupEn from tblsa_ms_diagnosis_groups H WHERE H.Code=@TempID)
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
		set @Msg = 'Diagnosis group: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		set @Msg='Diagnosis group: ' + @TempStr + ' have been removed.'
	end

	select @IsAdd, @Msg	
end
go

----------
drop procedure SA_GetDiagnosisByID
go

create procedure SA_GetDiagnosisByID
	@ID int,
	@DxGroup int,
	@isList int
as
begin
	if @ID<>0
	begin
		select top 1			
			DiagnosisCode
			,DxCode
			,DxEn
			,DxKh
			,DxDescription
			,DxGroup
			,Mark_Deleted
			,UserCreate
			,DateCreate
			,UserUpdate
			,DateUpdate
		from tblsa_ms_diagnosis		
		where DiagnosisCode=@ID
	end
	else if @DxGroup=0 and @isList=1
	begin
		select distinct
			DiagnosisCode
			,[DxEn]
			,DxGroupEn
		from tblsa_ms_diagnosis CC			
			inner join tblsa_ms_diagnosis_groups G on CC.DxGroup=G.Code
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
			and (G.Mark_Deleted=0 OR G.Mark_Deleted IS NULL)
		order by DxGroupEn, DxEn 
	end
	else if @DxGroup=0 and @isList=2
	begin
		select
			0 as DiagnosisCode, 
			'*** All diagnosis' as DxEn,
			'*** All Dx group' as DxGroupEn
		UNION
		select distinct
			DiagnosisCode
			,DxEn
			,DxGroupEn
		from tblsa_ms_diagnosis CC			
			inner join tblsa_ms_diagnosis_groups G on CC.DxGroup=G.Code
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
			and (G.Mark_Deleted=0 OR G.Mark_Deleted IS NULL)
		order by DxGroupEn, DxEn 
	end
	else if @DxGroup<>0 and @isList=1
	begin
		select distinct
			DiagnosisCode
			,[DxEn]
			,DxGroupEn
		from tblsa_ms_diagnosis CC			
			inner join tblsa_ms_diagnosis_groups G on CC.DxGroup=G.Code
		where G.Code=@DxGroup
			and (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
			and (G.Mark_Deleted=0 OR G.Mark_Deleted IS NULL)
		order by DxGroupEn, DxEn 
	end
	else if @DxGroup<>0 and @isList=2
	begin
		select top 1
			9999 as DiagnosisCode, 
			'*** All diagnosis' as DxEn,
			DxGroupEn as DxGroupEn
		from tblsa_ms_diagnosis_groups 
		where Code=@DxGroup
			and (Mark_Deleted=0 OR Mark_Deleted IS NULL)
		UNION
		select distinct
			DiagnosisCode
			,DxEn
			,DxGroupEn
		from tblsa_ms_diagnosis CC			
			inner join tblsa_ms_diagnosis_groups G on CC.DxGroup=G.Code
		where Code=@DxGroup
			and (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
			and (G.Mark_Deleted=0 OR G.Mark_Deleted IS NULL)
		order by DxGroupEn, DxEn 
	end
	else if @DxGroup=0 and @isList=3
	begin
		select distinct
			DiagnosisCode
			,DxCode
			,DxEn
			,DxKh
			,DxDescription
			,DxGroupEn
			,CC.Mark_Deleted as Inactive
			,U.Name as UserCreate
			,CC.DateCreate
			,V.Name as UserUpdate
			,CC.DateUpdate
		from tblsa_ms_diagnosis CC			
			inner join tblsa_ms_diagnosis_groups G on CC.DxGroup=G.Code
			LEFT join tblsa_set_userlog U on U.UserNo=CC.UserCreate
			LEFT join tblsa_set_userlog V on V.UserNo=CC.UserUpdate
		where (G.Mark_Deleted=0 OR G.Mark_Deleted IS NULL)			
		order by CC.Mark_Deleted, DxGroupEn, DxEn
	end
	else
	begin
		select distinct
			DiagnosisCode
			,DxCode
			,DxEn
			,DxKh
			,DxDescription
			,DxGroupEn
			,CC.Mark_Deleted as Inactive
			,U.Name as UserCreate
			,CC.DateCreate
			,V.Name as UserUpdate
			,CC.DateUpdate
		from tblsa_ms_diagnosis CC			
			inner join tblsa_ms_diagnosis_groups G on CC.DxGroup=G.Code
			LEFT join tblsa_set_userlog U on U.UserNo=CC.UserCreate
			LEFT join tblsa_set_userlog V on V.UserNo=CC.UserUpdate
		where Code=@DxGroup
			and (G.Mark_Deleted=0 OR G.Mark_Deleted IS NULL)			
		order by CC.Mark_Deleted, DxGroupEn, DxEn
	end
end
go

-----------------
drop procedure SA_DisabledDiagnosis
go

create procedure SA_DisabledDiagnosis
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

		if exists(select DiagnosisCode from tblsa_ms_diagnosis where DiagnosisCode=@TempID)
		begin	
			update tblsa_ms_diagnosis set 
				Mark_Deleted=@Inactive, 
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP				
			where DiagnosisCode=@TempID 
					
			set @IsAdd=1
			declare @UpdateData nvarchar(max)=(select top 1 DxEn from tblsa_ms_diagnosis H WHERE H.DiagnosisCode=@TempID)
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
		set @Msg = 'Diagnosis: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		set @Msg='Diagnosis: ' + @TempStr + ' have been removed.'
	end

	select @IsAdd, @Msg	
end
go

--------------
drop procedure SA_SaveDiagnosis
go

create procedure SA_SaveDiagnosis
	@ID int,	
	@DxGroup int,
	@DxCode nvarchar(10),
	@DxEn nvarchar(max),
	@DxKh nvarchar(max),
	@Des nvarchar(max),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@DxEn)>0 and @DxGroup>0)
	begin
		--if not exists(select DiagnosisCode from tblsa_ms_diagnosis where DxEn=@DxEn and DxGroup=@DxGroup and DiagnosisCode<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		if not exists(select DiagnosisCode from tblsa_ms_diagnosis where DxEn=@DxEn and DxGroup=@DxGroup and DiagnosisCode<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_ms_diagnosis(DxCode, DxEn, DxKh, DxDescription, DxGroup, Mark_Deleted, UserCreate, DateCreate) 
				values(UPPER(LTRIM(RTRIM(@DxCode))), LTRIM(RTRIM(@DxEn)), LTRIM(RTRIM(@DxKh)), LTRIM(RTRIM(@Des)), @DxGroup, 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Diagnosis: ' +LTRIM(RTRIM(@DxEn)) +' has been added successfully.'
			end
			else if exists(select DiagnosisCode from tblsa_ms_diagnosis where DiagnosisCode=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_ms_diagnosis set				
					DxCode=UPPER(LTRIM(RTRIM(@DxCode))),
					DxEn=LTRIM(RTRIM(@DxEn)),
					DxKh=LTRIM(RTRIM(@DxKh)),
					DxDescription=LTRIM(RTRIM(@Des)),
					DxGroup=@DxGroup,
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where DiagnosisCode=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Diagnosis: ' +LTRIM(RTRIM(@DxEn)) + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'Diagnosis: ' +LTRIM(RTRIM(@DxEn))  +' already exists in the system.'
		end
	end

	select @IsAdd, @Msg
end
go


--drop procedure SA_GetCampusToListForAdmin
--go

--create procedure SA_GetCampusToListForAdmin
--	@Flag bit
--as 
--begin 
--	if @Flag=0
--	begin
--		select
--			CampusID,
--			ABBR,
--			CampusEn,
--			CampusKh,
--			Description,						
--			UserCreate,
--			DateCreate,
--			UserUpdate,
--			DateUpdate
--		from tblsa_ms_campuses
--		where (Mark_Deleted=0 or Mark_Deleted is null)			
--		order by CampusEn
--	end
--	else
--	begin
--		select
--			CampusID,
--			ABBR,
--			CampusEn,
--			CampusKh,
--			Description,			
--			Mark_Deleted as Inactive,
--			UserCreate,
--			DateCreate,
--			UserUpdate,
--			DateUpdate
--		from tblsa_ms_campuses
--		order by CampusEn
--	end
--end
--go

---------20191121
drop procedure SA_DisabledCampuses
go

create procedure SA_DisabledCampuses
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
									from tblsa_ms_campuses CL
										LEFT JOIN tblsa_employee_employment EH ON CL.CampusID = EH.CampusID
										left join tblsa_employee_cardid EID on EID.ID=EH.CardIDNo				
									where CL.CampusID=@TempID
										and (CL.Mark_Deleted=0 or CL.Mark_Deleted is null)				
										and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL))
		if exists(select CampusID from tblsa_ms_campuses where CampusID=@TempID)
		begin	
			if @Inactive=1 and @NumStaffs>0
			begin				
				declare @NonUpdateData nvarchar(max)=(select top 1 CampusEn from tblsa_ms_campuses H WHERE H.CampusID=@TempID)
				set @TempStrNotUpdate=@TempStrNotUpdate +  @NonUpdateData +', '
			end
			else
			begin
				update tblsa_ms_campuses set 
					Mark_Deleted=@Inactive, 
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP				
				where CampusID=@TempID 
					
				set @IsAdd=1
				declare @UpdateData nvarchar(max)=(select top 1 CampusEn from tblsa_ms_campuses H WHERE H.CampusID=@TempID)
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
		set @Msg = 'Campuses: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		declare @TempSMS nvarchar(max)=''
		if LEN(@TempStr)=0
		begin
			if LEN(@TempStrNotUpdate)>0
			begin
				set @Msg='Campuses: ' +@TempStrNotUpdate +' cannot remove because there are some staff in the campus.'
			end
		end
		else
		begin
			if LEN(@TempStrNotUpdate)>0
			begin
				set @Msg='Campuses: ' + @TempStr + ' have been removed. Campuses: ' +@TempStrNotUpdate +' cannot remove because there are some staff in the campus.'
			end
			else
			begin
				set @Msg='Campuses: ' + @TempStr + ' have been removed.'
			end
		end
	end

	select @IsAdd, @Msg	
end
go

------------
drop procedure SA_SaveCampuses
go

create procedure SA_SaveCampuses
	@ID int,	
	@ABBR nvarchar(10),
	@CampusEn nvarchar(max),
	@CampusKh nvarchar(max),
	@Description nvarchar(max),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@CampusEn)>0)
	begin
		--if not exists(select CampusID from tblsa_ms_campuses where ABBR=@ABBR and CampusID<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		if not exists(select CampusID from tblsa_ms_campuses where ABBR=@ABBR and CampusID<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_ms_campuses(ABBR, CampusEn, CampusKh, Description, Mark_Deleted, UserCreate, DateCreate) 
				values(LTRIM(RTRIM(UPPER(@ABBR))), LTRIM(RTRIM(@CampusEn)), LTRIM(RTRIM(@CampusKh)),LTRIM(RTRIM(@Description)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Campus name: ' +@CampusEn +' has been added successfully.'
			end
			else if exists(select CampusID from tblsa_ms_campuses where CampusID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_ms_campuses set	
					ABBR=LTRIM(RTRIM(UPPER(@ABBR))),
					CampusEn=LTRIM(RTRIM(@CampusEn)),
					CampusKh=LTRIM(RTRIM(@CampusKh)),
					Description=LTRIM(RTRIM(@Description)),					
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where CampusID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Campus name: ' +@CampusEn + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found'
			end
		end
		else
		begin
			set @Msg = 'Campus name: ' +@CampusEn  +' already exists in the system.'
		end
	end

	select @IsAdd, @Msg
end
go

----------
drop procedure SA_GetCampusByID
go

create procedure SA_GetCampusByID
	@ID int,
	@isList int
as
begin
	if @ID<>0
	begin
		select top 1			
			CampusID,
			ABBR,
			CampusEn,
			CampusKh,
			[Description],
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_ms_campuses		
		where CampusID=@ID
	end
	else if @isList=1
	begin
		select distinct
			CampusID
			,ABBR
			,CampusEn
		from tblsa_ms_campuses
		where (Mark_Deleted=0 OR Mark_Deleted IS NULL)				
		order by CampusEn
	end
	else if @isList=2
	begin
		select
			0 as CampusID, 
			'***' as ABBR,
			'*** All campuses' as CampusEn
		UNION
		select distinct
			CampusID
			,ABBR
			,CampusEn
		from tblsa_ms_campuses
		where (Mark_Deleted=0 OR Mark_Deleted IS NULL)				
		order by CampusEn
	end
	else
	begin
		select distinct
			CampusID,
			ABBR,
			CampusEn,
			CampusKh,
			[Description],
			C.Mark_Deleted as Inactive,
			U.Name as UserCreate,
			C.DateCreate,
			V.Name as UserUpdate,
			C.DateUpdate
		from tblsa_ms_campuses C
			left join tblsa_set_userlog U on C.UserCreate=U.UserNo
			left join tblsa_set_userlog V on C.UserUpdate=V.UserNo
		order by C.Mark_Deleted, CampusEn
	end
end
go

-----------------20191207
--drop procedure SA_GetBuildingToListForAdmin 
--go

--create procedure SA_GetBuildingToListForAdmin
--	@ClinicID int,
--	@Flag bit
--as 
--begin 
--	if @Flag=0
--	begin
--		if @ClinicID=0
--		begin
--			select 				
--				BuildingID as Code,
--				BuildingEn,
--				Acronym,
--				BuildingKh,
--				AddressEn,
--				AddressKh,
--				C.ClinicEn,
--				C.ClinicID,
--				B.UserCreate,
--				B.DateCreate,
--				B.UserUpdate,
--				B.DateUpdate
--			from tblsa_ms_buildings B
--				inner join tblsa_ms_clinic C on B.ClinicID=C.ClinicID
--			where (B.Mark_Deleted=0 or B.Mark_Deleted is null)
--			order by C.ClinicEn, BuildingEn
--		end
--		else
--		begin
--			select 				
--				BuildingID as Code,
--				BuildingEn,
--				Acronym,
--				BuildingKh,
--				AddressEn,
--				AddressKh,
--				C.ClinicEn,
--				C.ClinicID,
--				B.UserCreate,
--				B.DateCreate,
--				B.UserUpdate,
--				B.DateUpdate
--			from tblsa_ms_buildings B
--				inner join tblsa_ms_clinic C on B.ClinicID=C.ClinicID
--			where B.ClinicID=@ClinicID 
--				and B.Mark_Deleted=0 or B.Mark_Deleted is null
--			order by C.ClinicEn, BuildingEn
--		end
--	end
--	else
--	begin
--		if @ClinicID=0
--		begin
--			select 				
--				BuildingID as Code,		
--				BuildingEn,
--				Acronym,
--				BuildingKh,
--				AddressEn,
--				AddressKh,
--				C.ClinicEn,
--				C.ClinicID,
--				B.Mark_Deleted as Inactive,
--				B.UserCreate,
--				B.DateCreate,
--				B.UserUpdate,
--				B.DateUpdate
--			from tblsa_ms_buildings B
--				inner join tblsa_ms_clinic C on B.ClinicID=C.ClinicID			
--			order by C.ClinicEn, BuildingEn
--		end
--		else
--		begin
--			select 				
--				BuildingID as Code,
--				BuildingEn,
--				Acronym,
--				BuildingKh,
--				AddressEn,
--				AddressKh,
--				C.ClinicEn,
--				C.ClinicID,
--				B.Mark_Deleted as Inactive,
--				B.UserCreate,
--				B.DateCreate,
--				B.UserUpdate,
--				B.DateUpdate
--			from tblsa_ms_buildings B
--				inner join tblsa_ms_clinic C on B.ClinicID=C.ClinicID
--			where B.ClinicID=@ClinicID  				
--			order by C.ClinicEn, BuildingEn
--		end
--	end
--end
--go

------------------
drop procedure SA_DisabledBuildings
go

create procedure SA_DisabledBuildings
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
		if exists(select BuildingID from tblsa_ms_buildings where BuildingID=@TempID)
		begin	
			update tblsa_ms_buildings set 
				Mark_Deleted=@Inactive, 
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP				
			where BuildingID=@TempID 
					
			set @IsAdd=1
			declare @UpdateData nvarchar(max)=(select top 1 BuildingEn from tblsa_ms_buildings H inner join @TblTempID T on H.BuildingID=T.ID WHERE H.BuildingID=@TempID)
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
		set @Msg = 'Sections: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		set @Msg='Buildings: ' + @TempStr + ' have been removed.'
	end

	select @IsAdd, @Msg	
end
go

-------------------
drop procedure SA_GetBuildingByID
go

create procedure SA_GetBuildingByID
	@ID int,
	@ClinicID int,
	@isList int
as
begin
	if @ID<>0
	begin
		select top 1			
			BuildingID,
			Acronym,
			BuildingEn,
			BuildingKh,
			AddressEn,
			AddressKh,
			ClinicID,
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_ms_buildings		
		where BuildingID=@ID
	end
	else if @ClinicID<>0 and @isList=1
	begin
		select distinct
			BuildingID,
			Acronym,
			ClinicEn
		from tblsa_ms_buildings B
			inner join tblsa_ms_clinic C on B.ClinicID=C.ClinicID
		where B.ClinicID=@ClinicID
			and (B.Mark_Deleted=0 or B.Mark_Deleted is null)
		order by ClinicEn, Acronym	
	end
	else if @ClinicID<>0 and @isList=2
	begin
		select​ top 1
			999 as BuildingID, 
			'*** All buildings' as Acronym,
			ClinicEn
		from tblsa_ms_buildings B
			inner join tblsa_ms_clinic C on B.ClinicID=C.ClinicID
		where B.ClinicID=@ClinicID
			and (B.Mark_Deleted=0 or B.Mark_Deleted is null)		
		UNION
		select distinct
			BuildingID,
			Acronym,
			ClinicEn
		from tblsa_ms_buildings B
			inner join tblsa_ms_clinic C on B.ClinicID=C.ClinicID
		where B.ClinicID=@ClinicID
			and (B.Mark_Deleted=0 or B.Mark_Deleted is null)
		order by ClinicEn, Acronym	
	end
	else if @ClinicID=0 and @isList=1
	begin
		select distinct
			BuildingID,
			Acronym,
			ClinicEn
		from tblsa_ms_buildings B
			inner join tblsa_ms_clinic C on B.ClinicID=C.ClinicID
		where (B.Mark_Deleted=0 or B.Mark_Deleted is null)
		order by ClinicEn, Acronym	
	end
	else if @ClinicID=0 and @isList=2
	begin
		select​ top 1
			0 as BuildingID, 
			'*** All buildings' as Acronym,
			'*** All clinics' as ClinicEn
		UNION
		select distinct
			BuildingID,
			Acronym,
			ClinicEn
		from tblsa_ms_buildings B
			inner join tblsa_ms_clinic C on B.ClinicID=C.ClinicID
		where (B.Mark_Deleted=0 or B.Mark_Deleted is null)
		order by ClinicEn, Acronym	
	end
	else
	begin
		select 
			BuildingID,
			Acronym,
			BuildingEn,
			BuildingKh,
			AddressEn,
			AddressKh,
			--B.ClinicID,
			CL.ABB as Clinic,
			B.Mark_Deleted as Inactive,
			U.Name as UserCreate,
			B.DateCreate,
			V.Name as UserUpdate,
			B.DateUpdate
		from tblsa_ms_buildings	B
			inner join tblsa_ms_clinic CL on CL.ClinicID=B.ClinicID
			left join tblsa_set_userlog U on B.UserCreate=U.UserNo
			left join tblsa_set_userlog V on B.UserUpdate=V.UserNo
		order by B.Mark_Deleted, CL.ClinicEn, BuildingEn
	end
end
go

--------------------------
--drop procedure SA_GetBuildingByID
--go

--create procedure SA_GetBuildingByID
--	@ClinicID int,
--	@ID int
--as
--begin
--	if @ClinicID <>0 
--	begin
--		if @ID<>0
--		begin
--			select top 1			
--				BuildingID,
--				Acronym,
--				BuildingEn,
--				BuildingKh,
--				AddressEn,
--				AddressKh,
--				ClinicID,
--				Mark_Deleted,
--				UserCreate,
--				DateCreate,
--				UserUpdate,
--				DateUpdate
--			from tblsa_ms_buildings		
--			where BuildingID=@ID
--		end
--		else
--		begin
--			select 
--				BuildingID,
--				Acronym
--				--BuildingEn
--			from tblsa_ms_buildings
--			where ClinicID=@ClinicID
--				and (Mark_Deleted=0 or Mark_Deleted is null)
--			order by Acronym	
--			--select
--			--	BuildingID,
--			--	Acronym,
--			--	BuildingEn,
--			--	BuildingKh,
--			--	AddressEn,
--			--	AddressKh,
--			--	B.CampusID,
--			--	CL.CampusEn,
--			--	B.Mark_Deleted as Inactive,
--			--	B.UserCreate,
--			--	B.DateCreate,
--			--	B.UserUpdate,
--			--	B.DateUpdate
--			--from tblsa_ms_buildings	B
--			--	inner join tblsa_ms_campuses CL on CL.CampusID=B.CampusID
--			--where B.CampusID=@CampusID
--			--order by CL.CampusEn, BuildingEn
--		end
--	end
--	else
--	begin
--		if @ID<>0
--		begin
--			select top 1			
--				BuildingID,
--				Acronym,
--				BuildingEn,
--				BuildingKh,
--				AddressEn,
--				AddressKh,
--				ClinicID,
--				Mark_Deleted,
--				UserCreate,
--				DateCreate,
--				UserUpdate,
--				DateUpdate
--			from tblsa_ms_buildings		
--			where BuildingID=@ID
--		end
--		else
--		begin
--			select
--				BuildingID,
--				Acronym,
--				BuildingEn,
--				BuildingKh,
--				AddressEn,
--				AddressKh,
--				B.ClinicID,
--				CL.ABB as Store,
--				B.Mark_Deleted as Inactive,
--				B.UserCreate,
--				B.DateCreate,
--				B.UserUpdate,
--				B.DateUpdate
--			from tblsa_ms_buildings	B
--				inner join tblsa_ms_clinic CL on CL.ClinicID=B.ClinicID			
--			order by CL.ClinicEn, BuildingEn
--		end
--	end
--end
--go

---------20191207
drop procedure SA_SaveBuildings
go

create procedure SA_SaveBuildings
	@ID int,	
	@ClinicID int,
	@BuildingEn nvarchar(max),
	@Acronym nvarchar(100),
	@BuildingKh nvarchar(max),	
	@AddressEn nvarchar(max),
	@AddressKh nvarchar(max),	
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@BuildingEn)>0 and @ClinicID>0)
	begin
		--if not exists(select BuildingID from tblsa_ms_buildings where ClinicID=@ClinicID and BuildingEn=@BuildingEn and BuildingID<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		if not exists(select BuildingID from tblsa_ms_buildings where ClinicID=@ClinicID and BuildingEn=@BuildingEn and BuildingID<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_ms_buildings(ClinicID, BuildingEn, Acronym, BuildingKh, AddressEn, AddressKh, Mark_Deleted, UserCreate, DateCreate) 
				values(@ClinicID, LTRIM(RTRIM(@BuildingEn)), LTRIM(RTRIM(@Acronym)), LTRIM(RTRIM(@BuildingKh)), LTRIM(RTRIM(@AddressEn)), LTRIM(RTRIM(@AddressKh)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Building name: ' +@BuildingEn +' has been added successfully.'
			end
			else if exists(select BuildingID from tblsa_ms_buildings where BuildingID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_ms_buildings set				
					BuildingEn=LTRIM(RTRIM(@BuildingEn)),
					Acronym=LTRIM(RTRIM(@Acronym)),
					BuildingKh=LTRIM(RTRIM(@BuildingKh)),
					AddressEn=LTRIM(RTRIM(@AddressEn)),
					AddressKh=LTRIM(RTRIM(@AddressKh)),
					ClinicID=@ClinicID,
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where BuildingID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Building name: ' +@BuildingEn + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found'
			end
		end
		else
		begin
			set @Msg = 'Building name: ' +@BuildingEn  +' already exists in the system.'
		end
	end

	select @IsAdd, @Msg
end
go

----------20191121
drop procedure SA_GetDepartmentByID
go

create procedure SA_GetDepartmentByID
	@ID int,
	@ClinicID int,
	@isList int
as
begin
	if @ID<>0
	begin
		select top 1			
			DepartmentID,
			DepartmentKh,
			DepartmentEn,			
			ISNULL(ClinicID, 0) as ClinicID,			
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_ms_departments		
		where DepartmentID=@ID
	end
	else if @ClinicID=0 and @isList=1
	begin
		select distinct
			DepartmentID,
			RTRIM(DepartmentEn) as Department,
			CL.ABB as Clinic
		from tblsa_ms_departments Dept
			inner join tblsa_ms_clinic CL on Dept.ClinicID=CL.ClinicID
		where Dept.Mark_Deleted=0 or Dept.Mark_Deleted is null 
		order by Clinic, Department
	end		
	else if @ClinicID=0 and @isList=2
	begin
		select
			0 as DepartmentID, 
			'*** All departments' as Department,
			'*** All clinics' as Clinic
		UNION
		select distinct
			DepartmentID,
			RTRIM(DepartmentEn) as Department,
			CL.ABB as Clinic
		from tblsa_ms_departments Dept
			inner join tblsa_ms_clinic CL on Dept.ClinicID=CL.ClinicID
		where Dept.Mark_Deleted=0 or Dept.Mark_Deleted is null 
		order by Clinic, Department			
	end
	else if @ClinicID<>0 and @isList=1
	begin
		select distinct
			DepartmentID,
			RTRIM(DepartmentEn) as Department,
			CL.ABB as Clinic
		from tblsa_ms_departments Dept
			inner join tblsa_ms_clinic CL on Dept.ClinicID=CL.ClinicID
		where Dept.ClinicID=@ClinicID
			and (Dept.Mark_Deleted=0 or Dept.Mark_Deleted is null )
		order by Clinic, Department
	end
	else if @ClinicID<>0 and @isList=2
	begin
		select top 1
			999 as DepartmentID, 
			'*** All departments' as Department,
			CL.ABB as Clinic
		from tblsa_ms_departments Dept
			inner join tblsa_ms_clinic CL on Dept.ClinicID=CL.ClinicID
		where Dept.ClinicID=@ClinicID
			and (Dept.Mark_Deleted=0 or Dept.Mark_Deleted is null )
		UNION
		select distinct
			DepartmentID,
			RTRIM(DepartmentEn) as Department,
			CL.ABB as Clinic
		from tblsa_ms_departments Dept
			inner join tblsa_ms_clinic CL on Dept.ClinicID=CL.ClinicID
		where Dept.ClinicID=@ClinicID
			and (Dept.Mark_Deleted=0 or Dept.Mark_Deleted is null )
		order by Clinic, Department
	end	
	else
	begin
		select distinct
			DepartmentID,
			DepartmentEn,			
			DepartmentKh,
			--ISNULL(CL.ClinicID, 0) as ClinicID,		
			CL.ClinicEn,
			D.Mark_Deleted as Inactive,
			U.Name as UserCreate,
			D.DateCreate,
			V.Name as UserUpdate,
			D.DateUpdate
		from tblsa_ms_departments D
			left join tblsa_ms_clinic CL ON D.ClinicID=CL.ClinicID
			left join tblsa_set_userlog U on U.UserNo=D.UserCreate
			left join tblsa_set_userlog V on V.UserNo=D.UserUpdate
		where (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
		order by D.Mark_Deleted, ClinicEn, D.DepartmentEn
	end
end
go


------------
drop procedure SA_SaveDepartment
go

create procedure SA_SaveDepartment
	@ID int,	
	@ClinicID int,
	@DepartmentEn nvarchar(max),
	@DepartmentKh nvarchar(max),	
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@DepartmentEn)>0 and @ClinicID>0)
	begin
		--if not exists(select DepartmentID from tblsa_ms_departments where ClinicID=@ClinicID and DepartmentEn=@DepartmentEn and DepartmentID<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		if not exists(select DepartmentID from tblsa_ms_departments where ClinicID=@ClinicID and DepartmentEn=@DepartmentEn and DepartmentID<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_ms_departments(ClinicID, DepartmentEn, DepartmentKh, Mark_Deleted, UserCreate, DateCreate) 
				values(@ClinicID, LTRIM(RTRIM(@DepartmentEn)), LTRIM(RTRIM(@DepartmentKh)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Department name: ' +@DepartmentEn +' has been added successfully.'
			end
			else if exists(select DepartmentID from tblsa_ms_departments where DepartmentID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_ms_departments set				
					DepartmentEn=LTRIM(RTRIM(@DepartmentEn)),
					DepartmentKh=LTRIM(RTRIM(@DepartmentKh)),
					ClinicID=@ClinicID,
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where DepartmentID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Department name: ' +@DepartmentEn + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found'
			end
		end
		else
		begin
			set @Msg = 'Department name: ' +@DepartmentEn  +' already exists in the system.'
		end
	end

	select @IsAdd, @Msg
end
go

----------------
drop procedure SA_DisabledDepartments
go

create procedure SA_DisabledDepartments
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
									from tblsa_ms_departments Dept
										LEFT JOIN tblsa_employee_employment EH ON Dept.ClinicID = EH.ClinicID and Dept.DepartmentID=EH.DepartmentID
										left join tblsa_employee_cardid EID on EID.ID=EH.CardIDNo				
									where Dept.DepartmentID=@TempID
										and (EH.Mark_Deleted=0 or EH.Mark_Deleted is null)				
										and (EID.Mark_Deleted=0 OR EID.Mark_Deleted IS NULL))
		if exists(select DepartmentID from tblsa_ms_departments where DepartmentID=@TempID)
		begin	
			if @Inactive=1 and @NumStaffs>0
			begin				
				declare @NonUpdateData nvarchar(max)=(select top 1 DepartmentEn from tblsa_ms_departments H inner join @TblTempID T on H.DepartmentID=T.ID WHERE H.DepartmentID=@TempID)
				set @TempStrNotUpdate=@TempStrNotUpdate +  @NonUpdateData +', '
			end
			else
			begin
				update tblsa_ms_departments set 
					Mark_Deleted=@Inactive, 
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP				
				where DepartmentID=@TempID 
					
				set @IsAdd=1
				declare @UpdateData nvarchar(max)=(select top 1 DepartmentEn from tblsa_ms_departments H inner join @TblTempID T on H.DepartmentID=T.ID WHERE H.DepartmentID=@TempID)
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
		set @Msg = 'Departments: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		declare @TempSMS nvarchar(max)=''
		if LEN(@TempStr)=0
		begin
			if LEN(@TempStrNotUpdate)>0
			begin
				set @Msg='Departments: ' +@TempStrNotUpdate +' cannot remove because there are some staff in the department.'
			end
		end
		else
		begin
			if LEN(@TempStrNotUpdate)>0
			begin
				set @Msg='Departments: ' + @TempStr + ' have been removed. Departments: ' +@TempStrNotUpdate +' cannot remove because there are some staff in the department.'
			end
			else
			begin
				set @Msg='Departments: ' + @TempStr + ' have been removed.'
			end
		end
	end

	select @IsAdd, @Msg	
end
go


-----20200115
drop procedure SA_GetMedTreatmentCategoryByID
go

create procedure SA_GetMedTreatmentCategoryByID
	@ID int,
	@isList int
as
begin
	if @ID<>0
	begin
		select top 1			
			CategoryCode,
			CategoryEn,
			CategoryKh,
			Note,								
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_cashier_medical_treatment_categories		
		where CategoryCode=@ID
	end
	else if @isList=1
	begin
		select distinct
			CategoryCode,
			CategoryEn
		from tblsa_cashier_medical_treatment_categories CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by CategoryEn
	end
	else if @isList=2
	begin
		select
			0 as CategoryCode, 			
			'*** All categories' as CategoryEn
		UNION
		select distinct
			CategoryCode,
			CategoryEn
		from tblsa_cashier_medical_treatment_categories CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by CategoryEn
	end
	else
	begin
		select distinct
			CategoryCode,
			CategoryEn,
			CategoryKh,
			Note,				
			CC.Mark_Deleted as Inactive,
			U.Name as UserCreate,
			CC.DateCreate,
			V.Name as UserUpdate,
			CC.DateUpdate
		from tblsa_cashier_medical_treatment_categories CC	
			LEFT join tblsa_set_userlog U on U.UserNo=CC.UserCreate
			LEFT join tblsa_set_userlog V on V.UserNo=CC.UserUpdate
		where (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
		order by CC.Mark_Deleted, CategoryEn
	end
end
go

----------------
drop procedure SA_SaveMedTreatmentCategory
go

create procedure SA_SaveMedTreatmentCategory
	@ID int,	
	@CategoryEn nvarchar(max),
	@CategoryKh nvarchar(max),
	@Des nvarchar(max),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@CategoryEn)>0)
	begin
		--if not exists(select Code from tblsa_ms_diagnosis_groups where DxGroupEn=@DxGroupEn and Code<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		if not exists(select CategoryCode from tblsa_cashier_medical_treatment_categories where CategoryEn=@CategoryEn and CategoryCode<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_cashier_medical_treatment_categories(CategoryEn, CategoryKh, Note, Mark_Deleted, UserCreate, DateCreate) 
				values(LTRIM(RTRIM(@CategoryEn)), LTRIM(RTRIM(@CategoryKh)), LTRIM(RTRIM(@Des)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Medical treatment category: ' +@CategoryEn +' has been added successfully.'
			end
			else if exists(select CategoryEn from tblsa_cashier_medical_treatment_categories where CategoryCode=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_cashier_medical_treatment_categories set				
					CategoryEn=LTRIM(RTRIM(@CategoryEn)),
					CategoryKh=LTRIM(RTRIM(@CategoryKh)),
					Note=LTRIM(RTRIM(@Des)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where CategoryCode=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Medical treatment category: ' +@CategoryEn + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'Medical treatment category: ' +@CategoryEn  +' already exists in the system.'
		end
	end

	select @IsAdd, @Msg
end
go

----------
drop procedure SA_DisabledMedTreatmentCategory
go

create procedure SA_DisabledMedTreatmentCategory
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

		if exists(select CategoryCode from tblsa_cashier_medical_treatment_categories where CategoryCode=@TempID)
		begin	
			update tblsa_cashier_medical_treatment_categories set 
				Mark_Deleted=@Inactive, 
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP				
			where CategoryCode=@TempID 
					
			set @IsAdd=1
			declare @UpdateData nvarchar(max)=(select top 1 CategoryEn from tblsa_cashier_medical_treatment_categories H WHERE H.CategoryCode=@TempID)
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
		set @Msg = 'Medical treatment category: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		set @Msg='Medical treatment category: ' + @TempStr + ' have been removed.'
	end

	select @IsAdd, @Msg	
end
go


----------20191121
drop procedure SA_GetMedTreatmentByID
go

create procedure SA_GetMedTreatmentByID
	@ID int,
	@CategoryID int,
	@isList int
as
begin
	if @ID<>0
	begin
		select top 1			
			TreatmentCode,
			ServiceCode,
			ServiceEn,
			ServiceKh,
			Category,
			ClinicID,
			IsDiscount,
			OriginalCost,
			LocalFee,
			ExpatFee,
			Note,								
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_cashier_medical_treatment		
		where TreatmentCode=@ID
	end
	else if @CategoryID=0 and @isList=1
	begin
		select distinct
			TreatmentCode,
			ServiceEn,
			CategoryEn
		from tblsa_cashier_medical_treatment T
			inner join tblsa_cashier_medical_treatment_categories C on T.Category=C.CategoryCode
		where (T.Mark_Deleted=0 or T.Mark_Deleted is null)
			and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
		order by CategoryEn, ServiceEn
	end		
	else if @CategoryID=0 and @isList=2
	begin
		select
			0 as TreatmentCode, 
			'*** All treatment' as ServiceEn,
			'*** All categories' as CategoryEn
		UNION
		select distinct
			TreatmentCode,
			ServiceEn,
			CategoryEn
		from tblsa_cashier_medical_treatment T
			inner join tblsa_cashier_medical_treatment_categories C on T.Category=C.CategoryCode
		where T.Mark_Deleted=0 or T.Mark_Deleted is null 
		order by CategoryEn, ServiceEn			
	end
	else if @CategoryID<>0 and @isList=1
	begin
		select distinct
			TreatmentCode,
			ServiceEn,
			CategoryEn
		from tblsa_cashier_medical_treatment T
			inner join tblsa_cashier_medical_treatment_categories C on T.Category=C.CategoryCode
		where T.Category=@CategoryID
			and (T.Mark_Deleted=0 or T.Mark_Deleted is null )
			and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
		order by CategoryEn, ServiceEn
	end
	else if @CategoryID<>0 and @isList=2
	begin
		select top 1
			999 as TreatmentCode, 
			'*** All treatment' as ServiceEn,
			CategoryEn
		from tblsa_cashier_medical_treatment T
			inner join tblsa_cashier_medical_treatment_categories C on T.Category=C.CategoryCode
		where T.Category=@CategoryID
			and (T.Mark_Deleted=0 or T.Mark_Deleted is null )
			and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
		UNION
		select distinct
			TreatmentCode,
			ServiceEn,
			CategoryEn
		from tblsa_cashier_medical_treatment T
			inner join tblsa_cashier_medical_treatment_categories C on T.Category=C.CategoryCode
		where T.Category=@CategoryID
			and (T.Mark_Deleted=0 or T.Mark_Deleted is null )
			and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
		order by CategoryEn, ServiceEn
	end	
	else
	begin
		select distinct
			TreatmentCode,
			ServiceCode,
			ServiceEn,
			ServiceKh,
			(CASE T.ClinicID WHEN 0 THEN '*** All clinics' ELSE ClinicEn END) as ClinicEn,
			IsDiscount,
			OriginalCost,
			LocalFee,
			ExpatFee,
			CategoryEn,
			T.Note,			
			T.Mark_Deleted as Inactive,
			U.Name as UserCreate,
			T.DateCreate,
			V.Name as UserUpdate,
			T.DateUpdate
		from tblsa_cashier_medical_treatment T
			inner join tblsa_cashier_medical_treatment_categories C on T.Category=C.CategoryCode
			left join tblsa_ms_clinic CL on CL.ClinicID=T.ClinicID
			left join tblsa_set_userlog U on U.UserNo=T.UserCreate
			left join tblsa_set_userlog V on V.UserNo=T.UserUpdate
		where (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
			and (CL.Mark_Deleted=0 OR CL.Mark_Deleted IS NULL)
			and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
		order by T.Mark_Deleted, ClinicEn, CategoryEn, ServiceEn
	end
end
go


----------------
drop procedure SA_SaveMedTreatment
go

create procedure SA_SaveMedTreatment
	@ID int,	
	@CategoryID int,
	@ServiceCode nvarchar(20),
	@ServiceEn nvarchar(max),
	@ServiceKh nvarchar(max),
	@ClinicID int,
	@IsDiscount bit,
	@OriginalCost float,
	@LocalFee float,
	@ExpatFee float,
	@Des nvarchar(max),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@ServiceEn)>0 and len(@ServiceCode)>0 and @CategoryID>0 )
	begin
		--if not exists(select Code from tblsa_ms_diagnosis_groups where DxGroupEn=@DxGroupEn and Code<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		if not exists(select TreatmentCode from tblsa_cashier_medical_treatment where ServiceEn=@ServiceEn and Category=@CategoryID and ClinicID=@ClinicID and TreatmentCode<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_cashier_medical_treatment(ServiceCode, ServiceEn, ServiceKh, Category, ClinicID, IsDiscount, OriginalCost, LocalFee, ExpatFee, Note, Mark_Deleted, UserCreate, DateCreate) 
				values(UPPER(LTRIM(RTRIM(@ServiceCode))), LTRIM(RTRIM(@ServiceEn)), LTRIM(RTRIM(@ServiceKh)), @CategoryID, @ClinicID, @IsDiscount, ISNULL(@OriginalCost,0), ISNULL(@LocalFee,0), ISNULL(@ExpatFee,0), LTRIM(RTRIM(@Des)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Medical treatment: ' +@ServiceEn +' has been added successfully.'
			end
			else if exists(select TreatmentCode from tblsa_cashier_medical_treatment where TreatmentCode=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_cashier_medical_treatment set				
					ServiceCode=UPPER(LTRIM(RTRIM(@ServiceCode))),
					ServiceEn=LTRIM(RTRIM(@ServiceEn)),
					ServiceKh=LTRIM(RTRIM(@ServiceKh)),
					Category=@CategoryID,
					ClinicID=@ClinicID,
					IsDiscount=ISNULL(@IsDiscount, 0),
					OriginalCost=ISNULL(@OriginalCost, 0),
					LocalFee=ISNULL(@LocalFee, 0),
					ExpatFee=ISNULL(@ExpatFee, 0),
					Note=LTRIM(RTRIM(@Des)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where TreatmentCode=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Medical treatment: ' +@ServiceEn + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'Medical treatment: ' +@ServiceEn  +' already exists in the system.'
		end
	end

	select @IsAdd, @Msg
end
go

----------
drop procedure SA_DisabledMedTreatment
go

create procedure SA_DisabledMedTreatment
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

		if exists(select TreatmentCode from tblsa_cashier_medical_treatment where TreatmentCode=@TempID)
		begin	
			update tblsa_cashier_medical_treatment set 
				Mark_Deleted=@Inactive, 
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP				
			where TreatmentCode=@TempID 
					
			set @IsAdd=1
			declare @UpdateData nvarchar(max)=(select top 1 ServiceEn from tblsa_cashier_medical_treatment H WHERE H.TreatmentCode=@TempID)
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
		set @Msg = 'Medical treatment: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		set @Msg='Medical treatment: ' + @TempStr + ' have been removed.'
	end

	select @IsAdd, @Msg	
end
go

-----20200115
drop procedure SA_GetMembershipTypeByID
go

create procedure SA_GetMembershipTypeByID
	@ID int,
	@isList int
as
begin
	if @ID<>0
	begin
		select top 1			
			TranID,
			MembershipType,			
			Note,								
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_cashier_membership_types		
		where TranID=@ID
	end
	else if @isList=1
	begin
		select distinct
			TranID,
			MembershipType
		from tblsa_cashier_membership_types CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by MembershipType
	end
	else if @isList=2
	begin
		select
			0 as TranID, 			
			'*** All types' as MembershipType
		UNION
		select distinct
			TranID,
			MembershipType
		from tblsa_cashier_membership_types CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by MembershipType
	end
	else
	begin
		select distinct
			TranID,
			MembershipType,
			Note,					
			CC.Mark_Deleted as Inactive,
			U.Name as UserCreate,
			CC.DateCreate,
			V.Name as UserUpdate,
			CC.DateUpdate
		from tblsa_cashier_membership_types CC				
			LEFT join tblsa_set_userlog U on U.UserNo=CC.UserCreate
			LEFT join tblsa_set_userlog V on V.UserNo=CC.UserUpdate
		where (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
		order by CC.Mark_Deleted, MembershipType
	end
end
go

----------------
drop procedure SA_SaveMembershipType
go

create procedure SA_SaveMembershipType
	@ID int,		
	@MembershipType nvarchar(max),
	@Note nvarchar(max),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@MembershipType)>0)
	begin
		--if not exists(select Code from tblsa_ms_diagnosis_groups where DxGroupEn=@DxGroupEn and Code<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		if not exists(select TranID from tblsa_cashier_membership_types where MembershipType=@MembershipType and TranID<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_cashier_membership_types(MembershipType, Note, Mark_Deleted, UserCreate, DateCreate) 
				values(LTRIM(RTRIM(@MembershipType)), LTRIM(RTRIM(@Note)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Membership type: ' +LTRIM(RTRIM(@MembershipType)) +' has been added successfully.'
			end
			else if exists(select TranID from tblsa_cashier_membership_types where TranID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_cashier_membership_types set									
					MembershipType=LTRIM(RTRIM(@MembershipType)),
					Note=LTRIM(RTRIM(@Note)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where TranID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Membership type: ' +LTRIM(RTRIM(@MembershipType)) + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'Membership type: ' +LTRIM(RTRIM(@MembershipType))  +' already exists in the system.'
		end
	end

	select @IsAdd, @Msg
end
go

----------
drop procedure SA_DisabledMembershipType
go

create procedure SA_DisabledMembershipType
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

		if exists(select TranID from tblsa_cashier_membership_types where TranID=@TempID)
		begin	
			update tblsa_cashier_membership_types set 
				Mark_Deleted=@Inactive, 
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP				
			where TranID=@TempID 
					
			set @IsAdd=1
			declare @UpdateData nvarchar(max)=(select top 1 MembershipType from tblsa_cashier_membership_types H WHERE H.TranID=@TempID)
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
		set @Msg = 'Membership type: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		set @Msg='Membership type: ' + @TempStr + ' have been removed.'
	end

	select @IsAdd, @Msg	
end
go

--====
drop procedure SA_GetEnrollmentTypeByID
go

create procedure SA_GetEnrollmentTypeByID
	@ID int,
	@isList int
as
begin
	if @ID<>0
	begin
		select top 1			
			TranID,
			EnrollmentType,
			Note,								
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_cashier_enrollment_types		
		where TranID=@ID
	end
	else if @isList=1
	begin
		select distinct
			TranID,
			EnrollmentType
		from tblsa_cashier_enrollment_types CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by EnrollmentType
	end
	else if @isList=2
	begin
		select
			0 as TranID, 			
			'*** All types' as EnrollmentType
		UNION
		select
			TranID,
			EnrollmentType
		from tblsa_cashier_enrollment_types CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by EnrollmentType
	end
	else
	begin
		select distinct
			TranID,
			EnrollmentType,
			Note,		
			CC.Mark_Deleted as Inactive,
			U.Name as UserCreate,
			CC.DateCreate,
			V.Name as UserUpdate,
			CC.DateUpdate
		from tblsa_cashier_enrollment_types CC	
				LEFT join tblsa_set_userlog U on U.UserNo=CC.UserCreate
			LEFT join tblsa_set_userlog V on V.UserNo=CC.UserUpdate
		where (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
		order by CC.Mark_Deleted, EnrollmentType
	end
end
go

----------------
drop procedure SA_SaveEnrollmentType
go

create procedure SA_SaveEnrollmentType
	@ID int,	
	@EnrollmentType nvarchar(max),
	@Note nvarchar(max),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@EnrollmentType)>0)
	begin
		--if not exists(select Code from tblsa_ms_diagnosis_groups where DxGroupEn=@DxGroupEn and Code<>@ID and (Mark_Deleted=0 or Mark_Deleted is null))
		if not exists(select TranID from tblsa_cashier_enrollment_types where EnrollmentType=@EnrollmentType and TranID<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_cashier_enrollment_types(EnrollmentType, Note, Mark_Deleted, UserCreate, DateCreate) 
				values(LTRIM(RTRIM(@EnrollmentType)), LTRIM(RTRIM(@Note)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Enrollment type: ' +LTRIM(RTRIM(@EnrollmentType)) +' has been added successfully.'
			end
			else if exists(select TranID from tblsa_cashier_enrollment_types where TranID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_cashier_enrollment_types set				
					EnrollmentType=LTRIM(RTRIM(@EnrollmentType)),
					Note=LTRIM(RTRIM(@Note)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where TranID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Enrollment type: ' +LTRIM(RTRIM(@EnrollmentType)) + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'Enrollment type: ' +LTRIM(RTRIM(@EnrollmentType))  +' already exists in the system.'
		end
	end

	select @IsAdd, @Msg
end
go

----------
drop procedure SA_DisabledEnrollmentType
go

create procedure SA_DisabledEnrollmentType
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

		if exists(select TranID from tblsa_cashier_enrollment_types where TranID=@TempID)
		begin	
			update tblsa_cashier_enrollment_types set 
				Mark_Deleted=@Inactive, 
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP				
			where TranID=@TempID 
					
			set @IsAdd=1
			declare @UpdateData nvarchar(max)=(select top 1 EnrollmentType from tblsa_cashier_enrollment_types H WHERE H.TranID=@TempID)
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
		set @Msg = 'Enrollment type: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		set @Msg='Enrollment type: ' + @TempStr + ' have been removed.'
	end

	select @IsAdd, @Msg	
end
go

----====
----====
drop procedure SA_GetMembershipFeeByID
go

create procedure SA_GetMembershipFeeByID
	@ID int,
	@isList int
as
begin
	if @ID<>0
	begin
		select top 1			
			TranID,
			MembershipType,
			EnrollmentType,
			ClinicID,
			Fee,
			Note,								
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_cashier_menbership_enrollment_fee		
		where TranID=@ID
	end
	else
	begin
		select 
			CC.TranID,
			M.MembershipType,
			E.EnrollmentType,
			(CASE CC.ClinicID WHEN 0 THEN '*** All clinics' ELSE ClinicEn END) as ClinicEn,
			CC.Fee,
			CC.Note,		
			CC.Mark_Deleted as Inactive,
			U.Name as UserCreate,
			CC.DateCreate,
			V.Name as UserUpdate,
			CC.DateUpdate
		from tblsa_cashier_menbership_enrollment_fee CC	
			inner join tblsa_cashier_membership_types M on CC.MembershipType=M.TranID
			inner join tblsa_cashier_enrollment_types E on CC.EnrollmentType=E.TranID
			left join tblsa_ms_clinic CL on CC.ClinicID=CL.ClinicID
			LEFT join tblsa_set_userlog U on U.UserNo=CC.UserCreate
			LEFT join tblsa_set_userlog V on V.UserNo=CC.UserUpdate
		where (M.Mark_Deleted=0 OR M.Mark_Deleted IS NULL)
			and (E.Mark_Deleted=0 OR E.Mark_Deleted IS NULL)
			and (CL.Mark_Deleted=0 OR CL.Mark_Deleted IS NULL)
			and (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
		order by CC.Mark_Deleted, CC.ClinicID, E.EnrollmentType, CC.MembershipType
	end
end
go

----------------
drop procedure SA_SaveMembershipFee
go

create procedure SA_SaveMembershipFee
	@ID int,	
	@MembershipType int,
	@EnrollmentType int,
	@ClinicID int,
	@Fee float,
	@Note nvarchar(max),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(@MembershipType>0 and @EnrollmentType>0)
	begin
		if not exists(select TranID from tblsa_cashier_menbership_enrollment_fee where EnrollmentType=@EnrollmentType and MembershipType=@MembershipType and ClinicID=@ClinicID and TranID<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_cashier_menbership_enrollment_fee(MembershipType, EnrollmentType, ClinicID, Fee, Note, Mark_Deleted, UserCreate, DateCreate) 
				values(@MembershipType, @EnrollmentType, @ClinicID, ISNULL(@Fee, 0), LTRIM(RTRIM(@Note)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = (select top 1 'Membership type: ' +MembershipType +' with enrollment type: ' +EnrollmentType +' is cost=$' +CONVERT(NVARCHAR(5), @Fee) from tblsa_cashier_membership_types M, tblsa_cashier_enrollment_types E where M.TranID=@MembershipType and E.TranID=@EnrollmentType and (M.Mark_Deleted=0 OR M.Mark_Deleted IS NULL) and (E.Mark_Deleted=0 OR E.Mark_Deleted IS NULL))
			end
			else if exists(select TranID from tblsa_cashier_menbership_enrollment_fee where TranID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_cashier_menbership_enrollment_fee set	
					MembershipType=@MembershipType,
					EnrollmentType=@EnrollmentType,
					ClinicID=@ClinicID,
					Fee=ISNULL(@Fee,0),
					Note=LTRIM(RTRIM(@Note)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where TranID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = (select top 1 'Membership type: ' +MembershipType +' with enrollment type: ' +EnrollmentType +' is updated cost=$' +CONVERT(NVARCHAR(5), @Fee) from tblsa_cashier_membership_types M, tblsa_cashier_enrollment_types E where M.TranID=@MembershipType and E.TranID=@EnrollmentType and (M.Mark_Deleted=0 OR M.Mark_Deleted IS NULL) and (E.Mark_Deleted=0 OR E.Mark_Deleted IS NULL))
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = (select top 1 'Membership type: ' +MembershipType +' with enrollment type: ' +EnrollmentType +' already exists on the system.' from tblsa_cashier_membership_types M, tblsa_cashier_enrollment_types E where M.TranID=@MembershipType and E.TranID=@EnrollmentType and (M.Mark_Deleted=0 OR M.Mark_Deleted IS NULL) and (E.Mark_Deleted=0 OR E.Mark_Deleted IS NULL))
		end
	end

	select @IsAdd, @Msg
end
go

----------
drop procedure SA_DisabledMembershipFee
go

create procedure SA_DisabledMembershipFee
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

		if exists(select TranID from tblsa_cashier_menbership_enrollment_fee where TranID=@TempID)
		begin	
			update tblsa_cashier_menbership_enrollment_fee set 
				Mark_Deleted=@Inactive, 
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP				
			where TranID=@TempID 
					
			set @IsAdd=1
			declare @UpdateData nvarchar(max)=(select top 1 TranID from tblsa_cashier_menbership_enrollment_fee H WHERE H.TranID=@TempID)
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
		set @Msg = 'Membership enrollment: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		set @Msg='Membership enrollment: ' + @TempStr + ' have been removed.'
	end

	select @IsAdd, @Msg	
end
go


------20200116
drop procedure SA_GetMedicalFormByID
go

create procedure SA_GetMedicalFormByID
	@ID int,
	@isList int
as
begin
	if @ID<>0
	begin
		select top 1			
			TranID,
			FormEn,			
			FormKh,
			Note,								
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_pharmacy_drug_form		
		where TranID=@ID
	end
	else if @isList=1
	begin
		select distinct
			TranID,
			FormEn
		from tblsa_pharmacy_drug_form CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by FormEn
	end
	else if @isList=2
	begin
		select
			0 as TranID, 			
			'*** All types' as FormEn
		UNION
		select distinct
			TranID,
			FormEn
		from tblsa_pharmacy_drug_form CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by FormEn
	end
	else
	begin
		select distinct
			TranID,
			FormEn,
			FormKh,
			Note,					
			CC.Mark_Deleted as Inactive,
			U.Name as UserCreate,
			CC.DateCreate,
			V.Name as UserUpdate,
			CC.DateUpdate
		from tblsa_pharmacy_drug_form CC				
			LEFT join tblsa_set_userlog U on U.UserNo=CC.UserCreate
			LEFT join tblsa_set_userlog V on V.UserNo=CC.UserUpdate
		where (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
		order by CC.Mark_Deleted, FormEn
	end
end
go

----------------
drop procedure SA_SaveMedicalForm
go

create procedure SA_SaveMedicalForm
	@ID int,		
	@FormEn nvarchar(max),
	@FormKh nvarchar(max),
	@Note nvarchar(max),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@FormEn)>0)
	begin		
		if not exists(select TranID from tblsa_pharmacy_drug_form where FormEn=@FormEn and TranID<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_pharmacy_drug_form(FormEn, FormKh, Note, Mark_Deleted, UserCreate, DateCreate) 
				values(LTRIM(RTRIM(@FormEn)), LTRIM(RTRIM(@FormKh)), LTRIM(RTRIM(@Note)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Medical form: ' +LTRIM(RTRIM(@FormEn)) +' has been added successfully.'
			end
			else if exists(select TranID from tblsa_pharmacy_drug_form where TranID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_pharmacy_drug_form set									
					FormEn=LTRIM(RTRIM(@FormEn)),
					FormKh=LTRIM(RTRIM(@FormKh)),
					Note=LTRIM(RTRIM(@Note)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where TranID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Medical form: ' +LTRIM(RTRIM(@FormEn)) + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'Medical form: ' +LTRIM(RTRIM(@FormEn))  +' already exists in the system.'
		end
	end

	select @IsAdd, @Msg
end
go

----------
drop procedure SA_DisabledMedicalForm
go

create procedure SA_DisabledMedicalForm
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

		if exists(select TranID from tblsa_pharmacy_drug_form where TranID=@TempID)
		begin	
			update tblsa_pharmacy_drug_form set 
				Mark_Deleted=@Inactive, 
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP				
			where TranID=@TempID 
					
			set @IsAdd=1
			declare @UpdateData nvarchar(max)=(select top 1 FormEn from tblsa_pharmacy_drug_form H WHERE H.TranID=@TempID)
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
		set @Msg = 'Medical form: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		set @Msg='Medical form: ' + @TempStr + ' have been removed.'
	end

	select @IsAdd, @Msg	
end
go


-----20200116
drop procedure SA_GetMedicalClassificationByID
go

create procedure SA_GetMedicalClassificationByID
	@ID int,
	@isList int
as
begin
	if @ID<>0
	begin
		select top 1			
			TranID,
			ClassificationEn,
			ClassificationKh,
			Note,								
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_pharmacy_drug_classification		
		where TranID=@ID
	end
	else if @isList=1
	begin
		select distinct
			TranID,
			ClassificationEn
		from tblsa_pharmacy_drug_classification CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by ClassificationEn
	end
	else if @isList=2
	begin
		select
			0 as TranID, 			
			'*** All classes' as ClassificationEn
		UNION
		select distinct
			TranID,
			ClassificationEn
		from tblsa_pharmacy_drug_classification CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by ClassificationEn
	end
	else
	begin
		select distinct
			TranID,
			ClassificationEn,
			ClassificationKh,
			Note,					
			CC.Mark_Deleted as Inactive,
			U.Name as UserCreate,
			CC.DateCreate,
			V.Name as UserUpdate,
			CC.DateUpdate
		from tblsa_pharmacy_drug_classification CC				
			LEFT join tblsa_set_userlog U on U.UserNo=CC.UserCreate
			LEFT join tblsa_set_userlog V on V.UserNo=CC.UserUpdate
		where (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
		order by CC.Mark_Deleted, ClassificationEn
	end
end
go

----------------
drop procedure SA_SaveMedicalClassification
go

create procedure SA_SaveMedicalClassification
	@ID int,		
	@ClassificationEn nvarchar(max),
	@ClassificationKh nvarchar(max),
	@Note nvarchar(max),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@ClassificationEn)>0)
	begin		
		if not exists(select TranID from tblsa_pharmacy_drug_classification where ClassificationEn=@ClassificationEn and TranID<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_pharmacy_drug_classification(ClassificationEn, ClassificationKh, Note, Mark_Deleted, UserCreate, DateCreate) 
				values(LTRIM(RTRIM(@ClassificationEn)), LTRIM(RTRIM(@ClassificationKh)), LTRIM(RTRIM(@Note)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Medical class: ' +LTRIM(RTRIM(@ClassificationEn)) +' has been added successfully.'
			end
			else if exists(select TranID from tblsa_pharmacy_drug_classification where TranID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_pharmacy_drug_classification set									
					ClassificationEn=LTRIM(RTRIM(@ClassificationEn)),
					ClassificationKh=LTRIM(RTRIM(@ClassificationKh)),
					Note=LTRIM(RTRIM(@Note)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where TranID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Medical class: ' +LTRIM(RTRIM(@ClassificationEn)) + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'Medical class: ' +LTRIM(RTRIM(@ClassificationEn))  +' already exists in the system.'
		end
	end

	select @IsAdd, @Msg
end
go

----------
drop procedure SA_DisabledMedicalClassification
go

create procedure SA_DisabledMedicalClassification
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

		if exists(select TranID from tblsa_pharmacy_drug_classification where TranID=@TempID)
		begin	
			update tblsa_pharmacy_drug_form set 
				Mark_Deleted=@Inactive, 
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP				
			where TranID=@TempID 
					
			set @IsAdd=1
			declare @UpdateData nvarchar(max)=(select top 1 ClassificationEn from tblsa_pharmacy_drug_classification H WHERE H.TranID=@TempID)
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
		set @Msg = 'Medical class: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		set @Msg='Medical class: ' + @TempStr + ' have been removed.'
	end

	select @IsAdd, @Msg	
end
go


-----Generic Name
-----20200116
drop procedure SA_GetGenericNameByID
go

create procedure SA_GetGenericNameByID
	@ID int,
	@isList int
as
begin
	if @ID<>0
	begin
		select top 1			
			TranID,
			GenericEn,
			GenericKh,			
			Note,								
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_pharmacy_generic_name		
		where TranID=@ID
	end
	else if @isList=1
	begin
		select distinct
			TranID,
			GenericEn			
		from tblsa_pharmacy_generic_name CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by GenericEn
	end
	else if @isList=2
	begin
		select
			0 as TranID, 			
			'*** All names' as GenericEn
		UNION
		select distinct
			TranID,
			GenericEn
		from tblsa_pharmacy_generic_name CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by GenericEn
	end
	else
	begin
		select distinct
			TranID,
			GenericEn,
			GenericKh,
			Note,					
			CC.Mark_Deleted as Inactive,
			U.Name as UserCreate,
			CC.DateCreate,
			V.Name as UserUpdate,
			CC.DateUpdate
		from tblsa_pharmacy_generic_name CC				
			LEFT join tblsa_set_userlog U on U.UserNo=CC.UserCreate
			LEFT join tblsa_set_userlog V on V.UserNo=CC.UserUpdate
		where (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
		order by CC.Mark_Deleted, GenericEn
	end
end
go



----------------
drop procedure SA_SaveInstructionAbbreviation
go

create procedure SA_SaveInstructionAbbreviation
	@ID int,		
	@AbbKey nvarchar(100),
	@FullWordEn nvarchar(max),
	@FullWordKh nvarchar(max),
	@Note nvarchar(max),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@FullWordEn)>0 and len(@AbbKey)>0)
	begin		
		if not exists(select TranID from tblsa_pharmacy_instruction_abbreviation where AbbKey=@AbbKey and FullWordEn=@FullWordEn and TranID<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_pharmacy_instruction_abbreviation(AbbKey, FullWordEn, FullWordKh, Note, Mark_Deleted, UserCreate, DateCreate) 
				values(LTRIM(RTRIM(@AbbKey)), LTRIM(RTRIM(@FullWordEn)), LTRIM(RTRIM(@FullWordKh)), LTRIM(RTRIM(@Note)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Abbreivation word: ' +LTRIM(RTRIM(@FullWordEn)) +' has been added successfully.'
			end
			else if exists(select TranID from tblsa_pharmacy_instruction_abbreviation where TranID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_pharmacy_instruction_abbreviation set		
					AbbKey=LTRIM(RTRIM(@AbbKey)),
					FullWordEn=LTRIM(RTRIM(@FullWordEn)),
					FullWordKh=LTRIM(RTRIM(@FullWordKh)),
					Note=LTRIM(RTRIM(@Note)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where TranID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Abbreivation word: ' +LTRIM(RTRIM(@FullWordEn)) + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'Abbreivation word: ' +LTRIM(RTRIM(@FullWordEn))  +' already exists in the system.'
		end
	end

	select @IsAdd, @Msg
end
go

----------
drop procedure SA_DisabledInstructionAbbreviation
go

create procedure SA_DisabledInstructionAbbreviation
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

		if exists(select TranID from tblsa_pharmacy_instruction_abbreviation where TranID=@TempID)
		begin	
			update tblsa_pharmacy_instruction_abbreviation set 
				Mark_Deleted=@Inactive, 
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP				
			where TranID=@TempID 
					
			set @IsAdd=1
			declare @UpdateData nvarchar(max)=(select top 1 AbbKey from tblsa_pharmacy_instruction_abbreviation H WHERE H.TranID=@TempID)
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
		set @Msg = 'Abbreivation word: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		set @Msg='Abbreivation word: ' + @TempStr + ' have been removed.'
	end

	select @IsAdd, @Msg	
end
go


--------20200117
drop procedure SA_GetLabUnitByID
go

create procedure SA_GetLabUnitByID
	@ID int,
	@isList int
as
begin
	if @ID<>0
	begin
		select top 1			
			TranID,
			UnitEn,
			UnitKh,			
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_lab_unit		
		where TranID=@ID
	end
	else if @isList=1
	begin
		select distinct
			TranID,
			UnitEn		
		from tblsa_lab_unit CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by UnitEn
	end
	else if @isList=2
	begin
		select
			0 as TranID, 		
			'*** All' as UnitEn			
		UNION
		select distinct
			TranID,
			UnitEn
		from tblsa_lab_unit CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by UnitEn
	end
	else
	begin
		select distinct
			TranID,
			UnitEn,
			UnitKh,			
			CC.Mark_Deleted as Inactive,
			U.Name as UserCreate,
			CC.DateCreate,
			V.Name as UserUpdate,
			CC.DateUpdate
		from tblsa_lab_unit CC				
			LEFT join tblsa_set_userlog U on U.UserNo=CC.UserCreate
			LEFT join tblsa_set_userlog V on V.UserNo=CC.UserUpdate
		where (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
		order by CC.Mark_Deleted, UnitEn
	end
end
go

----------
drop procedure SA_GetLabSectionByID
go

create procedure SA_GetLabSectionByID
	@ID int,
	@isList int
as
begin
	if @ID<>0
	begin
		select top 1			
			TranID,
			SectionEn,
			SectionKh,				
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_lab_section		
		where TranID=@ID
	end
	else if @isList=1
	begin
		select distinct
			TranID,
			SectionEn		
		from tblsa_lab_section CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by SectionEn
	end
	else if @isList=2
	begin
		select
			0 as TranID, 		
			'*** All' as SectionEn			
		UNION
		select distinct
			TranID,
			SectionEn
		from tblsa_lab_section CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by SectionEn
	end
	else
	begin
		select distinct
			TranID,
			SectionEn,
			SectionKh,			
			CC.Mark_Deleted as Inactive,
			U.Name as UserCreate,
			CC.DateCreate,
			V.Name as UserUpdate,
			CC.DateUpdate
		from tblsa_lab_section CC				
			LEFT join tblsa_set_userlog U on U.UserNo=CC.UserCreate
			LEFT join tblsa_set_userlog V on V.UserNo=CC.UserUpdate
		where (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
		order by CC.Mark_Deleted, SectionEn
	end
end
go

----------
drop procedure SA_GetLabByID
go

create procedure SA_GetLabByID
	@ID int,
	@isList int
as
begin
	if @ID<>0
	begin
		select top 1			
			TranID,
			LabEn,
			LabKh,				
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_lab		
		where TranID=@ID
	end
	else if @isList=1
	begin
		select distinct
			TranID,
			LabEn	
		from tblsa_lab CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by LabEn
	end
	else if @isList=2
	begin
		select
			0 as TranID, 		
			'*** All' as LabEn			
		UNION
		select distinct
			TranID,
			LabEn
		from tblsa_lab CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by LabEn
	end
	else
	begin
		select distinct
			TranID,
			LabEn,
			LabKh,			
			CC.Mark_Deleted as Inactive,
			U.Name as UserCreate,
			CC.DateCreate,
			V.Name as UserUpdate,
			CC.DateUpdate
		from tblsa_lab CC				
			LEFT join tblsa_set_userlog U on U.UserNo=CC.UserCreate
			LEFT join tblsa_set_userlog V on V.UserNo=CC.UserUpdate
		where (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
		order by CC.Mark_Deleted, LabEn
	end
end
go

----------
drop procedure SA_GetGroupTestByID
go

create procedure SA_GetGroupTestByID
	@ID int,
	@isList int
as
begin
	if @ID<>0
	begin
		select top 1			
			TranID,
			GroupEn,
			GroupKh,				
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_lab_group_test		
		where TranID=@ID
	end
	else if @isList=1
	begin
		select distinct
			TranID,
			GroupEn	
		from tblsa_lab_group_test CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by GroupEn
	end
	else if @isList=2
	begin
		select
			0 as TranID, 		
			'*** All' as GroupEn			
		UNION
		select distinct
			TranID,
			GroupEn
		from tblsa_lab_group_test CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by GroupEn
	end
	else
	begin
		select distinct
			TranID,
			GroupEn,
			GroupKh,			
			CC.Mark_Deleted as Inactive,
			U.Name as UserCreate,
			CC.DateCreate,
			V.Name as UserUpdate,
			CC.DateUpdate
		from tblsa_lab_group_test CC				
			LEFT join tblsa_set_userlog U on U.UserNo=CC.UserCreate
			LEFT join tblsa_set_userlog V on V.UserNo=CC.UserUpdate
		where (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
		order by CC.Mark_Deleted, GroupEn
	end
end
go

----------------
drop procedure SA_SaveLabUnit
go

create procedure SA_SaveLabUnit
	@ID int,			
	@FullWordEn nvarchar(max),
	@FullWordKh nvarchar(max),	
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@FullWordEn)>0)
	begin		
		if not exists(select TranID from tblsa_lab_unit where UnitEn=@FullWordEn and TranID<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_lab_unit(UnitEn, Unitkh, Mark_Deleted, UserCreate, DateCreate) 
				values(LTRIM(RTRIM(@FullWordEn)), LTRIM(RTRIM(@FullWordKh)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Lab unit: ' +LTRIM(RTRIM(@FullWordEn)) +' has been added successfully.'
			end
			else if exists(select TranID from tblsa_lab_unit where TranID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_lab_unit set		
					UnitEn=LTRIM(RTRIM(@FullWordEn)),
					UnitKh=LTRIM(RTRIM(@FullWordKh)),					
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where TranID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Lab unit: ' +LTRIM(RTRIM(@FullWordEn)) + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'Lab unit: ' +LTRIM(RTRIM(@FullWordEn))  +' already exists in the system.'
		end
	end

	select @IsAdd, @Msg
end
go

----------------
drop procedure SA_SaveLabSection
go

create procedure SA_SaveLabSection
	@ID int,			
	@FullWordEn nvarchar(max),
	@FullWordKh nvarchar(max),	
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@FullWordEn)>0)
	begin		
		if not exists(select TranID from tblsa_lab_section where SectionEn=@FullWordEn and TranID<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_lab_section(SectionEn, SectionKh, Mark_Deleted, UserCreate, DateCreate) 
				values(LTRIM(RTRIM(@FullWordEn)), LTRIM(RTRIM(@FullWordKh)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Lab section: ' +LTRIM(RTRIM(@FullWordEn)) +' has been added successfully.'
			end
			else if exists(select TranID from tblsa_lab_section where TranID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_lab_section set		
					SectionEn=LTRIM(RTRIM(@FullWordEn)),
					SectionKh=LTRIM(RTRIM(@FullWordKh)),					
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where TranID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Lab section: ' +LTRIM(RTRIM(@FullWordEn)) + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'Lab section: ' +LTRIM(RTRIM(@FullWordEn))  +' already exists in the system.'
		end
	end

	select @IsAdd, @Msg
end
go

----------------
drop procedure SA_SaveLab
go

create procedure SA_SaveLab
	@ID int,			
	@FullWordEn nvarchar(max),
	@FullWordKh nvarchar(max),	
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@FullWordEn)>0)
	begin		
		if not exists(select TranID from tblsa_lab where LabEn=@FullWordEn and TranID<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_lab(LabEn, LabKh, Mark_Deleted, UserCreate, DateCreate) 
				values(LTRIM(RTRIM(@FullWordEn)), LTRIM(RTRIM(@FullWordKh)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Lab: ' +LTRIM(RTRIM(@FullWordEn)) +' has been added successfully.'
			end
			else if exists(select TranID from tblsa_lab where TranID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_lab set		
					LabEn=LTRIM(RTRIM(@FullWordEn)),
					LabKh=LTRIM(RTRIM(@FullWordKh)),					
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where TranID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Lab: ' +LTRIM(RTRIM(@FullWordEn)) + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'Lab: ' +LTRIM(RTRIM(@FullWordEn))  +' already exists in the system.'
		end
	end

	select @IsAdd, @Msg
end
go

----------------
drop procedure SA_SaveGroupTest
go

create procedure SA_SaveGroupTest
	@ID int,			
	@FullWordEn nvarchar(max),
	@FullWordKh nvarchar(max),	
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@FullWordEn)>0)
	begin		
		if not exists(select TranID from tblsa_lab_group_test where GroupEn=@FullWordEn and TranID<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_lab_group_test(GroupEn, GroupKh, Mark_Deleted, UserCreate, DateCreate) 
				values(LTRIM(RTRIM(@FullWordEn)), LTRIM(RTRIM(@FullWordKh)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Group test: ' +LTRIM(RTRIM(@FullWordEn)) +' has been added successfully.'
			end
			else if exists(select TranID from tblsa_lab_group_test where TranID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_lab_group_test set		
					GroupEn=LTRIM(RTRIM(@FullWordEn)),
					GroupKh=LTRIM(RTRIM(@FullWordKh)),					
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where TranID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Group test: ' +LTRIM(RTRIM(@FullWordEn)) + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'Group test: ' +LTRIM(RTRIM(@FullWordEn))  +' already exists in the system.'
		end
	end

	select @IsAdd, @Msg
end
go

--------------
drop procedure SA_DisabledLabUnit
go

create procedure SA_DisabledLabUnit
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

		if exists(select TranID from tblsa_lab_unit where TranID=@TempID)
		begin	
			update tblsa_lab_unit set 
				Mark_Deleted=@Inactive, 
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP				
			where TranID=@TempID 
					
			set @IsAdd=1
			declare @UpdateData nvarchar(max)=(select top 1 UnitEn from tblsa_lab_unit H WHERE H.TranID=@TempID)
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
		set @Msg = 'Lab unit: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		set @Msg='Lab unit: ' + @TempStr + ' have been removed.'
	end

	select @IsAdd, @Msg	
end
go

-----------
drop procedure SA_DisabledLabSection
go

create procedure SA_DisabledLabSection
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

		if exists(select TranID from tblsa_lab_section where TranID=@TempID)
		begin	
			update tblsa_lab_section set 
				Mark_Deleted=@Inactive, 
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP				
			where TranID=@TempID 
					
			set @IsAdd=1
			declare @UpdateData nvarchar(max)=(select top 1 SectionEn from tblsa_lab_section H WHERE H.TranID=@TempID)
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
		set @Msg = 'Lab section: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		set @Msg='Lab section: ' + @TempStr + ' have been removed.'
	end

	select @IsAdd, @Msg	
end
go

-----------
drop procedure SA_DisabledLab
go

create procedure SA_DisabledLab
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

		if exists(select TranID from tblsa_lab where TranID=@TempID)
		begin	
			update tblsa_lab set 
				Mark_Deleted=@Inactive, 
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP				
			where TranID=@TempID 
					
			set @IsAdd=1
			declare @UpdateData nvarchar(max)=(select top 1 LabEn from tblsa_lab H WHERE H.TranID=@TempID)
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
		set @Msg = 'Lab: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		set @Msg='Lab: ' + @TempStr + ' have been removed.'
	end

	select @IsAdd, @Msg	
end
go

-----------
drop procedure SA_DisabledGroupTest
go

create procedure SA_DisabledGroupTest
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

		if exists(select TranID from tblsa_lab_group_test where TranID=@TempID)
		begin	
			update tblsa_lab_group_test set 
				Mark_Deleted=@Inactive, 
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP				
			where TranID=@TempID 
					
			set @IsAdd=1
			declare @UpdateData nvarchar(max)=(select top 1 GroupEn from tblsa_lab_group_test H WHERE H.TranID=@TempID)
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
		set @Msg = 'Group test: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		set @Msg='Group test: ' + @TempStr + ' have been removed.'
	end

	select @IsAdd, @Msg	
end
go

-----20200126

drop procedure SA_GetDxDiagnosisCode
go

create procedure SA_GetDxDiagnosisCode
	@ID int
as
begin
	select top 1
		DxCode
	from tblsa_ms_diagnosis
	where DiagnosisCode=@ID
		and (Mark_Deleted=0 OR Mark_Deleted IS NULL)
end
go


--------------------=============
--SELECT        TOP (100) PERCENT CONVERT(VARCHAR(20), dbo.Registrations.PaymentDate, 112) AS PaymentDate, dbo.Students.CardID, dbo.Students.StudentName, dbo.Students.Gender, dbo.Registrations.Reg, dbo.Courses.CourseName, 
--                         dbo.Registrations.InvoiceID, dbo.Registrations.RegFrom, dbo.Registrations.RegTo, dbo.Registrations.TotalPaid, CASE WHEN Reg = 'New' THEN 1 ELSE 0 END AS RegNew, 
--                         CASE WHEN Reg = 'Old' THEN 1 ELSE 0 END AS RegOld, dbo.Terms.TermID, dbo.LevelCost.LevelC, dbo.TimeStudies.TimeStudy, dbo.Rooms.RoomName, dbo.Courses.COrder, dbo.Terms.Term, dbo.Students.RegID, 
--                         dbo.Students.DOB, dbo.Students.Images, dbo.Registrations.UserCreate, dbo.Registrations.Remark, dbo.Classes.CourseID, dbo.Registrations.isReturn, dbo.Students.StudentNameCN, dbo.Students.CallTerminate, 
--                         dbo.Students.PhoneP, dbo.Students.PhoneGuardian, dbo.Courses.programType
--FROM            dbo.Class_Details INNER JOIN
--                         dbo.Registrations INNER JOIN
--                         dbo.RegClasses ON dbo.Registrations.InvoiceID = dbo.RegClasses.InvoiceID ON dbo.Class_Details.ClassID = dbo.RegClasses.ClassID INNER JOIN
--                         dbo.Courses INNER JOIN
--                         dbo.Classes ON dbo.Courses.CourseID = dbo.Classes.CourseID ON dbo.Class_Details.ClassID = dbo.Classes.ClassID INNER JOIN
--                         dbo.Terms ON dbo.Classes.TermID = dbo.Terms.TermID INNER JOIN
--                         dbo.LevelCost ON dbo.Classes.LevelID = dbo.LevelCost.LevelID INNER JOIN
--                         dbo.TimeStudies ON dbo.Classes.TimeID = dbo.TimaeStudies.TimeID INNER JOIN
--                         dbo.Rooms ON dbo.Class_Details.RoomID = dbo.Rooms.RoomID RIGHT OUTER JOIN
--                         dbo.Students ON dbo.Registrations.CardID = dbo.Students.CardID
--WHERE        (dbo.Registrations.VoidInvoice <> 'Y' OR
--                         dbo.Registrations.VoidInvoice IS NULL) AND (dbo.Courses.COrder <> 0)
--ORDER BY dbo.Registrations.InvoiceID
----------------
drop procedure SA_SaveGenericName
go

create procedure SA_SaveGenericName
	@ID int,		
	@GenericEn nvarchar(max),
	@GenericKh nvarchar(max),
	@Note nvarchar(max),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@GenericEn)>0)
	begin		
		if not exists(select TranID from tblsa_pharmacy_generic_name where GenericEn=@GenericEn and TranID<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_pharmacy_generic_name(GenericEn, GenericKh, Note, Mark_Deleted, UserCreate, DateCreate) 
				values(LTRIM(RTRIM(@GenericEn)), LTRIM(RTRIM(@GenericKh)), LTRIM(RTRIM(@Note)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Generic name: ' +LTRIM(RTRIM(@GenericEn)) +' has been added successfully.'
			end
			else if exists(select TranID from tblsa_pharmacy_generic_name where TranID=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_pharmacy_generic_name set									
					GenericEn=LTRIM(RTRIM(@GenericEn)),
					GenericKh=LTRIM(RTRIM(@GenericKh)),
					Note=LTRIM(RTRIM(@Note)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where TranID=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Generic name: ' +LTRIM(RTRIM(@GenericEn)) + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'Generic name: ' +LTRIM(RTRIM(@GenericEn))  +' already exists in the system.'
		end
	end

	select @IsAdd, @Msg
end
go

----------
drop procedure SA_DisabledGenericName
go

create procedure SA_DisabledGenericName
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

		if exists(select TranID from tblsa_pharmacy_generic_name where TranID=@TempID)
		begin	
			update tblsa_pharmacy_generic_name set 
				Mark_Deleted=@Inactive, 
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP				
			where TranID=@TempID 
					
			set @IsAdd=1
			declare @UpdateData nvarchar(max)=(select top 1 GenericEn from tblsa_pharmacy_generic_name H WHERE H.TranID=@TempID)
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
		set @Msg = 'Generic name: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		set @Msg='Generic name: ' + @TempStr + ' have been removed.'
	end

	select @IsAdd, @Msg	
end
go


----Rx Instruction
-----20200116
drop procedure SA_GetInstructionAbbreviationByID
go

create procedure SA_GetInstructionAbbreviationByID
	@ID int,
	@isList int
as
begin
	if @ID<>0
	begin
		select top 1			
			TranID,
			AbbKey,
			FullWordEn,
			FullWordKh,		
			Note,								
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_pharmacy_instruction_abbreviation		
		where TranID=@ID
	end
	else if @isList=1
	begin
		select distinct
			TranID,
			AbbKey,
			FullWordEn			
		from tblsa_pharmacy_instruction_abbreviation CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by AbbKey
	end
	else if @isList=2
	begin
		select
			0 as TranID, 		
			'*** All' as AbbKey,
			'*** All names' as FullWordEn
		UNION
		select distinct
			TranID,
			AbbKey,
			FullWordEn
		from tblsa_pharmacy_instruction_abbreviation CC				
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
		order by AbbKey
	end
	else
	begin
		select 
			TranID,
			AbbKey,
			FullWordEn,
			FullWordKh,
			Note,					
			CC.Mark_Deleted as Inactive,
			U.Name as UserCreate,
			CC.DateCreate,
			V.Name as UserUpdate,
			CC.DateUpdate
		from tblsa_pharmacy_instruction_abbreviation CC				
			LEFT join tblsa_set_userlog U on U.UserNo=CC.UserCreate
			LEFT join tblsa_set_userlog V on V.UserNo=CC.UserUpdate
		where (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
		order by CC.Mark_Deleted, AbbKey
	end
end
go

--------------
---===========
--20200131
----------------
drop procedure SA_SaveShelf
go

create procedure SA_SaveShelf
	@ID int,	
	@ClinicID int,
	@En nvarchar(max),
	@Kh nvarchar(max),
	@Note nvarchar(max),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(200) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot performance this operation while the code is empty.'

	if(len(@En)>0 and @ClinicID<>0)
	begin		
		if not exists(select ShelfCode from tblsa_pharmacy_shelf where ShelfEn=@En and ShelfCode<>@ID)
		begin
			if @ID=0
			begin
				insert into tblsa_pharmacy_shelf(ClinicID, ShelfEn, ShelfKh, Note, Mark_Deleted, UserCreate, DateCreate) 
				values(@ClinicID, LTRIM(RTRIM(@En)), LTRIM(RTRIM(@kh)), LTRIM(RTRIM(@Note)), 0, @User, CURRENT_TIMESTAMP)					
				set @IsAdd=1
				set @Msg = 'Shelf name: ' +LTRIM(RTRIM(@En)) +' has been added successfully.'
			end
			else if exists(select ShelfCode from tblsa_pharmacy_shelf where ShelfCode=@ID and (Mark_Deleted=0 or Mark_Deleted is null))
			begin
				update tblsa_pharmacy_shelf set		
					ClinicID=@ClinicID,
					ShelfEn=LTRIM(RTRIM(@En)),
					ShelfKh=LTRIM(RTRIM(@Kh)),
					Note=LTRIM(RTRIM(@Note)),
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where ShelfCode=@ID 
					and (Mark_Deleted=0 or Mark_Deleted is null)
			
				set @IsAdd=2
				set @Msg = 'Shelf name: ' +LTRIM(RTRIM(@En)) + ' has been updated successfully.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'Shelf name: ' +LTRIM(RTRIM(@En))  +' already exists in the system.'
		end
	end

	select @IsAdd, @Msg
end
go

----------
drop procedure SA_DisabledShelf
go

create procedure SA_DisabledShelf
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

		if exists(select ShelfCode from tblsa_pharmacy_shelf where ShelfCode=@TempID)
		begin	
			update tblsa_pharmacy_shelf set 
				Mark_Deleted=@Inactive, 
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP				
			where ShelfCode=@TempID 
					
			set @IsAdd=1
			declare @UpdateData nvarchar(max)=(select top 1 ShelfEn from tblsa_pharmacy_shelf H WHERE H.ShelfCode=@TempID)
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
		set @Msg = 'Shelf name: ' + @TempStr + ' have been restored.'
	end
	else
	begin
		set @Msg='Shelf name: ' + @TempStr + ' have been removed.'
	end

	select @IsAdd, @Msg	
end
go

-------
drop procedure SA_GetShelfByID
go

create procedure SA_GetShelfByID
	@ID int,
	@ClinicID int,
	@isList int
as
begin
	if @ID<>0
	begin
		select top 1			
			ShelfCode,
			ShelfEn,
			ShelfKh,			
			Note,	
			ClinicID,
			Mark_Deleted,
			UserCreate,
			DateCreate,
			UserUpdate,
			DateUpdate
		from tblsa_pharmacy_shelf		
		where ShelfCode=@ID
	end
	else if @ClinicID=0 and @isList=1
	begin
		select distinct
			ShelfCode,
			ShelfEn,
			ClinicEn
		from tblsa_pharmacy_shelf CC		
			LEFT JOIN tblsa_ms_clinic C on CC.ClinicID=C.ClinicID
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
			and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
		order by ClinicEn, ShelfEn
	end
	else if @ClinicID=0 and @isList=2
	begin
		select
			0 as TranID, 			
			'*** All shelf' as ShelfEn,
			'*** All clinics' as ClinicEn
		UNION
		select distinct
			ShelfCode,
			ShelfEn,
			ClinicEn
		from tblsa_pharmacy_shelf CC		
			LEFT JOIN tblsa_ms_clinic C on CC.ClinicID=C.ClinicID
		where (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
			and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
		order by ClinicEn, ShelfEn
	end
	else if @ClinicID<>0 and @isList=1
	begin
		select distinct
			ShelfCode,
			ShelfEn,
			ClinicEn
		from tblsa_pharmacy_shelf CC		
			LEFT JOIN tblsa_ms_clinic C on CC.ClinicID=C.ClinicID
		where CC.ClinicID=@ClinicID
			and (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
			and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
		order by ClinicEn, ShelfEn
	end
	else if @ClinicID<>0 and @isList=2
	begin
		select top 1
			999 as ShelfCode, 
			'*** All shelf' as ShelfEn,
			ClinicEn
		from tblsa_pharmacy_shelf CC		
			LEFT JOIN tblsa_ms_clinic C on CC.ClinicID=C.ClinicID
		where CC.ClinicID=@ClinicID
			and (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
			and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
		UNION
		select distinct
			ShelfCode,
			ShelfEn,
			ClinicEn
		from tblsa_pharmacy_shelf CC		
			LEFT JOIN tblsa_ms_clinic C on CC.ClinicID=C.ClinicID
		where CC.ClinicID=@ClinicID
			and (CC.Mark_Deleted=0 OR CC.Mark_Deleted IS NULL)
			and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
		order by ClinicEn, ShelfEn
	end
	else
	begin
		select
			ShelfCode,
			ShelfEn,
			ShelfKh,
			Note,	
			ClinicEn,
			CC.Mark_Deleted as Inactive,
			U.Name as UserCreate,
			CC.DateCreate,
			V.Name as UserUpdate,
			CC.DateUpdate
		from tblsa_pharmacy_shelf CC	
			LEFT JOIN tblsa_ms_clinic C on CC.ClinicID=C.ClinicID
			LEFT join tblsa_set_userlog U on U.UserNo=CC.UserCreate
			LEFT join tblsa_set_userlog V on V.UserNo=CC.UserUpdate
		where (U.Mark_Deleted=0 OR U.Mark_Deleted IS NULL)
			and (C.Mark_Deleted=0 OR C.Mark_Deleted IS NULL)
		order by CC.Mark_Deleted, ClinicEn, ShelfEn
	end
end
go


-----20200408
drop procedure SA_SaveStockCarts
go

create procedure SA_SaveStockCarts
	@DrugMasterCode int
    ,@DrugCode nvarchar(20)
    ,@Barcode nvarchar(100)
    ,@DrugBrandName nvarchar(max)
    ,@DrugGenericName nvarchar(max)
    ,@DrugForm nvarchar(30)
    ,@Strength nvarchar(50)
    ,@Volume nvarchar(50)
    ,@DrugSpecification nvarchar(50)
    ,@DrugClassification nvarchar(50)
	,@MinSOH float
	,@MaxSOH float
	,@TotalSOH float
	,@TotalValuetoDate float
	,@DrugItemType nvarchar(50) 
    ,@Branch nvarchar(50)    
    ,@User int 
	,@isAdd int output
	,@msg nvarchar(200) output
	,@TDrugCode nvarchar(20) output
as
begin	
	set @Msg = 'Cannot performance this operation while item code is empty.'
	set @isAdd =0
	set @DrugCode=LTRIM(RTRIM(@DrugCode))
	set @Barcode=LTRIM(RTRIM(@Barcode))
	set @DrugBrandName=LTRIM(RTRIM(@DrugBrandName))
	set @DrugGenericName=LTRIM(RTRIM(@DrugGenericName))
	set @DrugForm=LTRIM(RTRIM(@DrugForm))
	set @Strength=LTRIM(RTRIM(@Strength))
	set @Volume=LTRIM(RTRIM(@Volume))
	set @DrugSpecification=LTRIM(RTRIM(@DrugSpecification))
	set @DrugItemType=LTRIM(RTRIM(@DrugItemType))
	set @Branch=LTRIM(RTRIM(@Branch))

	if(len(@DrugCode)>0 and len(@DrugBrandName)>0 and @DrugGenericName>0)
	begin
		if @DrugMasterCode=0
		begin
			set @DrugCode=dbo.SAC_GetMEDAutoNumber(@DrugItemType)		
		end

		set @TDrugCode=@DrugCode

		if not exists(select DrugMasterCode from tblsa_pharmacy_drug_master where DrugCode<>@DrugCode and DrugBrandName=@DrugBrandName and DrugGenericName=@DrugGenericName)
		begin
			if @DrugMasterCode=0
			begin
				insert into tblsa_pharmacy_drug_master(DrugCode, Barcode, DrugBrandName, DrugGenericName, DrugForm, Strength, Volume, DrugSpecification, DrugClassification, MinSOH, MaxSOH, TotalSOH, TotalValueToDate, DrugItemType, Branch, Mark_Deleted, UserCreate, DateCreate)
				select @DrugCode, @Barcode, @DrugBrandName, @DrugGenericName, @DrugForm, @Strength, @Volume, @DrugSpecification, @DrugClassification, @MinSOH, @MaxSOH, @TotalSOH, @TotalValueToDate, @DrugItemType, @Branch, 0, @User, CURRENT_TIMESTAMP
				set @IsAdd=1
				set @Msg= 'Medication name: ' +@DrugBrandName +' (Code: ' +@DrugCode +') has been added to ' +(select top 1 GenericEn from tblsa_pharmacy_generic_name where TranID=@DrugGenericName) +'.'
			end
			else if exists(select DrugMasterCode from tblsa_pharmacy_drug_master where DrugMasterCode=@DrugMasterCode and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
			begin
				update tblsa_pharmacy_drug_master set		
					DrugCode=@DrugCode,
					Barcode=@Barcode,
					DrugBrandName=@DrugBrandName,
					DrugGenericName=@DrugGenericName,
					DrugForm=@DrugForm,
					Strength=@Strength,
					Volume=@Volume,
					DrugSpecification=@DrugSpecification,
					DrugClassification=@DrugClassification,
					MinSOH=@MinSOH, 
					MaxSOH=@MaxSOH, 
					TotalSOH=@TotalSOH, 
					TotalValueToDate=@TotalValueToDate,
					DrugItemType=@DrugItemType,
					Branch=@Branch,
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where DrugMasterCode=@DrugMasterCode 
					and (Mark_Deleted=0 OR Mark_Deleted IS NULL) 				

				set @IsAdd=2
				set @Msg= 'Medication name: ' +@DrugBrandName +' (Code: ' +@DrugCode +') has been updated in ' +(select top 1 GenericEn from tblsa_pharmacy_generic_name where TranID=@DrugGenericName) +'.'
			end
			else if exists(select DrugMasterCode from tblsa_pharmacy_drug_master where DrugMasterCode=@DrugMasterCode)
			begin
				set @Msg = 'Cannot make update this Medication has been removed or deactived from the system.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
	end
	select @IsAdd, @Msg, @TDrugCode
end
go

--select dbo.SAC_GetMEDAutoNumber('Laboratory')

-------------20200414
DROP FUNCTION SAC_GetMEDAutoNumber 
GO

CREATE FUNCTION SAC_GetMEDAutoNumber(
	@DrugItemType NVARCHAR(100)
)RETURNS NVARCHAR(100)
AS
BEGIN
	SET @DrugItemType=LTRIM(RTRIM(@DrugItemType))
	DECLARE @DrugCode NVARCHAR(10)=DBO.SAC_GetDrugCode(@DrugItemType)

	DECLARE @MaxNum NVARCHAR(100)=''
	SET @MaxNum=(SELECT TOP 1 DrugCode FROM tblsa_pharmacy_drug_master WHERE DrugCode like @DrugCode+'%' ORDER BY DrugMasterCode desc)
	
	--SET @MaxNum=ISNULL(MAX(CONVERT(INT, SUBSTRING(DrugCode, 5, 20))), 0) AS DrugCode FROM tblsa_pharmacy_drug_master WHERE SUBSTRING(DrugCode, 0, 4)=@DrugCode

	WHILE PATINDEX('%[^0-9]%', @MaxNum) > 0 SET @MaxNum = REPLACE(@MaxNum, SUBSTRING(@MaxNum, PATINDEX('%[^0-9]%', @MaxNum), 1), '')
	DECLARE @NEXT_INSERT_NUMBER INT = ISNULL(@MaxNum, 0)
	IF @NEXT_INSERT_NUMBER = 0
	BEGIN
		SET @NEXT_INSERT_NUMBER = 1
	END
	ELSE
	BEGIN
		SET @NEXT_INSERT_NUMBER = @NEXT_INSERT_NUMBER + 1
	END

	RETURN @DrugCode+'-'+CONVERT(NVARCHAR(10), @NEXT_INSERT_NUMBER)
END
GO

----------------
DROP PROCEDURE SAC_NEXT_INSERT_NUMBER
GO

CREATE PROCEDURE SAC_NEXT_INSERT_NUMBER
	@DrugItemType NVARCHAR(100)
AS 
BEGIN
	SET @DrugItemType=LTRIM(RTRIM(@DrugItemType))
	SELECT dbo.SAC_GetMEDAutoNumber(@DrugItemType)
END
GO

----------------
DROP FUNCTION SAC_GetDrugCode
GO

CREATE FUNCTION SAC_GetDrugCode(
	@DrugItemType NVARCHAR(100)
)RETURNS NVARCHAR(10)
AS 
BEGIN
	SET @DrugItemType=LTRIM(RTRIM(@DrugItemType))
	DECLARE @DrugCode NVARCHAR(10)=''
	IF @DrugItemType='Pharmacy'
	BEGIN
		SET @DrugCode='MED'
	END
	ELSE IF @DrugItemType='Laboratory'
	BEGIN
		SET @DrugCode='LAB'
	END

	RETURN @DrugCode
END
GO


-------20200703
drop procedure SA_DisableMedication
go

create procedure SA_DisableMedication
	@StrID nvarchar(max),	
	@Inactive bit,
	@User int,
	@IsUpdate int output,
	@Msg nvarchar(max) output
as
begin
	set @IsUpdate=0
	set @Msg='There is no selected medication to perform action.'
	DECLARE @TempStr nvarchar(max)=''

	DECLARE @TblTempID TABLE(ID int)
	INSERT INTO @TblTempID SELECT Name FROM dbo.SA_SplitString(@StrID, ',')

	DECLARE @TempID int
	DECLARE DB_CURSOR CURSOR FOR SELECT ID from @TblTempID
	OPEN DB_CURSOR 
	
	FETCH NEXT FROM DB_CURSOR INTO @TempID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		if exists(select DrugMasterCode from tblsa_pharmacy_drug_master where DrugMasterCode=@TempID)
		begin			
			update tblsa_pharmacy_drug_master set				
				Mark_Deleted=@Inactive,
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP
			where DrugMasterCode=@TempID
			set @IsUpdate=1				
			set @TempStr=@TempStr +(select top 1 DrugBrandName from tblsa_pharmacy_drug_master where DrugMasterCode=@TempID) +', ' 						
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
			set @Msg='Medication: ' + @TempStr + ' has been restored.'	
		end
		else
		begin
			set @Msg='Medication: ' + @TempStr + ' has been removed.'	
		end
	end
	
	select @IsUpdate, @Msg	
end
go


---------20200824
drop procedure SA_GetSupplierForStockCart
go

create procedure SA_GetSupplierForStockCart
	@DrugMasterCode int
as
begin
	SELECT 
		IVRecievedNum AS [InvoiceNumber]
		,Company as SupplierName
		,CONVERT(NVARCHAR, RecievedDate, 107) AS RecievedDate
		,Country as MadeIn 
		,Quantity
		,StockOnHand
		,Quantity-StockOnhand AS Dispensed
		,CONVERT(NVARCHAR, ExpiredDate, 107) AS ExpiredDate
		,DrugMasterCode
		,DD.DrugDetailCode 
		,MS.InvoiceMedicalStockInCode
	FROM tblsa_set_suppliers SS 
		INNER JOIN tblsa_pharmacy_invoice_medical_stockin MS ON SS.CompanyID=MS.SupplierCode
		INNER JOIN tblsa_pharmacy_drug_detail DD ON DD.InvoiceMedicalStockInCode=MS.InvoiceMedicalStockInCode
		INNER JOIN tblsa_ms_location_countries LC ON LC.ID=DD.MadeIn
	WHERE DrugMasterCode=@DrugMasterCode
		AND (MS.Mark_Deleted=0 OR MS.Mark_Deleted IS NULL)
		AND (DD.Mark_Deleted=0 OR DD.Mark_Deleted IS NULL)
	ORDER BY RecievedDate DESC
end
go


----------20200831 @3:05am
drop procedure SA_GetLogoImage
go

create procedure SA_GetLogoImage
	@ImageType nvarchar(max)
as
begin
	select top 1
		ID,
		Photo,
		Ispermanent,
		StartDate,
		EndDate,
		ImageType
	from tblsa_ms_logos
	where ImageType=@ImageType 
end
go

---------20190311
drop procedure SA_SaveLogoImage
go

create procedure SA_SaveLogoImage 
	@ID int,
	@IsChanged bit,
	@Photo varbinary(max),
	@StartDate nvarchar(20),
	@EndDate nvarchar(20),
	@IsPermanent bit,
	@ImageType nvarchar(max),
	@User int,	
	@IsAdd int output,
	@Msg nvarchar(max) output
as 
begin 
	set nocount on
	set @IsAdd = 0
	set @Msg = 'Cannot add upload image.'
	if @IsChanged<>0 
	begin
		set @ImageType=LTRIM(RTRIM(@ImageType))

		if not exists(select ID from tblsa_ms_logos where ImageType=@ImageType and ID<>@ID)
		begin
			if @IsPermanent=0
			begin
				set @StartDate=NULL
				set @EndDate=NULL
			end

			if @ID=0
			begin
				insert into tblsa_ms_logos(Photo, ImageType, StartDate, EndDate, IsPermanent, UserCreate, DateCreate) 
				select @Photo, @ImageType, @StartDate, @EndDate, @IsPermanent, @User, CURRENT_TIMESTAMP				
				set @IsAdd=1
				set @Msg='Image is successfully uploaded.'
			end
			else if exists(select ID from tblsa_ms_logos where ID=@ID)
			begin
				update tblsa_ms_logos set				
					Photo=@Photo,
					ImageType=@ImageType,
					StartDate=@StartDate,
					EndDate=@EndDate,
					IsPermanent=@Ispermanent,
					UserUpdate=@User,
					DateUpdate=CURRENT_TIMESTAMP
				where ID=@ID 
			
				set @IsAdd=2
				set @Msg='Image is successfully updated.'
			end
			else
			begin
				set @Msg = 'Cannot make update due to the code is not found or has been removed.'
			end
		end
		else
		begin
			set @Msg = 'Uploaded image already exists in the system.'
		end
	end
	
	select @IsAdd, @Msg
end
go


-----------20190312
drop procedure SA_RemovePopupImage
go

create procedure SA_RemovePopupImage
	@Code int,	
	@IsRemoved bit,
	@User nvarchar(100),
	@IsDeleted int output,
	@Msg nvarchar(300) output
as
begin
	set @IsDeleted=0
	set @Msg='No image selected.'
	if(@Code>0)
	begin
		if exists(select ID from tblsa_ms_logos where ID=@Code)
		begin
			if @IsRemoved=1
			begin
				set @Msg='Image id ' + CAST(@Code AS nvarchar(10)) + ' has been removed.'					
			end
			else
			begin
				set @Msg='Image id ' + CAST(@Code AS nvarchar(10)) + ' has been restored.'					
			end

			update tblsa_ms_logos set
				Mark_Deleted=@IsRemoved,
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP
			where ID=@Code
			set @IsDeleted=1 
		end
	end

Finished:
	select @IsDeleted, @Msg
end
go