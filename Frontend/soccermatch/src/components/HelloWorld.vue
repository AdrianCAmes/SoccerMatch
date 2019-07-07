<template>   

   
<v-flex>
   <v-toolbar flat color="white">  
     <h1>Login</h1>    
    </v-toolbar>

     <v-flex xs12 sm12 md12>
                    <v-text-field v-model="loginUsuario" label="Usuario"></v-text-field>
                  </v-flex>

 
         <v-text-field v-model="contraseña" label="Contraseña">Contraseña </v-text-field>

        <v-btn   @click="Loggin()" slot="activator" color="primary" dark class="mb-2">Login</v-btn>    
      <v-btn   @click="Register()" slot="activator" color="primary" dark class="mb-2">Register</v-btn>
</v-flex>

 


   
     
</template>
<script>

import axios from "axios";
import router from "vue-router"
export default {
  name: 'App',
  data () {
    return {
    lstaUsuarios:[],
    loginUsuario:'',
    contraseña:'',
    ruta:'',
      drawer: true,
     }
  },
  
  created(){
   this.setLstaUsuarios();
  },
  methods: {
    setLstaUsuarios(){
         let me = this;

    axios.get("api/usuario")
        .then(function(response) {
          console.log(response);
          me.lstaUsuarios = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
  },

  LoginCorrecto(){      
            var correcto = 0;
            for (var i = 0; i < this.lstaUsuarios.length; i++) {
               if (this.lstaUsuarios[i].usuario1 == this.loginUsuario ) { 
                    correcto = 1;
               }
            }
            return correcto;       
  },
  Register(){
    this.$router.push('/register');
  },
  Loggin(){ 

      if (this.LoginCorrecto()==1){
        this.$router.push('/usuarios');
        localStorage.setItem('usuario',loginUsuario);
      }
      else{ 
             
        alert("USUARIO o PASSWORD INCORRECTO");
       this.loginUsuario='';
        this.contraseña='';
      }   
  }
  },
  

}
</script>

