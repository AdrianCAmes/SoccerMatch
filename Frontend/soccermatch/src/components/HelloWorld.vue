<template>   
   <v-container>
    <v-layout justify-center
      text-xs-center
      wrap>
      <v-flex xs12 sm10 md8 lg6>
        <v-toolbar flat color="white">  
          <h1>¡Bienvenido a SoccerMatch!</h1>    
          </v-toolbar>

              <v-text-field v-model="loginUsuario" label="Usuario"></v-text-field>

          <v-text-field v-model="contraseña"
            :append-icon="show2 ? 'visibility' : 'visibility_off'"
            :type="show2 ? 'text' : 'password'"
            name="input-10-2"
            label="Contraseña"
            value="wqfasds"
            class="input-group--focused"
            @click:append="show2 = !show2"
          ></v-text-field>
             <!-- <v-text-field v-model="contraseña" label="Contraseña">Contraseña </v-text-field>-->

              <v-btn   @click="Loggin()" slot="activator" color="primary" dark class="mb-2">Login</v-btn>    
            <v-btn   @click="Register()" slot="activator" color="primary" dark class="mb-2">Register</v-btn>
      </v-flex>

    </v-layout>
   </v-container>
 
     
</template>
<script>

import axios from "axios";
import router from "vue-router"
export default {
  name: 'App',
  data () {
    return {
        show2: false,
        password: 'Password',
    lstaUsuarios:[],
    loginUsuario:'',
    contraseña:'',
    idUsuario:'',
    ruta:'',
      drawer: true,
     }
  },
  
  created(){
   localStorage.removeItem("usuario");
   localStorage.removeItem("equipo");
   this.setLstaUsuarios();
  },
  methods: {
    setLstaUsuarios(){
         let me = this;

    axios.get("api/usuario")
        .then(function(response) {
          me.lstaUsuarios = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
  },
  LoginCorrecto(){      
            var correcto = 0;
            for (var i = 0; i < this.lstaUsuarios.length; i++) {
               if (this.lstaUsuarios[i].usuario1 == this.loginUsuario && this.lstaUsuarios[i].pswd == this.contraseña) { 
                    correcto = 1;
                    this.idUsuario=this.lstaUsuarios[i].cusuario;
               }
            }
            return correcto;       
  },
  Register(){
    this.$router.push('/register');
  },
  Loggin(){ 

      if (this.LoginCorrecto()==1){
        this.$router.push('/equipo/misequipos');
        localStorage.setItem("usuario",this.idUsuario);
      }
      else{ 
             
        alert("Usuario o Contraseña incorrecta");
       this.loginUsuario='';
        this.contraseña='';
      }   
  }
  },
  

}
</script>

