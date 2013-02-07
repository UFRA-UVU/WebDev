select Users.UserUVID as 'User UVID', Users.UserFName + ' ' + Users.UserLName as 'User''s Name', Equipment.UVUInvID as 'UVU Inventory ID', Mfg.MfgName + ' ' + Model.ModelName as 'Model', Type.TypeName as 'Type', Equipment.SerialNum as 'Computer Serial #'
from Equipment
Inner Join Model on Equipment.ModelID = Model.ModelID
Inner Join Type on Equipment.TypeID = Type.TypeID
Inner Join Users on Equipment.UserUVID = Users.UserUVID
Inner Join Mfg on Mfg.MfgID = Model.MfgID
order by 'User UVID'