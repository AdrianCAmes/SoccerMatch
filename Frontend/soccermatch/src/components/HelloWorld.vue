<template>   

   
<v-flex>
   <v-toolbar flat color="white">  
     <h1>Login</h1>    
    </v-toolbar>

     <v-flex xs12 sm12 md12>
                    <v-text-field v-model="loginUsuario" label="Ingrese su identidad de usuario"></v-text-field>
                  </v-flex>



     <form>
        <v-text-field v-model="contraseña" label="Ingrese su contraseña de usuario">Contraseña </v-text-field>

        <v-btn @click="Loggin()" href='ruta' slot="activator" color="primary" dark class="mb-2">Registrarse</v-btn>
           <!-- @click="this.Loggin()"-->
        
      </form>

</v-flex>

 


   
     
</template>
<script>

import axios from "axios";
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
  Loggin(){ 

      if (this.LoginCorrecto()==1){
          this.ruta="./usuarios";
      }
      else{ 
             
        alert(this.loginUsuario);
       this.loginUsuario='';
        this.contraseña='';
      }

      return router[this.usuarios];
    
  }
  },
  

}
</script>

