select Area.AreaName as 'Area', Bldg.BldgID as 'Building', dept.deptID as 'Department', Equipment.Room as 'Room', Equipment.UVUInvID as 'Equipment ID', Equipment.UserUVID as 'User', EquipType.EquipTypeName as 'Equip Typ', Mfg.MfgName as 'Mfg', Model.ModelName as 'Model', equip.UserPrimaryComp
from Equipment
Inner Join Bldg on Bldg.BldgID = Equipment.BldgID
Inner Join Dept on dept.deptID = Equipment.deptID
Inner Join Area on Area.AreaID = Equipment.AreaID
Inner Join EquipType on EquipType.EquipTypeID = Equipment.EquipTypeID
Inner Join Model on Model.MfgID = Mfg.MfgID
order by Bldg.BldgID, dept.deptID, Equipment.Room, Equipment.UVUInvID 