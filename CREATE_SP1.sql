create proc GetFees @NatID nvarchar (14)
as
begin
SELECT * FROM online_fees WHERE NATID = @NATID
end