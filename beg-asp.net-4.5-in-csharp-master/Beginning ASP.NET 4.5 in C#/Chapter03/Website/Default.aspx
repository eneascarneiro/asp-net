<%@ Page Language="C#" %>

<!DOCTYPE html>

<script runat="server">
    private void Page_Load(object sender, EventArgs e)
    {
        Product saleProduct = new Product("Kitchen Garbage", 49.99M, "garbage.jpg");
        Product saleProduct1 = new Product("Kitchen Garbage Discount", 39.99M, "garbage.jpg");
        Response.Write(saleProduct.GetHtml());
        Response.Write(saleProduct1.GetHtml());
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Product Test</title>
</head>
<body></body>
</html>
