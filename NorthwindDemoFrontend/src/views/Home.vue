<template>
  <div class="home">
    <ProductList />
  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from '@/components/HelloWorld.vue'
import ProductList from '@/components/ProductList.vue'

export default {
  name: 'home',
  components: {
    HelloWorld,
    ProductList
  }
}
</script>
