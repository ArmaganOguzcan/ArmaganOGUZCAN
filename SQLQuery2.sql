delete from Test_Detay
DBCC CHECKIDENT ('Test_Detay',RESEED,0)

select * from Test_Detay

delete from Test
DBCC CHECKIDENT ('Test',RESEED,0)

select * from Test

delete from Soru
DBCC CHECKIDENT ('Soru',RESEED,0)

select * from Soru