<template>
    <div>
         <div class="row">
            <div class="col-lg-8 offset-lg-2">
                <div class="card mt-4">
                    <div class="text-center">
                        <div v-if="loading" class="spinner-border text-success" role="status">
                            <span class="sr-only"></span>
                        </div>
                    </div>
                    <h5 v-if="listPermissions.length == 0" class="text-center">No hay permisos para mostrar</h5>
                    <table class="table table-hover" v-if="!loading">
                        <thead>
                            <tr>
                            <th scope="col">Nombre Empleado</th>
                            <th scope="col">Apellidos Empleado</th>
                            <th scope="col">Tipo Permiso</th>
                            <th scope="col">Fecha Permiso</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="(permit, id) of listPermissions" :key="id">
                                <td>{{permit.employeeName}}</td>
                                <td>{{permit.lastNameEmployee}}</td>
                                <td>{{permit.permitType.description}}</td>
                                <td>{{permit.permitDateFormat}}</td>
                                <td>
                                    <span class="text-danger cursor" v-on:click="deletePermission(permit.id)">
                                        <i class="far fa-trash-alt"></i>
                                    </span>
                                </td>
                                <td>
                                    <span class="text-success cursor" v-on:click="updatePermission(permit.id)">
                                        <i class="far fa-pencil-alt"></i>
                                    </span>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';

    export default {
        name: 'ManagePermissions',
        data(){
            return {
                listPermissions:[],
                loading: false,
                responseDelete: false
            }
        },
        methods:{
            getPermissions(){
                this.loading = true;
                axios.get(this.urlServices + "Permit").then(response => {
                    console.log(response);
                    this.listPermissions = response.data;
                    this.loading = false;
                }).catch(error => {
                    console.error(error);
                    this.loading = false;
                })
            },
            deletePermission(id){

                this.responseDelete = confirm("¿Desea eliminar el permiso?");

                if (this.responseDelete) {
                    this.loading = true;
                    axios.delete(this.urlServices + "Permit/" + id).then(response => {
                        console.log(response);
                        this.loading = false;
                        this.getPermissions();
                    }).catch(error =>{
                        console.log(error);
                    });
                }
            },
            updatePermission(id){
                this.$router.push({
                    path: '/Update/' + id
                });
            }
        },
        created: function(){
            this.getPermissions();            
        }
    }
</script>

<style scoped>
    .cursor{
        cursor:pointer;
    }
</style>