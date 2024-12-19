namespace Services;

//record kullanımı ile iki record type yapılı referanslar da 
// record1==record2 şeklinde karşılaştırma yapılabilir.
// bu şekilde referans karşılaştırması yapılır ve karşışaltırılırken propertyler bazında karşılaştırılır
// eğer class1 == class2 şeklinde karşılaştırma yapmak istersek classlar referans karşılaştırması yaparlar

public record ProductDto
{
    public int Id { get; init; }
    public string ProductName { get; init; } = string.Empty;
}