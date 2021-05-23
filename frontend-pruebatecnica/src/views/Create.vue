<template>
  <div>
      <h1 v-if="$route.params.id == undefined" class="display-4 text-center">Crear Permiso</h1>
      <h1 v-if="$route.params.id != undefined" class="display-4 text-center">Actualizar Permiso</h1>
      <hr>
    <CreatePermission />
  </div>
</template>

<script>
import CreatePermission from '@/components/CreatePermission.vue'

export default {
  name: 'Create',
  components: {
    CreatePermission
  }
}
</script>