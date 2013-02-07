select Area.AreaName as 'Area', dept.DeptName as 'Department', UserFName + ' ' + Users.UserLName as 'Name', Users.Title as 'Title', CASE WHEN (Users.FullTime = 0 or Users.FullTime IS NULL) THEN 'PT' ELSE 'FT' END AS 'Full Time'
from Users
Inner Join Dept on Dept.DeptID = Users.DeptID
Inner Join Area on Area.AreaID = Users.AreaID

Order By 'Area', 'Department', Users.UserFName