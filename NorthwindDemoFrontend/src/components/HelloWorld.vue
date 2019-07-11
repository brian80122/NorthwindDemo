<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <el-button @click="test">TestAxios</el-button>
    <p> {{testData}} </p>
  </div>
</template>

<script>
export default {
  name: 'HelloWorld',
  data:function() {
         return  {
           testData: ''
         }},
  props: {
    msg: String
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
    }
  }
}
</script>