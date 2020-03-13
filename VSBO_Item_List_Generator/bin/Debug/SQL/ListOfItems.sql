select

--	PARAMETER 1 = STORE ID		--


si.STORE_ID
,s.store_name
,i.FO_ITEM_CODE as item_code
,i.ITEM_DESC
,bh.FO_BARCODE as Item_Barcode
,si.CRT_PRICE# as SELLING_PRICE
,(Select  max (bc.GROSS_UCOST) 
	From BO_SPR_COST_HST bc
	LEFT JOIN BO_SPR_ITEM spr
		ON spr.store_id = bc.store_id
		AND spr.item_id = bc.item_id
		AND spr.spr_id = bc.spr_id
	Where bc.item_id = si.item_id 
		and bc.store_id = si.store_id
		and spr.SPR_MAIN_FLAG = '1') as BASE_UCOST
,(Select  max (bc.NET_UCOST) 
	From BO_SPR_COST_HST bc
	LEFT JOIN BO_SPR_ITEM spr
		ON spr.store_id = bc.store_id
		AND spr.item_id = bc.item_id
		AND spr.spr_id = bc.spr_id
	Where bc.item_id = si.item_id 
		and bc.store_id = si.store_id
		and spr.SPR_MAIN_FLAG = '1') as NET_UCOST
,bo_getunitcost(si.store_id, i.item_id, CURRENT DATE) AVG_COST
--,si.CRT_VAT_PERC#
,i.DEPT_FULL_CODE# as DEPARTMENT
,d.DEPT_NAME as CATEGORY
,v.VAT_DESC as VAT_TYPE
,Case 
	si.ITEM_ASSORT_TYPE#
	When
	'N' Then 'Raw material'
	When
	'I' Then 'In assortment'
	When
	'E' Then 'Indepletion'
	When
	'S' Then 'Out of assortment'
	Else
	'undefined**'
End As ASSORT_TYPE




from 
vsboread.LW_STORE_ITEM si

LEFT JOIN BO_STORE s
	ON si.store_id = s.store_id
LEFT JOIN BO_VAT v
	ON si.CRT_VAT_ID# = v.vat_id
LEFT JOIN vsboread.LW_ITEM i
	ON si.item_id = i.item_id
LEFT JOIN BO_BARCODE_HST bh
	ON si.store_id = bh.store_id
	AND si.item_id = bh.item_id
	AND bh.BARCODE_MAIN_FLAG = 1
	
LEFT JOIN vsboread.LW_DEPT d ON i.DEPT_FULL_CODE# = d.DEPT_FULL_CODE

left join vsboread.lw_dept d4 on (i.dept_seq = d4.dept_seq)
LEFT join vsboread.lw_dept d3 on (d3.dept_seq = d4.parent_dept_seq)
left join vsboread.lw_dept d2 on (d2.dept_seq = d3.parent_dept_seq)
left join vsboread.lw_dept d1 on (d1.dept_seq = d2.parent_dept_seq)
	

where 
si.STORE_ID = {0}


order by
i.FO_ITEM_CODE


--FETCH FIRST 1 ROWS ONLY


