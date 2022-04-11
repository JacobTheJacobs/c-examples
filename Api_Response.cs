//create class name api_response
class ApiResponse
{
    public string name;
    public string sales;

    public double floor_price;

    public double avg_price;
    public string url;
    public string description;

    //constructor
    public ApiResponse(string name, string sales, double floor_price, double avg_price, string url, string description)
    {
        this.name = name;
        this.sales = sales;
        this.floor_price = floor_price;
        this.avg_price = avg_price;
        this.url = url;
        this.description = description;
    }

}