<template>
  <el-row  type="flex" justify="center" >
      <el-col :span="22">
        <h3>Product List</h3>
        
        <el-table border
        :data="ProductResult.Products"
                  width="80vw"
        >
            <el-table-column prop="ProductId"
                             label="ProductId">
            </el-table-column>
            <el-table-column prop="ProductName"
                             label="ProductName">
            </el-table-column>
            <el-table-column prop="SupplierId"
                             label="SupplierId">
            </el-table-column>
            <el-table-column prop="CategoryId"
                             label="CategoryId">
            </el-table-column>
            <el-table-column prop="QuantityPerUnit"
                             label="QuantityPerUnit">
            </el-table-column>
            <el-table-column prop="UnitPrice"
                             label="UnitPrice">
            </el-table-column>
            <el-table-column prop="UnitsInStock"
                             label="UnitsInStock">
            </el-table-column>
            <el-table-column prop="UnitsOnOrder"
                             label="UnitsOnOrder">
            </el-table-column>
            <el-table-column prop="ReorderLevel"
                             label="ReorderLevel">
            </el-table-column>
            <el-table-column prop="Discontinued"
                             label="Discontinued">
                <template slot-scope="scope">
                    <span> {{scope.row.Discontinued ? 'Yes': 'No'}} </span>
                </template>
            </el-table-column>
        </el-table>
        <br/>
        <el-pagination @size-change="ProductResult_handleSizeChange"
                       @current-change="ProductResult_handleCurrentChange"
                       background
                       layout="total, sizes, prev, pager, next, jumper"
                       :current-page.sync="ProductResult.PageIndex"
                       :page-size="ProductResult.PageSize"
                       :total="ProductResult.Total">
        </el-pagination>
        </el-col>
    </el-row>

     

</template>

<script>
export default {
  name: 'ProductList',
  data:function() {
         return  {
           testData: '123',
           ProductResult:
                {
                    Products: [],
                    PageSize: 10,
                    Total: 0,
                    PageIndex: 1
                }
         }
  },  
  methods:
  {
    test(){
       let Self = this;
       this.axios({
           method: 'post',
           url: "https://localhost:5001/api/supplier/Get?supplierId=1",
       }).then(function (response) {
         Self.testData = JSON.stringify(response.data)
       });
    },
    GetProducts(){
       let Self = this;
       this.axios({
           method: 'post',
           url: `${Self.ApiUrl}product/find`,
           data:{
               "pageSize": Self.ProductResult.PageSize,
               "pageIndex": Self.ProductResult.PageIndex
           }
       }).then(function (response) {
         console.log(response.data)
         Self.ProductResult.Products = response.data.Products
         Self.ProductResult.Total = response.data.TotalCount
       });
    },
    ProductResult_handleSizeChange() {
        this.GetProducts();
    },
    ProductResult_handleCurrentChange() {
        this.GetProducts();
    }
  },
  mounted(){
      this.GetProducts();
  }
}
</script>