<template>
  <div>
     <h1 class="display-4 text-center">Listado de Permisos</h1>
      <hr>
    <Manage />
  </div>
</template>

<script>
import Manage from '@/components/ManagePermissions.vue'

export default {
  name: 'Home',
  components: {
    Manage
  }
}
</script>
