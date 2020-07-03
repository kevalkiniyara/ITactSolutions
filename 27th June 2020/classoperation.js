class car
{
    constructor(brand)
    {
        this.carName=brand;
    }
    CarDetail()
    {
        return this.carName;
    }
    static CarBrand()
    {
        return "Hello";
    }
}
class maruti extends car
{
    constructor(brand,value)
    {
        super(brand);
        this.price=value;
    }
    ShowDetail()
    {
        return this.carName+""+this.price;
    }
}
carData1=new car("Ford");
carData2=new maruti("Ford",250000);
document.writeln(car.CarBrand());
document.writeln(carData1.CarDetail());
document.writeln(carData2.ShowDetail())