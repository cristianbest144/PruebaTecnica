<template>
     <div class="row">
        <div class="col-lg-4 offset-lg-4">
           <form>
                <fieldset>
                    <div class="text-center">
                        <div v-if="loading" class="spinner-border text-success" role="status">
                            <span class="sr-only"></span>
                        </div>
                    </div>
                    <div class="mb-3">
                        <label for="name" class="form-label">Nombre</label>
                        <input v-model="name" type="text" id="name" class="form-control">
                    </div>
                    <div class="mb-3">
                        <label for="lastName" class="form-label">Apellido</label>
                        <input v-model="lastName" type="text" id="lastName" class="form-control">
                    </div>
                    <div class="mb-3">
                        <label for="permitType" class="form-label">Tipo Permiso</label>
                        <select  v-model="permitType"
                                id="permitType" class="form-select">
                            <option v-for="type in listType" :value="type.id" :key="type.id" >
                                {{type.description}}
                            </option>
                        </select>
                    </div>
                     <div class="mb-3">
                        <label for="permitDate" class="form-label">Fecha de Solicitud</label>
                        <input v-model="permitDate" type="date" id="permitDate" class="form-control" >
                    </div>
                    <button v-on:click="createPermission()" v-if="idPermit == undefined"
                            type="submit" class="btn btn-primary">Guardar</button>
                    <button v-on:click="updatePermission()" v-if="idPermit != undefined"
                            type="submit" class="btn btn-primary">Actualizar</button>
                </fieldset>
            </form>
        </div>
    </div>
</template>

<script>
import axios from 'axios';

    export default {
        name: 'CreatePermission',
        data(){
            return {
                idPermit: this.$route.params.id, 
                listType:[],
                loading: false,
                name: '',
                lastName: '',
                permitType: '',
                permitDate: ''
            }
        },
        methods:{
            getTypes(){
                this.loading = true;
                axios.get(this.urlServices + "PermitType").then(response => {
                    console.log(response);
                    this.listType = response.data;
                    this.loading = false;
                }).catch(error => {
                    console.error(error);
                    this.loading = false;
                })
            },
            createPermission(){

                if(this.name == ''){
                    alert('Debe ingresar un nombre');
                    return;
                }

                if(this.lastName == ''){
                    alert('Debe ingresar un apellido');
                    return;
                }

                if(this.permitType == ''){
                    alert('Debe seleccionar un tipo de permiso');
                    return;
                }

                if(this.permitDate == ''){
                    alert('Debe ingresar una fecha de solicitud');
                    return;
                }

                const permit = {
                    employeeName: this.name,
                    lastNameEmployee: this.lastName,
                    idPermitType: this.permitType,
                    permitDate: this.permitDate
                }
                this.loading = true;
                axios.post(this.urlServices + "Permit", permit).then(response => {
                    console.log(response);
                    this.loading = false;
                    this.$router.push({ path: '/' });
                }).catch(error => {
                    console.error(error);
                    this.loading = false;
                })
            },
            getPermitById: function(){

                if(this.idPermit == undefined){
                    return;
                }

                this.loading = true;
                axios.get(this.urlServices + "Permit/" + this.idPermit).then(response => {
                    console.log(response);
                    this.name = response.data.employeeName;
                    this.lastName = response.data.lastNameEmployee;
                    this.permitDate = response.data.permitDateFormat;
                    this.permitType = response.data.idPermitType;

                    this.loading = false;
                }).catch(error => {
                    console.error(error);
                    this.loading = false;
                })
            },
            updatePermission(){

                if(this.name == ''){
                    alert('Debe ingresar un nombre');
                    return;
                }

                if(this.lastName == ''){
                    alert('Debe ingresar un apellido');
                    return;
                }

                if(this.permitType == ''){
                    alert('Debe seleccionar un tipo de permiso');
                    return;
                }

                if(this.permitDate == ''){
                    alert('Debe ingresar una fecha de solicitud');
                    return;
                }

                const permit = {
                    id: parseInt(this.idPermit),
                    employeeName: this.name,
                    lastNameEmployee: this.lastName,
                    idPermitType: this.permitType,
                    permitDate: this.permitDate
                }
                this.loading = true;
                axios.put(this.urlServices + "Permit/" + this.idPermit, permit).then(response => {
                    console.log(response);
                    this.loading = false;
                    this.$router.push({ path: '/' });
                }).catch(error => {
                    console.error(error);
                    this.loading = false;
                })
            }
        },
        created: function(){
            this.getTypes();
            this.getPermitById();            
        }
    }
</script>

<style scoped>

</style>