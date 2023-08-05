CREATE FUNCTION Urunleri_getir(@param1 int)
RETURNS TABLE
AS
RETURN
(
SELECT  U.UrunAdi
FROM Urunler AS U
WHERE
 @param1=U.KategoriID
);