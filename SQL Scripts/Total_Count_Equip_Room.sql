select Bldg.BldgID as 'Building', Dept.DeptID as 'Department', Equipment.Room as 'Room', COUNT(Equipment.EquipID)as 'Total Count'
from Equipment
Inner Join Bldg on Bldg.BldgID = Equipment.BldgID
Inner Join Dept on dept.deptID = Equipment.deptID
--order by 'Building', 'Department'
group by Bldg.BldgID, Dept.DeptID, Equipment.Room
