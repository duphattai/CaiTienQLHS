select * from sys.tables whereexists (select * from sys.tables where name = 'NAMHOC') and exists (select * from sys.tables where name = 'HOCKY') and exists (select * from sys.tables where name = 'KHOI') and exists (select * from sys.tables where name = 'LOP') and exists (select * from sys.tables where name = 'HOSOHOCSINH') and exists (select * from sys.tables where name = 'XEPLOP') and exists (select * from sys.tables where name = 'MONHOC') and exists (select * from sys.tables where name = 'LOAIDIEM') and exists (select * from sys.tables where name = 'DIEM') and exists (select * from sys.tables where name = 'BANGDIEM') and exists (select * from sys.tables where name = 'THAMSO')and exists (select * from sys.tables where name = 'BAOCAOMONHOC') and exists (select * from sys.tables where name = 'CHITIETBAOCAOMON')and exists (select * from sys.tables where name = 'CHITIETBAOCAOHOCKY')and exists (select * from sys.tables where name = 'BAOCAOHOCKY')and exists (select * from sys.tables where name = 'GIANGDAY')and exists (select * from sys.tables where name = 'THOIKHOABIEU')and exists (select * from sys.tables where name = 'GIAOVIEN')