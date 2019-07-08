<template>
  <v-layout justify-center>
    <v-flex xs12 sm10 md8 lg6>
      <v-card ref="form">
        <v-card-text>
          <v-text-field
            v-model="nusuario"
            label="Nombre"
            required
          ></v-text-field>
                    <v-text-field
            v-model="direccion"
            label="Direccion"
            required
          ></v-text-field>
          <v-text-field
            v-model="usuario1"
            label="Usuario"
            required
          ></v-text-field>
            <v-text-field v-model="pswd"
            :append-icon="show2 ? 'visibility' : 'visibility_off'"
            :type="show2 ? 'text' : 'password'"
            name="input-10-2"
            label="Contraseña"
            value="wqfasds"
            class="input-group--focused"
            @click:append="show2 = !show2"
          ></v-text-field>
            <v-text-field v-model="cpswd"
            :append-icon="show3 ? 'visibility' : 'visibility_off'"
            :type="show3 ? 'text' : 'password'"
            name="input-10-2"
            label="Confirmar Contraseña"
            value="wqfasds"
            class="input-group--focused"
            @click:append="show3 = !show3"
          ></v-text-field>
          <!--<v-text-field
            v-model="pswd"
            label="Contraseña"
            required
          ></v-text-field>
          <v-text-field
            v-model="cpswd"
            label="Confirmar contraseña"
            required
          ></v-text-field>-->
            <v-text-field
            v-model="cdni"
            label="DNI"
            required
          ></v-text-field>
          <v-text-field
            v-model="numTelefono"
            label="Telefono"
            required
          ></v-text-field>
        </v-card-text>
        <v-divider class="mt-5"></v-divider>
        <v-card-actions>
          <v-btn flat>Cancel</v-btn>
          <v-spacer></v-spacer>
          <v-slide-x-reverse-transition>
            <v-tooltip
              v-if="formHasErrors"
              left
            >
              <template v-slot:activator="{ on }">
                <v-btn
                  icon
                  class="my-0"
                  @click="resetForm"  
                  v-on="on"
                >
                  <v-icon>refresh</v-icon>
                </v-btn>
              </template>
              <span>Refresh form</span>
            </v-tooltip>
          </v-slide-x-reverse-transition>
         <v-btn   @click="guardar()" slot="activator" color="primary" dark class="mb-2">Registrarse</v-btn> 
        </v-card-actions>
      </v-card>
    </v-flex>
  </v-layout>
</template>
<script>
import axios from "axios";
import router from "vue-router";
export default {
  data() {
    return {
       show2: false,
       show3:false,
        password: 'Password',
      usuarios: [],
      dialog: false,
      headers: [    
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Nombres", value: "nusuario", sortable: false },     
        { text: "DNI", value: "cdni", sortable: false },  
        { text: "Telefono", value: "numTelefono" },  
        { text: "Usuario", value: "usuario1" },
        { text: "Contraseña", value: "pswd"},
        {text:"Confirmar contraseña",value:"cpswd"},
        {text:"Direccion",value:"direccion"}
      ],
      search: "",
      editedIndex: -1,

      //TODO:Model
       cusuario :'',
     cdni :'',
      nusuario:'',
      numTelefono:'',
      usuario1:'',
      pswd:'',
        cpswd:'',
        direccion:''
    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nuevo Usuario" : "Actualizar Usuario";
    }
  },

  watch: {
    dialog(val) {
      val || this.close();
    }
  },

  created() {
      this.listar();

  },
  methods: {
    listar() {
      let me = this;
      axios
        .get("api/usuario")
        .then(function(response) {
          console.log(response);
          me.usuarios = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    editItem(item) {
      this.cusuario = item.cusuario;
      this.cdni = item.cdni;
      this.nusuario = item.nusuario;
      this.numTelefono = item.numTelefono;
      this.usuario1 = item.usuario1;
      this.pswd = item.pswd;
      this.cpswd=item.cpswd;
      this.direccion=item.direccion;
      this.editedIndex = 1;
      this.dialog = true;
    },
    close() {
      this.dialog = false;
    },
    limpiar() {
      this.cusuario = "";
      this.cdni = "";
      this.pswd = "";
      this.nusuario = "";
      this.numTelefono = "";
      this.usuario1 = "";
      this.cpswd="";
      this.direccion="";
    },
   guardar() {
      if (this.editedIndex > -1) {
        //Código para editar

        let me = this;
        axios 
          .put("api/usuario", {
            cusuario: me.cusuario,
            cdni: me.cdni,
            pswd: me.pswd,
            nusuario: me.nusuario,
            numTelefono: me.numTelefono,
            usuario1: me.usuario1
          })
          .then(function(response) {
            me.close();
            me.listar();
            me.limpiar();
          })
          .catch(function(error) {
            console.log(error);
          });
      } else {
        //Código para guardar
        let me = this;
        axios
          .post("api/usuario", {
           cdni: me.cdni,
            pswd: me.pswd,
            nusuario: me.nusuario,
            numTelefono: me.numTelefono,
            usuario1: me.usuario1
          })
          .catch(function(error) {
            console.log(error);
          });
          var tamaño=this.usuarios.length+1;     
          var dir=this.direccion; 
           axios
          .post("api/jugador", {
           cjugador:tamaño,
           tdireccion:dir
          }).then(function(response) {
            me.close();
            me.listar();
            me.limpiar();
          }).catch(function(error){console.log(error)});
            this.$router.push('/usuarios');
          }
      }
    
  }
};
</script>