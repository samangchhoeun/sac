update tblsa_pharmacy_drug_master set DrugGenericName='Dexamethasone' where DrugGenericName = 'Dexamethazone disodium phosphate'
update tblsa_pharmacy_drug_master set DrugGenericName=G.TranID
from tblsa_pharmacy_drug_master D 
	inner join tblsa_pharmacy_generic_name G on D.DrugGenericName=G.GenericEn
select 
	*
from tblsa_pharmacy_drug_master
WHERE DrugGenericName LIKE '%[^0-9]%' 
order by DrugGenericName


select
	*
from tblsa_pharmacy_drug_form 
where FormEn like '%ov%'

	
update tblsa_pharmacy_drug_master set DrugForm=G.TranID
from tblsa_pharmacy_drug_master D 
	inner join tblsa_pharmacy_drug_form G on D.DrugForm=G.FormEn



--select 
--	*
--from HospitalDatabase.dbo.Ph_tblDrugMaster

--select 
--	*
--from MJQEWarehouse.dbo.tblsa_pharmacy_drug_master

--insert into MJQEWarehouse.dbo.tblsa_pharmacy_drug_master(DrugCode, DrugBrandName, DrugGenericName, DrugForm, TotalValueToDate, TotalSOH, MaxSOH, MinSOH, Strength, Volume, DrugSpecification, Branch, MainRetailPrice, DrugItemType)
--select 
--	drugCode, 
--	DrugBrandName, 
--	DrugGenericName, 
--	form, 
--	TotalValueToDate, 
--	TotalSOH, 
--	MaxSOH, 
--	MinSOH, 
--	Strength, 
--	Volume, 
--	DrugSpecification, 
--	Branch, 
--	MainRetailPrice, 
--	DrugItemType
--from HospitalDatabase.dbo.Ph_tblDrugMaster
--order by HospitalDatabase.dbo.Ph_tblDrugMaster.Drugcode