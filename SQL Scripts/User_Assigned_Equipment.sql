select Users.UserUVID as 'User UVID', Users.UserFName + Users.UserLName as 'User''s Name', Equipment.UVUInvID as 'UVU Inventory ID', Model.ModelName as 'Model', Type.TypeID as 'Type', Equipment.SerialNum as 'Computer Serial #'
from Equipment
Inner Join Model on Equipment.ModelID = Model.ModelID
Inner Join Type on Equipment.TypeID = Type.TypeID
Inner Join Users on Equipment.UserUVID = Users.UserUVID
order by 'User UVID'

