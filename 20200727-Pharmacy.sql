-----------20200723
SA_GetBrandNameByID 0, 'Pharmacy', 2

drop procedure SA_GetBrandGenNameByID 
go

create procedure SA_GetBrandGenNameByID
	@ID int,
	@isList int,
	@Branch nvarchar(50), 
	@DrugItemType nvarchar(50)
as
begin
	if @ID<>0
	begin
		select top 1			
			[DrugMasterCode]
		  ,[DrugCode]
		  ,[Barcode]
		  ,[DrugBrandName]
		  ,[DrugGenericName]
		  ,[DrugForm]
		  ,[TotalValueToDate]
		  ,[TotalSOH]
		  ,[MaxSOH]
		  ,[MinSOH]
		  ,[Strength]
		  ,[Volume]
		  ,[DrugSpecification]
		  ,[ShelfCode]
		  ,[DrugClassification]
		  ,[MainRetailPrice]
		  ,[DrugItemType]
		  ,[Branch]
		  ,[Mark_Deleted]
		  ,[UserCreate]
		  ,[DateCreate]
		  ,[UserUpdate]
		  ,[DateUpdate]
		from tblsa_pharmacy_drug_master	
		where [DrugMasterCode] =@ID
	end
	else if @isList=1
	begin
		select distinct
			[DrugMasterCode],
			DrugMasterCode as Code,
			DrugBrandName as BrandName,
			GenericEn as GenericName,
			Strength,
			FormEn as Form
		from tblsa_pharmacy_drug_master	DM
			inner join tblsa_pharmacy_generic_name GN on DM.DrugGenericName=GN.TranID
			inner join tblsa_pharmacy_drug_form DF on DM.DrugForm=DF.TranID
		where DM.Mark_Deleted=0 or DM.Mark_Deleted is null 
			and DrugItemType=@DrugItemType
		order by DrugBrandName	
	end
	else if @isList=2
	begin
		select distinct
			[DrugMasterCode],
			DrugMasterCode as Code,
			GenericEn as GenericName,
			DrugBrandName as BrandName,
			Strength,
			FormEn as Form
		from tblsa_pharmacy_drug_master	DM
			inner join tblsa_pharmacy_generic_name GN on DM.DrugGenericName=GN.TranID
			inner join tblsa_pharmacy_drug_form DF on DM.DrugForm=DF.TranID
		where DM.Mark_Deleted=0 or DM.Mark_Deleted is null 
			and DrugItemType=@DrugItemType
		order by GenericEn, DrugBrandName
	end
	else if @isList=3
	begin
		select distinct
			DM.DrugMasterCode as MasterCode
			,DD.DrugDetailCode as Code
			,DrugBrandName as BrandName
			,GenericEn as GenericName
			,Strength
			,FormEn as Form
			,Country as MadeIn 
			,CONVERT(NVARCHAR, ExpiredDate, 107) AS ExpiredDate
			,RealCost 
			,dbo.SA_GetMedAvgCost(DM.DrugMasterCode) as AvgCost
			,RetailCost
			,DD.StockOnHand
		from tblsa_pharmacy_drug_master	DM
			inner join tblsa_pharmacy_drug_detail DD on DM.DrugMasterCode=DD.DrugMasterCode
			inner join tblsa_pharmacy_generic_name GN on DM.DrugGenericName=GN.TranID
			inner join tblsa_pharmacy_drug_form DF on DM.DrugForm=DF.TranID
			INNER JOIN tblsa_ms_location_countries LC ON LC.ID=DD.MadeIn
		where (DM.Mark_Deleted=0 or DM.Mark_Deleted is null)
			and (DD.Mark_Deleted=0 or DD.Mark_Deleted is null)
			and DD.StockOnHand>0
			and DrugItemType=@DrugItemType
		order by BrandName, ExpiredDate
	end
	else if @isList=4
	begin
		select distinct
			DM.DrugMasterCode as MasterCode
			,DD.DrugDetailCode as Code
			,GenericEn as GenericName
			,DrugBrandName as BrandName
			,Strength
			,FormEn as Form
			,Country as MadeIn 
			,CONVERT(NVARCHAR, ExpiredDate, 107) AS ExpiredDate
			,RealCost 
			,dbo.SA_GetMedAvgCost(DM.DrugMasterCode) as AvgCost
			,RetailCost
			,DD.StockOnHand
		from tblsa_pharmacy_drug_master	DM
			inner join tblsa_pharmacy_drug_detail DD on DM.DrugMasterCode=DD.DrugMasterCode
			inner join tblsa_pharmacy_generic_name GN on DM.DrugGenericName=GN.TranID
			inner join tblsa_pharmacy_drug_form DF on DM.DrugForm=DF.TranID
			INNER JOIN tblsa_ms_location_countries LC ON LC.ID=DD.MadeIn
		where (DM.Mark_Deleted=0 or DM.Mark_Deleted is null)
			and (DD.Mark_Deleted=0 or DD.Mark_Deleted is null)
			and DD.StockOnHand>0
			and DrugItemType=@DrugItemType
		order by GenericEn, ExpiredDate
	end
end
go


----------20200827
DROP FUNCTION SA_GetMedAvgCost
GO

CREATE FUNCTION SA_GetMedAvgCost(
	@DrugMasterCode int
)RETURNS float
AS
BEGIN
	declare @AvgCost float=0
	set @AvgCost=(SELECT AVG(DD.RealCost) as AvgCost
				FROM tblsa_pharmacy_drug_master DM
					INNER JOIN tblsa_pharmacy_drug_detail DD on DM.DrugMasterCode=DD.DrugMasterCode
				WHERE (DM.Mark_Deleted=0 or DM.Mark_Deleted is null)
					and (DD.Mark_Deleted=0 or DD.Mark_Deleted is null)
					and DD.StockOnHand>0
					and DD.DrugMasterCode=@DrugMasterCode
				GROUP BY DM.DrugMasterCode)
	RETURN @AvgCost
END
Go

----------------------
drop procedure SA_GetDrugMasterList
go

create procedure SA_GetDrugMasterList
	@DrugMasterCode int,
	@MedCode nvarchar(20),
	@DrugItemType nvarchar(100)
as 
begin
	if @DrugMasterCode<>0
	begin
		select top 1
			DM.[DrugMasterCode]
			,[DrugCode]
			,[Barcode]
			,[DrugBrandName]
			,[DrugGenericName]
			,[DrugForm]
			,[Strength]
			,[Volume]
			,[DrugSpecification]
			,[DrugClassification]
			,TotalSOH
			,MinSOH
			,TotalValueToDate
			,MaxSOH
			,FormEn as [Form]
			,ISNULL(StockOnHand, 0) as StockOnHand
			,ISNULL(RealCost, 0) as RealCost
			,ISNULL(RetailCost, 0) as RetailCost
			,MadeIn
			,CONVERT(NVARCHAR, ExpiredDate, 107) AS ExpiredDate
			--,[DrugItemType]
			--,[Branch]						
		from tblsa_pharmacy_drug_master DM
			left join tblsa_pharmacy_drug_form DF on DM.DrugForm=DF.TranID
			left join tblsa_pharmacy_drug_detail DD on DM.DrugMasterCode=DD.DrugMasterCode
		where DM.DrugMasterCode=@DrugMasterCode
			and (DM.Mark_Deleted=0 or DM.Mark_Deleted is null)
	end
	else if @DrugMasterCode=0 and len(@MedCode)>0
	begin
		select top 1
			[DrugMasterCode]
			,[DrugCode]
			,[Barcode]
			,[DrugBrandName]
			,[DrugGenericName]
			,[DrugForm]
			,[Strength]
			,[Volume]
			,[DrugSpecification]
			,[DrugClassification]
			,TotalSOH
			,MinSOH
			,TotalValueToDate
			,MaxSOH
			--,[DrugItemType]
			--,[Branch]						
		from tblsa_pharmacy_drug_master 
		where [DrugCode]=@MedCode
			and DrugItemType=@DrugItemType
			and (Mark_Deleted=0 or Mark_Deleted is null)
	end
	else if len(@DrugItemType)<>0
	begin 
		select distinct 
			[DrugMasterCode]
			,[DrugCode] as Code
			,[Barcode]
			,[DrugBrandName] as [BrandName]
			,GenericEn as [GenericName]
			,FormEn as [Form]
			,[Strength]
			,[Volume]
			--,[DrugSpecification]
			,ClassificationEn as [Classification]
			,TotalSOH
			,MinSOH
			--,[DrugItemType]
			--,[Branch]
			,DM.[Mark_Deleted] as Inactive
		from tblsa_pharmacy_drug_master DM
			left join tblsa_pharmacy_generic_name GN on DM.DrugGenericName=GN.TranID
			left join tblsa_pharmacy_drug_form DF on DM.DrugForm=DF.TranID
			left join tblsa_pharmacy_drug_classification DC on DM.DrugClassification=DC.TranID
		where DrugItemType=@DrugItemType			
		order by DrugBrandName
	end
	else
	begin
		select distinct 
			[DrugMasterCode]
			,[DrugCode] as Code
			,[Barcode]
			,[DrugBrandName] as [BrandName]
			,GenericEn as [GenericName]
			,FormEn as [Form]
			,[Strength]
			,[Volume]
			--,[DrugSpecification]
			,ClassificationEn as [Classification]
			,TotalSOH
			,MinSOH
			--,[DrugItemType]
			--,[Branch]
			,DM.[Mark_Deleted] as Inactive
		from tblsa_pharmacy_drug_master DM
			left join tblsa_pharmacy_generic_name GN on DM.DrugGenericName=GN.TranID
			left join tblsa_pharmacy_drug_form DF on DM.DrugForm=DF.TranID
			left join tblsa_pharmacy_drug_classification DC on DM.DrugClassification=DC.TranID
		order by DrugBrandName
	end
end
go


------20200810
DROP FUNCTION SAC_AutoINVReceivedNum
GO

CREATE FUNCTION SAC_AutoINVReceivedNum(
	@Branch nvarchar(30)
)RETURNS NVARCHAR(40)
AS
BEGIN
	declare @InvoiceNumber nvarchar(20)=''
	set @InvoiceNumber = ISNULL((select top 1 IVRecievedNum from tblsa_pharmacy_invoice_medical_stockin where IVRecievedNum like 'IV' + CONVERT(NVARCHAR(2), RIGHT(YEAR(GETDATE()), 2)) + '%' and Branch=@Branch order by IVRecievedNum desc), 0)
	set @InvoiceNumber=RIGHT(@InvoiceNumber, 6)+1
	set @InvoiceNumber='IV' +CONVERT(NVARCHAR(2), RIGHT(YEAR(GETDATE()), 2)) +REPLICATE('0', 6-LEN(RTRIM(@InvoiceNumber))) +RTRIM(@InvoiceNumber)

	RETURN @InvoiceNumber
END
Go

Select dbo.SAC_AutoINVReceivedNum('')


---------20200811
drop procedure SA_SaveMedicationStockin
go

create procedure SA_SaveMedicationStockin
	@InvoiceMedicalStockInCode int
	,@Warehouse int
    ,@SupplierCode int
    ,@IVRecievedNum nvarchar(20)
	,@RefInvoiceNo nvarchar(50)
    ,@RecievedDate datetime
    ,@RecievedBy nvarchar(100)
    ,@Remark nvarchar(max)
	,@DrugDetailCode int
	,@DrugMasterCode int
	,@MadeIn int
	,@RealCost float
	,@Markup float
	,@RetailCost float
	,@Quantity float
	,@BeforeAdjSOH float
	,@StockOnHand float
	,@ExpiredDate date
	,@LotNum nvarchar(10)
	,@DrugMasterCodeBeforeUpdate int
	,@BeforeUpdateQty float
	,@IsAdjustment bit
	,@AdjustmentReason nvarchar(max)
    ,@Branch nvarchar(20)
	,@User int 
	,@isAdd int output
	,@msg nvarchar(200) output
	,@TMIVStockInCode int output
	,@TMIVRecievedNum nvarchar(20) output
as
begin	
	set @Msg = 'Cannot performance this operation while item code is empty.'
	set @isAdd=0
	set @TMIVStockInCode=0
	set @TMIVRecievedNum=''
	
	BEGIN TRY
		BEGIN TRANSACTION SaveMedication;
			set @IVRecievedNum=LTRIM(RTRIM(@IVRecievedNum))
			set @RefInvoiceNo=LTRIM(RTRIM(@RefInvoiceNo))
			set @RecievedBy=LTRIM(RTRIM(@RecievedBy))
			set @Remark=LTRIM(RTRIM(@Remark))
			set @Branch=LTRIM(RTRIM(@Branch))
	
			if(@Warehouse>0 and @SupplierCode>0)
			begin
				if not exists(select InvoiceMedicalStockInCode from tblsa_pharmacy_invoice_medical_stockin where SupplierCode=@SupplierCode and CAST(RecievedDate AS DATE)=CAST(@RecievedDate as DATE) and IVRecievedNum=@IVRecievedNum and InvoiceMedicalStockInCode<>@InvoiceMedicalStockInCode)
				begin
					if @InvoiceMedicalStockInCode=0
					begin
						if len(@IVRecievedNum)=0
						begin
							set @IVRecievedNum=dbo.SAC_AutoINVReceivedNum(@Branch)
						end
				
						--Insert new invoice info in stock-in
						insert into tblsa_pharmacy_invoice_medical_stockin(SupplierCode, IVRecievedNum, RefInvoiceNo, RecievedDate, RecievedBy, Remark, Warehouse, Branch, Mark_Deleted, UserCreate, DateCreate)
						select @SupplierCode, @IVRecievedNum, @RefInvoiceNo, @RecievedDate, @RecievedBy, @Remark, @Warehouse, @Branch, 0, @User, CURRENT_TIMESTAMP
						set @IsAdd=1
						--set @Msg= 'Invoice No: ' +@IVRecievedNum +' has been created.'
					end
					else if exists(select InvoiceMedicalStockInCode from tblsa_pharmacy_invoice_medical_stockin where InvoiceMedicalStockInCode=@InvoiceMedicalStockInCode and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
					begin
						--Update invoice info in the stock-in
						update tblsa_pharmacy_invoice_medical_stockin set		
							SupplierCode=@SupplierCode,
							IVRecievedNum=@IVRecievedNum,
							RefInvoiceNo=@RefInvoiceNo,
							RecievedDate=@RecievedDate,
							RecievedBy=@RecievedBy,
							Remark=@Remark,
							Warehouse=@Warehouse,
							Branch=@Branch,
							UserUpdate=@User,
							DateUpdate=CURRENT_TIMESTAMP
						where InvoiceMedicalStockInCode=@InvoiceMedicalStockInCode 
							and (Mark_Deleted=0 OR Mark_Deleted IS NULL) 				

						set @IsAdd=2
						--set @Msg= 'Invoice No: ' +@IVRecievedNum +' has been updated.'
					end
					--else if exists(select InvoiceMedicalStockInCode from tblsa_pharmacy_invoice_medical_stockin where InvoiceMedicalStockInCode=@InvoiceMedicalStockInCode)
					--begin
					--	set @Msg = 'Cannot make update this! Medication stock-in has been removed or deactived from the system.'
					--end
					--else
					--begin
					--	set @Msg = 'Cannot make update due to the code is not found or has been removed.'
					--end
				end

				set @TMIVRecievedNum=@IVRecievedNum
				declare @TempInvoiceMedicalStockInCode int=(select top 1 InvoiceMedicalStockInCode 
															from tblsa_pharmacy_invoice_medical_stockin 
															where IVRecievedNum=@IVRecievedNum
																and Branch=@Branch
																and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
				set @TMIVStockInCode=@TempInvoiceMedicalStockInCode
				if not exists(Select DrugDetailCode from tblsa_pharmacy_drug_detail where InvoiceMedicalStockInCode=@TempInvoiceMedicalStockInCode and DrugMasterCode=@DrugMasterCode and DrugDetailCode<>@DrugDetailCode)
				begin
					if @DrugDetailCode=0
					begin
						--Insert new medication to stock in
						insert into tblsa_pharmacy_drug_detail(InvoiceMedicalStockInCode, DrugMasterCode, MadeIn, RealCost, Markup, RetailCost, Quantity, StockOnHand, ExpiredDate, LotNum, Branch, Warehouse, IsAdjustment, Mark_Deleted, UserCreate, DateCreate)
						select @TempInvoiceMedicalStockInCode, @DrugMasterCode, @MadeIn, @RealCost, @Markup, @RetailCost, @Quantity, @StockOnHand, @ExpiredDate, @LotNum, @Branch, @Warehouse, @IsAdjustment, 0, @User, CURRENT_TIMESTAMP
						set @IsAdd=3
						set @Msg= (select top 1 'Brand name: ' +DrugBrandName +' saved to Invoice No: ' +@IVRecievedNum +'.' from tblsa_pharmacy_drug_master where DrugMasterCode=@DrugMasterCode)
					end
					else if exists(select DrugDetailCode from tblsa_pharmacy_drug_detail where DrugDetailCode=@DrugDetailCode and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
					begin
						--Update medication in the stock in
						update tblsa_pharmacy_drug_detail set
							InvoiceMedicalStockInCode=@TempInvoiceMedicalStockInCode ,
							DrugMasterCode=@DrugMasterCode,
							MadeIn=@MadeIn,
							RealCost=@RealCost,
							Markup=@Markup,
							RetailCost=@RetailCost,
							Quantity=@Quantity,
							StockOnHand=@StockOnHand,
							ExpiredDate=@ExpiredDate,
							LotNum=@LotNum,
							Branch=@Branch,
							Warehouse=@Warehouse,
							IsAdjustment=@IsAdjustment,
							UserUpdate=@User,
							DateUpdate=CURRENT_TIMESTAMP
						where DrugDetailCode=@DrugDetailCode 
							and (Mark_Deleted=0 OR Mark_Deleted IS NULL)
						set @IsAdd=4
						set @Msg= (select top 1 'Brand name: ' +DrugBrandName +' updated in the Invoice No: ' +@IVRecievedNum +'.' from tblsa_pharmacy_drug_master where DrugMasterCode=@DrugMasterCode)
					end
					else if exists(select DrugDetailCode from tblsa_pharmacy_drug_detail where DrugDetailCode=@DrugDetailCode)
					begin
						set @Msg = 'Cannot make update this! Medication stock-in has been removed or deactived from the system.'
					end
					else
					begin
						set @Msg = 'Cannot make update due to the code is not found or has been removed.'
					end

					--Operation In Stock Master and Stock Detail
					if @DrugDetailCode=0 --Saved Mode 
					begin
						update tblsa_pharmacy_drug_master set
							TotalSOH=TotalSOH+@Quantity,
							TotalValueToDate=TotalValueToDate+@Quantity
						where DrugMasterCode=@DrugMasterCode

						declare @TmpDrugDetailCode float=0
						set @TmpDrugDetailCode=(SELECT TOP 1 DD.DrugDetailCode
												FROM tblsa_pharmacy_drug_master DM
													INNER JOIN tblsa_pharmacy_drug_detail DD ON DM.drugMasterCode = DD.drugMasterCode
												WHERE DM.DrugItemType='Pharmacy'
													AND (DM.Mark_Deleted=0 OR DM.Mark_Deleted IS NULL)
													AND (DD.Mark_Deleted=0 OR DD.Mark_Deleted IS NULL)
												ORDER BY DrugDetailCode DESC)
						declare @TmpMainCampusSOH float=0
						set @TmpMainCampusSOH=(SELECT SUM(DD.StockOnHand) AS StockOnHand
												FROM dbo.tblsa_pharmacy_drug_master DM
													INNER JOIN dbo.tblsa_pharmacy_drug_detail DD ON DM.drugMasterCode = DD.drugMasterCode
												WHERE DM.DrugItemType='Pharmacy'
													AND (DM.Mark_Deleted=0 OR DM.Mark_Deleted IS NULL)
													AND (DD.Mark_Deleted=0 OR DD.Mark_Deleted IS NULL)
													AND DD.Warehouse=@Warehouse
													AND DM.DrugMasterCode=@DrugMasterCode
												GROUP BY DM.drugMasterCode)
						declare @TmpDrugMasterSOH float=0
						set @TmpDrugMasterSOH=(SELECT top 1 TotalSOH from tblsa_pharmacy_drug_master WHERE DrugMasterCode=@DrugMasterCode)

						--Insert to tblsa_pharmacy_stock_transaction
						INSERT INTO tblsa_pharmacy_stock_transaction(
							[DrugDetailCode]
							,[TransDate]
							,[MainBegQtySOH]
							,[MainCampusBegQtySOH]
							,[DetailBegQtySOH]
							,[QtyReceived]
							,[DetailEndQtySOH]
							,[MainCampusEndQtySOH]
							,[MainEndQtySOH]
							,[Branch]
							,[Remark]
							,[DisWarehouse]
							,[UserCreate]
							,[DateCreate])
						VALUES(@TmpDrugDetailCode
							,CURRENT_TIMESTAMP
							,@TmpDrugMasterSOH-@Quantity
							,@TmpMainCampusSOH-@Quantity
							,0
							,@Quantity
							,@Quantity
							,@TmpMainCampusSOH
							,@TmpDrugMasterSOH
							,@Branch
							,'IV Recieve No: ' + @IVRecievedNum + ' : ' + @Remark + ' - Added'
							,@Warehouse
							,@User
							,CURRENT_TIMESTAMP)
					end --end save mode
					else --Update mode
					begin
						update tblsa_pharmacy_drug_master set
							TotalSOH=TotalSOH-@BeforeUpdateQty,
							TotalValueToDate=TotalValueToDate-@BeforeUpdateQty
						where DrugMasterCode=@DrugMasterCodeBeforeUpdate

						update tblsa_pharmacy_drug_master set
							TotalSOH=TotalSOH+@Quantity,
							TotalValueToDate=TotalValueToDate+@Quantity
						where DrugMasterCode=@DrugMasterCode

						if @BeforeUpdateQty<>@Quantity
						begin
							declare @TmpDrugDetailSOH float=(select top 1 StockOnHand from tblsa_pharmacy_drug_detail where DrugDetailCode=@DrugDetailCode order by StockOnHand desc)
							set @TmpDrugMasterSOH=(select top 1 TotalSOH from tblsa_pharmacy_drug_master where DrugMasterCode=@DrugMasterCode order by TotalSOH desc)
							set @TmpMainCampusSOH=(SELECT SUM(DD.StockOnHand) AS StockOnHand
												FROM dbo.tblsa_pharmacy_drug_master DM
													INNER JOIN dbo.tblsa_pharmacy_drug_detail DD ON DM.drugMasterCode = DD.drugMasterCode
												WHERE DM.DrugItemType='Pharmacy'
													AND (DM.Mark_Deleted=0 OR DM.Mark_Deleted IS NULL)
													AND (DD.Mark_Deleted=0 OR DD.Mark_Deleted IS NULL)
													AND DD.Warehouse=@Warehouse
													AND DM.DrugMasterCode=@DrugMasterCode
												GROUP BY DM.drugMasterCode)
							--========Insert to tblsa_pharmacy_stock_transaction=========================
							INSERT INTO tblsa_pharmacy_stock_transaction(
								[DrugDetailCode]
								,[TransDate]
								,[MainBegQtySOH]
								,[MainCampusBegQtySOH]
								,[DetailBegQtySOH]
								,[QtyReceived]
								,[DetailEndQtySOH]
								,[MainCampusEndQtySOH]
								,[MainEndQtySOH]
								,[Branch]
								,[Remark]
								,[DisWarehouse]
								,[UserCreate]
								,[DateCreate])
							VALUES(@DrugDetailCode
								,CURRENT_TIMESTAMP
								,@TmpDrugMasterSOH-(@Quantity-@BeforeUpdateQty)
								,@TmpMainCampusSOH-(@Quantity-@BeforeUpdateQty)
								,@TmpDrugDetailSOH+(@BeforeUpdateQty-@Quantity)
								,@Quantity-@BeforeUpdateQty
								,@TmpDrugDetailSOH
								,@TmpMainCampusSOH
								,@TmpDrugMasterSOH
								,@Branch
								,'IV Recieve No: ' + @IVRecievedNum + ' : Stock adjusted-Reason : ' +@AdjustmentReason
								,@Warehouse
								,@User
								,CURRENT_TIMESTAMP)
						end
					end --end update mode
					--=====Get Top Sale Price to update into tblsa_pharmacy_drug_master======================
					declare @TopSalePrice float=ISNULL((SELECT MAX(RetailCost) AS RetailCost FROM tblsa_pharmacy_drug_detail Where (Mark_Deleted=0 OR Mark_Deleted IS NULL) AND StockOnHand>0 and DrugMasterCode=@DrugMasterCode),0)
					if @TopSalePrice=0
					begin
						set @TopSalePrice=(SELECT top 1 RetailCost FROM tblsa_pharmacy_drug_detail WHERE DrugMasterCode=@DrugMasterCode order by RetailCost desc)
					end
					--==Update Top Sale Price to Table tblsa_pharmacy_drug_master========
					UPDATE tblsa_pharmacy_drug_master SET 
						MainRetailPrice= @TopSalePrice
					WHERE DrugMasterCode=DrugMasterCode

					--=============Record to tblsa_pharmacy_stock_transaction========
					If @BeforeUpdateQty>0 
					begin
						If @BeforeUpdateQty<>@Quantity  --Adjustment only record when Quantity has been changed
						begin
							INSERT INTO tblsa_pharmacy_stock_adjustment(
								[DrugDetailCode]
								,[InvoiceMedicalStockInCode]
								,[DrugMasterCode]
								,[DateAdjustment]
								,[BeforeAdjSOH]
								,[AfterAdjSOH]
								,[BeforeAdjQty]
								,[AfterAdjQty]
								,[AdjReason]
								,[QtyAdj]
								,[IsAdjustmentIn]
								,[Warehouse]
								,[Mark_Deleted]
								,[UserCreate]
								,[DateCreate])
							VALUES(@DrugDetailCode
								,@InvoiceMedicalStockInCode
								,@DrugMasterCode
								,CURRENT_TIMESTAMP
								,@BeforeAdjSOH
								,@StockOnHand
								,@BeforeUpdateQty
								,@Quantity
								,@AdjustmentReason
								,@Quantity-@BeforeUpdateQty
								,(CASE WHEN @BeforeUpdateQty<@Quantity THEN 1 ELSE 0 END)
								,@Warehouse
								,0
								,@User
								,CURRENT_TIMESTAMP)
						end
					end
				end
				else
				begin
					set @isAdd=0
					set @Msg = 'Incompleted add! This medication already exists in the list.'
				end
			end
		COMMIT TRANSACTION SaveMedication;  
	END TRY
	BEGIN CATCH
		IF (@@TRANCOUNT>0)
		BEGIN
			ROLLBACK TRANSACTION SaveMedication
			PRINT 'Error detected, all changes reversed'
		END 
	END CATCH

	SELECT @IsAdd, @Msg, @TMIVStockInCode, @TMIVRecievedNum
end
go

SA_GetInvoiceStockIn 'IV200000001'

-------20200811
drop procedure SA_GetInvoiceStockIn-- 'IV200000001'
go

create procedure SA_GetInvoiceStockIn
	@IVRecievedNum nvarchar(20)
as 
begin
	select distinct
		[InvoiceMedicalStockInCode]
		,[SupplierCode]
		,[IVRecievedNum]
		,[RefInvoiceNo]
		,[RecievedDate]
		,[RecievedBy]
		,[Remark]
		,[Warehouse]
		,[Branch]
		,[Campus]
		,[TransferFromCampus]
		,[SalePriceSetting]
		,[Mark_Deleted]
		,[UserCreate]
		,[DateCreate]
		,[UserUpdate]
		,[DateUpdate]
	from tblsa_pharmacy_invoice_medical_stockin
	where IVRecievedNum=@IVRecievedNum
		and (Mark_Deleted=0 or Mark_Deleted IS NULL)
end
go

---------20200812
drop procedure SA_GetDrugDetailInfo-- 'IV200000001'
go

create procedure SA_GetDrugDetailInfo
	@DrugDetailCode int,
	@InvoiceMedicalStockInCode int
as 
begin
	if @DrugDetailCode<>0 
	begin
		SELECT TOP 1 
			DrugDetailCode
			,InvoiceMedicalStockInCode
			,DD.DrugMasterCode
			,MadeIn
			,Strength
			,FormEn 
			,RealCost
			,Markup
			,RetailCost
			,Quantity
			,StockOnHand
			,ExpiredDate
			,LotNum
			,DD.Branch
			,IsAdjustment
			,Warehouse
			,TrasferFromdrugDetailCode
		FROM tblsa_pharmacy_drug_detail DD
			inner join tblsa_pharmacy_drug_master DM on DD.DrugMasterCode=DM.DrugMasterCode
			INNER JOIN tblsa_pharmacy_drug_form DF ON DF.TranID=DM.DrugForm
		Where DrugDetailCode=@DrugDetailCode
			and (DD.Mark_Deleted=0 or DD.Mark_Deleted IS NULL)
	end
	else if @InvoiceMedicalStockInCode<>0
	begin
		SELECT distinct
			DrugDetailCode
			,InvoiceMedicalStockInCode
			,DrugBrandName AS [BrandName]
			,GenericEn AS [GenericName]
			,Country as MadeIn 
			,CONVERT(NVARCHAR, ExpiredDate, 107) AS ExpiredDate
			,Strength
			,FormEn as Form
			,RealCost 
			,RetailCost
			,Quantity
			,DD.DrugMasterCode
			,RetailCost * Quantity AS LineTotal
			,DD.StockOnHand
			,CASE 
				WHEN IsAdjustment = 'True'
					THEN 'Adjusted'
				ELSE ''
			END AS StockAdjusted
		FROM tblsa_pharmacy_drug_master DM
			INNER JOIN tblsa_pharmacy_drug_detail DD ON DM.DrugMasterCode=DD.DrugMasterCode
			INNER JOIN tblsa_pharmacy_drug_form DF ON DF.TranID=DM.DrugForm
			INNER JOIN tblsa_pharmacy_generic_name GN on GN.TranID=DM.DrugGenericName
			INNER JOIN tblsa_ms_location_countries LC ON LC.ID=DD.MadeIn
		WHERE (DD.Mark_Deleted=0 OR DD.Mark_Deleted IS NULL)
			AND InvoiceMedicalStockInCode=@InvoiceMedicalStockInCode
		ORDER BY DM.DrugBrandName
	end
end
go


------------20200815
drop procedure SA_RemoveMedicationStockIn
go

create procedure SA_RemoveMedicationStockIn
	@DrugDetailCode int,
	@Branch nvarchar(50),
	@User int,
	@IsUpdate int output,
	@Msg nvarchar(max) output
as
begin
	set @IsUpdate=0
	set @Msg='There is no selected medication stock-in to perform action.'
	declare @TempStr nvarchar(max)=''
	
	BEGIN TRY
		BEGIN TRANSACTION RemoveMedication;
		if exists(select DrugDetailCode from tblsa_pharmacy_drug_detail where DrugDetailCode=@DrugDetailCode)
		begin			
			update tblsa_pharmacy_drug_detail set				
				Mark_Deleted=1,
				UserUpdate=@User,
				DateUpdate=CURRENT_TIMESTAMP
			where DrugDetailCode=@DrugDetailCode

			declare @DrugMasterCode int=0
			declare @Quantity float=0
			declare @IVRecievedNum nvarchar(30)=''
			declare @Warehouse int=0
			declare @Remark nvarchar(max)=''

			select @DrugMasterCode=DrugMasterCode,
				@Quantity=Quantity,
				@IVRecievedNum=IVRecievedNum,
				@Warehouse=DD.Warehouse,
				@Remark=Remark
			from tblsa_pharmacy_drug_detail DD
				inner join tblsa_pharmacy_invoice_medical_stockin MS on DD.InvoiceMedicalStockInCode=MS.InvoiceMedicalStockInCode
			where DrugDetailCode=@DrugDetailCode
				and (DD.Mark_Deleted=0 OR DD.Mark_Deleted IS NULL)

			--=======UPDATE tblsa_pharmacy_drug_master TO TABLE========
			UPDATE tblsa_pharmacy_drug_master SET 
				TotalValueTodate=TotalValueTodate-@Quantity,
				TotalSOH=TotalSOH-@Quantity 
			Where DrugMasterCode=@DrugMasterCode
                
			declare @TmpMainCampusSOH float=0
			set @TmpMainCampusSOH=(SELECT SUM(DD.StockOnHand) AS StockOnHand
									FROM dbo.tblsa_pharmacy_drug_master DM
										INNER JOIN dbo.tblsa_pharmacy_drug_detail DD ON DM.drugMasterCode = DD.drugMasterCode
									WHERE DM.DrugItemType='Pharmacy'
										AND (DM.Mark_Deleted=0 OR DM.Mark_Deleted IS NULL)
										AND (DD.Mark_Deleted=0 OR DD.Mark_Deleted IS NULL)
										AND DD.Warehouse=@Warehouse
										AND DD.DrugMasterCode=@DrugMasterCode
									GROUP BY DM.DrugMasterCode)
			declare @TmpDrugMasterSOH float=0
			set @TmpDrugMasterSOH=(SELECT top 1 TotalSOH from tblsa_pharmacy_drug_master WHERE DrugMasterCode=@DrugMasterCode order by TotalSOH desc)

			--Insert to tblsa_pharmacy_stock_transaction=========================
			INSERT INTO tblsa_pharmacy_stock_transaction(
				[DrugDetailCode]
				,[TransDate]
				,[MainBegQtySOH]
				,[MainCampusBegQtySOH]
				,[DetailBegQtySOH]
				,[QtyReceived]
				,[DetailEndQtySOH]
				,[MainCampusEndQtySOH]
				,[MainEndQtySOH]
				,[Branch]
				,[Remark]
				,[DisWarehouse]
				,[UserCreate]
				,[DateCreate])
			VALUES(@DrugDetailCode
				,CURRENT_TIMESTAMP
				,@TmpDrugMasterSOH-@Quantity
				,@TmpMainCampusSOH-@Quantity
				,@Quantity
				,@Quantity
				,0
				,@TmpMainCampusSOH
				,@TmpDrugMasterSOH
				,@Branch
				,'IV Recieve No: ' + @IVRecievedNum + ' : Stock adjusted-Reason : ' +@Remark +' - Deleted'
				,@Warehouse
				,@User
				,CURRENT_TIMESTAMP)
			set @IsUpdate=1				
			set @Msg='Medication stock-in: ' + @TempStr + ' has been removed.'
			set @TempStr=(select top 1 DrugBrandName from tblsa_pharmacy_drug_master where DrugMasterCode=@DrugMasterCode) 						
		end
		COMMIT TRANSACTION RemoveMedication;  
	END TRY
	BEGIN CATCH
		IF (@@TRANCOUNT>0)
		BEGIN
			ROLLBACK TRANSACTION RemoveMedication
			PRINT 'Error detected, all changes reversed'
		END 
	END CATCH

	select @IsUpdate, @Msg	
end
go


--------20200825
drop procedure SA_UpdateMedicationExpiredDate
go

create procedure SA_UpdateMedicationExpiredDate
	@DrugDetailCode int
	,@BrandName nvarchar(max)
	,@ExpiredDate datetime
    ,@User int 
	,@IsUpdate int output
	,@msg nvarchar(200) output
as
begin	
	set @Msg = 'Cannot performance this operation while item code is empty.'
	set @IsUpdate =0

	if(@DrugDetailCode>0)
	begin
		update tblsa_pharmacy_drug_detail set		
			ExpiredDate=@ExpiredDate,
			UserUpdate=@User,
			DateUpdate=CURRENT_TIMESTAMP
		where DrugDetailCode=@DrugDetailCode 
		
		set @IsUpdate=1
		set @Msg= 'Medication: '+@BrandName +' has been updated the expired date: ' +CONVERT(NVARCHAR, @ExpiredDate, 107)+'.'
	end
	select @IsUpdate, @Msg
end
go


---------20200828
drop procedure SA_SearchOptDispensary
go

create procedure SA_SearchOptDispensary
	@Opt nvarchar(100)
as
begin
	select
		ID,
		SearchOption
	from tblsa_ms_pharmacy_search_option_dispensary
	where Opt=@Opt
	order by ID
end
go

----------20200828

drop procedure SA_SearchPatientOption
go

create procedure SA_SearchPatientOption
	@StartDate nvarchar(30),
	@EndDate nvarchar(30),
	@PatientCode nvarchar(30),
	@PatientName nvarchar(max),
	@DOB nvarchar(30),
	@Phone nvarchar(max)
as
begin
	if len(@StartDate)>0 and len(@EndDate)>0
	begin
		if len(@PatientCode)>0
		begin
			SELECT 
				*
			FROM vSA_LoadPatientSearch
			WHERE CAST(RegistrationDate as DATE) between CAST(@StartDate as DATE) and CAST(@EndDate as DATE)
				and PatientCode=@PatientCode
		end
		else
		begin
			SELECT 
				*
			FROM vSA_LoadPatientSearch
			WHERE CAST(RegistrationDate as DATE) between CAST(@StartDate as DATE) and CAST(@EndDate as DATE)
		end
	end
	else
	begin
		if len(@PatientCode)>0
		begin
			SELECT 
				*
			FROM vSA_LoadPatientSearch
			WHERE PatientCode=@PatientCode
		end
		else
		begin
			SELECT 
				*
			FROM vSA_LoadPatientSearch
		end
	end
end
go

---------------20200901
drop procedure SA_GetMedicationDispensary
go

create procedure SA_GetMedicationDispensary
	@PatientCode nvarchar(20),
	@Branch nvarchar(50)
as
begin
	SELECT
		*
	FROM tblsa_pharmacy_medication_dispensary
	Where Branch=@Branch
		and PatientCode=@PatientCode
	ORDER BY MedicationDispensaryCode DESC
end
go

---------------20200901
drop procedure SA_GetMedicationDispensaryDetail
go

create procedure SA_GetMedicationDispensaryDetail
	@PatientCode nvarchar(20)
as
begin
	SELECT 
		MedicationDispensaryDetailCode
		,MS.MedicationdiSpensaryCode
		,DrugBrandName AS [Brand Name]
		,DrugGenericName AS [Generic Name]
		,MadeIn 
		,DM.Strength
		,FormEn as Form
		,convert(NVARCHAR, ExpiredDate, 107) AS ExpiredDate
		,MDD.RealCost 
		,MDD.RetailCost
		,MDD.Quantity
		,MDD.Quantity * MDD.RetailCost AS [Line Total]
		,DM.drugMasterCode
		,MDD.drugDetailCode
		,MDD.Remark 
	FROM tblsa_pharmacy_drug_master DM
		INNER JOIN tblsa_pharmacy_drug_detail DD ON DM.drugMasterCode = DD.drugMasterCode
		INNER JOIN tblsa_pharmacy_medication_dispensary_detail MDD ON DD.drugDetailCode = MDD.drugDetailCode
		INNER JOIN tblsa_pharmacy_drug_form DF ON DF.TranID=DM.DrugForm
		INNER JOIN tblsa_pharmacy_medication_dispensary MS ON  MDD.MedicationDispensaryCode = MS.MedicationDispensaryCode 
	WHERE MS.PatientCode = @PatientCode
		AND (MDD.Mark_Deleted=0 OR MDD.Mark_Deleted IS NULL)
end
go

----------20200902
drop procedure SA_SaveMedicationDispensary
go

create procedure SA_SaveMedicationDispensary
	@MedicationDispensaryCode int
	,@DisCampus int
	,@PatientCode nvarchar(20)
	,@DisCode nvarchar(30)
	,@PresDate date
	,@Prescriber int
	,@Remark nvarchar(max)
	,@DrugDetailCode int
	,@Quantity float
	,@QuantityBeforeUpdate float
	,@CurrentSOH float
	,@RealCost float
	,@RetailCode float
    ,@Note nvarchar(max)
	,@Branch nvarchar(20)
	,@User int 
	,@isAdd int output
	,@msg nvarchar(200) output
	,@TMIVStockInCode int output
	,@TMIVRecievedNum nvarchar(20) output
as
begin	
	set @Msg = 'Cannot performance this operation while item code is empty.'
	set @isAdd=0
	set @TMIVStockInCode=0
	set @TMIVRecievedNum=''
	
	BEGIN TRY
		BEGIN TRANSACTION SaveMedication;
			set @DisCode=LTRIM(RTRIM(@DisCode))
			set @Note=LTRIM(RTRIM(@Note))
			set @Remark=LTRIM(RTRIM(@Remark))
			set @Branch=LTRIM(RTRIM(@Branch))
	
			if(len(@PatientCode)>0 and len(@Branch)>0 and @DisCampus>0)
			begin
				if not exists(select InvoiceMedicalStockInCode from tblsa_pharmacy_invoice_medical_stockin where SupplierCode=@SupplierCode and CAST(RecievedDate AS DATE)=CAST(@RecievedDate as DATE) and IVRecievedNum=@IVRecievedNum and InvoiceMedicalStockInCode<>@InvoiceMedicalStockInCode)
				begin
					if @MedicationDispensaryCode=0
					begin
						if len(@DisCode)=0
						begin
							set @DisCode=dbo.SAC_AutoDispensaryCode(@Branch)
						end
				
						--Insert new invoice info in stock-in
						insert into tblsa_pharmacy_invoice_medical_stockin(SupplierCode, IVRecievedNum, RefInvoiceNo, RecievedDate, RecievedBy, Remark, Warehouse, Branch, Mark_Deleted, UserCreate, DateCreate)
						select @SupplierCode, @IVRecievedNum, @RefInvoiceNo, @RecievedDate, @RecievedBy, @Remark, @Warehouse, @Branch, 0, @User, CURRENT_TIMESTAMP
						set @IsAdd=1
						--set @Msg= 'Invoice No: ' +@IVRecievedNum +' has been created.'
					end
					else if exists(select InvoiceMedicalStockInCode from tblsa_pharmacy_invoice_medical_stockin where InvoiceMedicalStockInCode=@InvoiceMedicalStockInCode and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
					begin
						--Update invoice info in the stock-in
						update tblsa_pharmacy_invoice_medical_stockin set		
							SupplierCode=@SupplierCode,
							IVRecievedNum=@IVRecievedNum,
							RefInvoiceNo=@RefInvoiceNo,
							RecievedDate=@RecievedDate,
							RecievedBy=@RecievedBy,
							Remark=@Remark,
							Warehouse=@Warehouse,
							Branch=@Branch,
							UserUpdate=@User,
							DateUpdate=CURRENT_TIMESTAMP
						where InvoiceMedicalStockInCode=@InvoiceMedicalStockInCode 
							and (Mark_Deleted=0 OR Mark_Deleted IS NULL) 				

						set @IsAdd=2
						--set @Msg= 'Invoice No: ' +@IVRecievedNum +' has been updated.'
					end
					--else if exists(select InvoiceMedicalStockInCode from tblsa_pharmacy_invoice_medical_stockin where InvoiceMedicalStockInCode=@InvoiceMedicalStockInCode)
					--begin
					--	set @Msg = 'Cannot make update this! Medication stock-in has been removed or deactived from the system.'
					--end
					--else
					--begin
					--	set @Msg = 'Cannot make update due to the code is not found or has been removed.'
					--end
				end

				set @TMIVRecievedNum=@IVRecievedNum
				declare @TempInvoiceMedicalStockInCode int=(select top 1 InvoiceMedicalStockInCode 
															from tblsa_pharmacy_invoice_medical_stockin 
															where IVRecievedNum=@IVRecievedNum
																and Branch=@Branch
																and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
				set @TMIVStockInCode=@TempInvoiceMedicalStockInCode
				if not exists(Select DrugDetailCode from tblsa_pharmacy_drug_detail where InvoiceMedicalStockInCode=@TempInvoiceMedicalStockInCode and DrugMasterCode=@DrugMasterCode and DrugDetailCode<>@DrugDetailCode)
				begin
					if @DrugDetailCode=0
					begin
						--Insert new medication to stock in
						insert into tblsa_pharmacy_drug_detail(InvoiceMedicalStockInCode, DrugMasterCode, MadeIn, RealCost, Markup, RetailCost, Quantity, StockOnHand, ExpiredDate, LotNum, Branch, Warehouse, IsAdjustment, Mark_Deleted, UserCreate, DateCreate)
						select @TempInvoiceMedicalStockInCode, @DrugMasterCode, @MadeIn, @RealCost, @Markup, @RetailCost, @Quantity, @StockOnHand, @ExpiredDate, @LotNum, @Branch, @Warehouse, @IsAdjustment, 0, @User, CURRENT_TIMESTAMP
						set @IsAdd=3
						set @Msg= (select top 1 'Brand name: ' +DrugBrandName +' saved to Invoice No: ' +@IVRecievedNum +'.' from tblsa_pharmacy_drug_master where DrugMasterCode=@DrugMasterCode)
					end
					else if exists(select DrugDetailCode from tblsa_pharmacy_drug_detail where DrugDetailCode=@DrugDetailCode and (Mark_Deleted=0 OR Mark_Deleted IS NULL))
					begin
						--Update medication in the stock in
						update tblsa_pharmacy_drug_detail set
							InvoiceMedicalStockInCode=@TempInvoiceMedicalStockInCode ,
							DrugMasterCode=@DrugMasterCode,
							MadeIn=@MadeIn,
							RealCost=@RealCost,
							Markup=@Markup,
							RetailCost=@RetailCost,
							Quantity=@Quantity,
							StockOnHand=@StockOnHand,
							ExpiredDate=@ExpiredDate,
							LotNum=@LotNum,
							Branch=@Branch,
							Warehouse=@Warehouse,
							IsAdjustment=@IsAdjustment,
							UserUpdate=@User,
							DateUpdate=CURRENT_TIMESTAMP
						where DrugDetailCode=@DrugDetailCode 
							and (Mark_Deleted=0 OR Mark_Deleted IS NULL)
						set @IsAdd=4
						set @Msg= (select top 1 'Brand name: ' +DrugBrandName +' updated in the Invoice No: ' +@IVRecievedNum +'.' from tblsa_pharmacy_drug_master where DrugMasterCode=@DrugMasterCode)
					end
					else if exists(select DrugDetailCode from tblsa_pharmacy_drug_detail where DrugDetailCode=@DrugDetailCode)
					begin
						set @Msg = 'Cannot make update this! Medication stock-in has been removed or deactived from the system.'
					end
					else
					begin
						set @Msg = 'Cannot make update due to the code is not found or has been removed.'
					end

					--Operation In Stock Master and Stock Detail
					if @DrugDetailCode=0 --Saved Mode 
					begin
						update tblsa_pharmacy_drug_master set
							TotalSOH=TotalSOH+@Quantity,
							TotalValueToDate=TotalValueToDate+@Quantity
						where DrugMasterCode=@DrugMasterCode

						declare @TmpDrugDetailCode float=0
						set @TmpDrugDetailCode=(SELECT TOP 1 DD.DrugDetailCode
												FROM tblsa_pharmacy_drug_master DM
													INNER JOIN tblsa_pharmacy_drug_detail DD ON DM.drugMasterCode = DD.drugMasterCode
												WHERE DM.DrugItemType='Pharmacy'
													AND (DM.Mark_Deleted=0 OR DM.Mark_Deleted IS NULL)
													AND (DD.Mark_Deleted=0 OR DD.Mark_Deleted IS NULL)
												ORDER BY DrugDetailCode DESC)
						declare @TmpMainCampusSOH float=0
						set @TmpMainCampusSOH=(SELECT SUM(DD.StockOnHand) AS StockOnHand
												FROM dbo.tblsa_pharmacy_drug_master DM
													INNER JOIN dbo.tblsa_pharmacy_drug_detail DD ON DM.drugMasterCode = DD.drugMasterCode
												WHERE DM.DrugItemType='Pharmacy'
													AND (DM.Mark_Deleted=0 OR DM.Mark_Deleted IS NULL)
													AND (DD.Mark_Deleted=0 OR DD.Mark_Deleted IS NULL)
													AND DD.Warehouse=@Warehouse
													AND DM.DrugMasterCode=@DrugMasterCode
												GROUP BY DM.drugMasterCode)
						declare @TmpDrugMasterSOH float=0
						set @TmpDrugMasterSOH=(SELECT top 1 TotalSOH from tblsa_pharmacy_drug_master WHERE DrugMasterCode=@DrugMasterCode)

						--Insert to tblsa_pharmacy_stock_transaction
						INSERT INTO tblsa_pharmacy_stock_transaction(
							[DrugDetailCode]
							,[TransDate]
							,[MainBegQtySOH]
							,[MainCampusBegQtySOH]
							,[DetailBegQtySOH]
							,[QtyReceived]
							,[DetailEndQtySOH]
							,[MainCampusEndQtySOH]
							,[MainEndQtySOH]
							,[Branch]
							,[Remark]
							,[DisWarehouse]
							,[UserCreate]
							,[DateCreate])
						VALUES(@TmpDrugDetailCode
							,CURRENT_TIMESTAMP
							,@TmpDrugMasterSOH-@Quantity
							,@TmpMainCampusSOH-@Quantity
							,0
							,@Quantity
							,@Quantity
							,@TmpMainCampusSOH
							,@TmpDrugMasterSOH
							,@Branch
							,'IV Recieve No: ' + @IVRecievedNum + ' : ' + @Remark + ' - Added'
							,@Warehouse
							,@User
							,CURRENT_TIMESTAMP)
					end --end save mode
					else --Update mode
					begin
						update tblsa_pharmacy_drug_master set
							TotalSOH=TotalSOH-@BeforeUpdateQty,
							TotalValueToDate=TotalValueToDate-@BeforeUpdateQty
						where DrugMasterCode=@DrugMasterCodeBeforeUpdate

						update tblsa_pharmacy_drug_master set
							TotalSOH=TotalSOH+@Quantity,
							TotalValueToDate=TotalValueToDate+@Quantity
						where DrugMasterCode=@DrugMasterCode

						if @BeforeUpdateQty<>@Quantity
						begin
							declare @TmpDrugDetailSOH float=(select top 1 StockOnHand from tblsa_pharmacy_drug_detail where DrugDetailCode=@DrugDetailCode order by StockOnHand desc)
							set @TmpDrugMasterSOH=(select top 1 TotalSOH from tblsa_pharmacy_drug_master where DrugMasterCode=@DrugMasterCode order by TotalSOH desc)
							set @TmpMainCampusSOH=(SELECT SUM(DD.StockOnHand) AS StockOnHand
												FROM dbo.tblsa_pharmacy_drug_master DM
													INNER JOIN dbo.tblsa_pharmacy_drug_detail DD ON DM.drugMasterCode = DD.drugMasterCode
												WHERE DM.DrugItemType='Pharmacy'
													AND (DM.Mark_Deleted=0 OR DM.Mark_Deleted IS NULL)
													AND (DD.Mark_Deleted=0 OR DD.Mark_Deleted IS NULL)
													AND DD.Warehouse=@Warehouse
													AND DM.DrugMasterCode=@DrugMasterCode
												GROUP BY DM.drugMasterCode)
							--========Insert to tblsa_pharmacy_stock_transaction=========================
							INSERT INTO tblsa_pharmacy_stock_transaction(
								[DrugDetailCode]
								,[TransDate]
								,[MainBegQtySOH]
								,[MainCampusBegQtySOH]
								,[DetailBegQtySOH]
								,[QtyReceived]
								,[DetailEndQtySOH]
								,[MainCampusEndQtySOH]
								,[MainEndQtySOH]
								,[Branch]
								,[Remark]
								,[DisWarehouse]
								,[UserCreate]
								,[DateCreate])
							VALUES(@DrugDetailCode
								,CURRENT_TIMESTAMP
								,@TmpDrugMasterSOH-(@Quantity-@BeforeUpdateQty)
								,@TmpMainCampusSOH-(@Quantity-@BeforeUpdateQty)
								,@TmpDrugDetailSOH+(@BeforeUpdateQty-@Quantity)
								,@Quantity-@BeforeUpdateQty
								,@TmpDrugDetailSOH
								,@TmpMainCampusSOH
								,@TmpDrugMasterSOH
								,@Branch
								,'IV Recieve No: ' + @IVRecievedNum + ' : Stock adjusted-Reason : ' +@AdjustmentReason
								,@Warehouse
								,@User
								,CURRENT_TIMESTAMP)
						end
					end --end update mode
					--=====Get Top Sale Price to update into tblsa_pharmacy_drug_master======================
					declare @TopSalePrice float=ISNULL((SELECT MAX(RetailCost) AS RetailCost FROM tblsa_pharmacy_drug_detail Where (Mark_Deleted=0 OR Mark_Deleted IS NULL) AND StockOnHand>0 and DrugMasterCode=@DrugMasterCode),0)
					if @TopSalePrice=0
					begin
						set @TopSalePrice=(SELECT top 1 RetailCost FROM tblsa_pharmacy_drug_detail WHERE DrugMasterCode=@DrugMasterCode order by RetailCost desc)
					end
					--==Update Top Sale Price to Table tblsa_pharmacy_drug_master========
					UPDATE tblsa_pharmacy_drug_master SET 
						MainRetailPrice= @TopSalePrice
					WHERE DrugMasterCode=DrugMasterCode

					--=============Record to tblsa_pharmacy_stock_transaction========
					If @BeforeUpdateQty>0 
					begin
						If @BeforeUpdateQty<>@Quantity  --Adjustment only record when Quantity has been changed
						begin
							INSERT INTO tblsa_pharmacy_stock_adjustment(
								[DrugDetailCode]
								,[InvoiceMedicalStockInCode]
								,[DrugMasterCode]
								,[DateAdjustment]
								,[BeforeAdjSOH]
								,[AfterAdjSOH]
								,[BeforeAdjQty]
								,[AfterAdjQty]
								,[AdjReason]
								,[QtyAdj]
								,[IsAdjustmentIn]
								,[Warehouse]
								,[Mark_Deleted]
								,[UserCreate]
								,[DateCreate])
							VALUES(@DrugDetailCode
								,@InvoiceMedicalStockInCode
								,@DrugMasterCode
								,CURRENT_TIMESTAMP
								,@BeforeAdjSOH
								,@StockOnHand
								,@BeforeUpdateQty
								,@Quantity
								,@AdjustmentReason
								,@Quantity-@BeforeUpdateQty
								,(CASE WHEN @BeforeUpdateQty<@Quantity THEN 1 ELSE 0 END)
								,@Warehouse
								,0
								,@User
								,CURRENT_TIMESTAMP)
						end
					end
				end
				else
				begin
					set @isAdd=0
					set @Msg = 'Incompleted add! This medication already exists in the list.'
				end
			end
		COMMIT TRANSACTION SaveMedication;  
	END TRY
	BEGIN CATCH
		IF (@@TRANCOUNT>0)
		BEGIN
			ROLLBACK TRANSACTION SaveMedication
			PRINT 'Error detected, all changes reversed'
		END 
	END CATCH

	SELECT @IsAdd, @Msg, @TMIVStockInCode, @TMIVRecievedNum
end
go


------20200810
DROP FUNCTION SAC_AutoDispensaryCode
GO

CREATE FUNCTION SAC_AutoDispensaryCode(
	@Branch nvarchar(30)
)RETURNS NVARCHAR(40)
AS
BEGIN
	declare @InvoiceNumber nvarchar(20)=''
	set @InvoiceNumber = ISNULL((select top 1 DisCode from tblsa_pharmacy_medication_dispensary where DisCode like 'D' + CONVERT(NVARCHAR(2), RIGHT(YEAR(GETDATE()), 2)) + '%' and Branch=@Branch order by DisCode desc), 0)
	set @InvoiceNumber=RIGHT(@InvoiceNumber, 6)+1
	set @InvoiceNumber='D' +CONVERT(NVARCHAR(2), RIGHT(YEAR(GETDATE()), 2)) +REPLICATE('0', 6-LEN(RTRIM(@InvoiceNumber))) +RTRIM(@InvoiceNumber)

	RETURN @InvoiceNumber
END
Go

Select dbo.SAC_AutoDispensaryCode('')