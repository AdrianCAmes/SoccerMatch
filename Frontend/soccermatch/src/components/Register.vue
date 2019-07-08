<template>
  <v-form v-model="valid">
    <v-container grid-list-xl text-xs-center>
      <v-layout column>
        <v-flex xs12 md4 offset-xs8>
          <v-text-field
            v-model="nusuario"
            :counter="10"
            label="Nombre"
            required
          ></v-text-field>
        </v-flex>
                <v-flex xs12 md4 offset-xs8>
          <v-text-field
            v-model="direccion"
            :counter="10"
            label="Direccion"
            required
          ></v-text-field>
        </v-flex>
        <v-flex
          xs12
          md4
          offset-xs8
        >
          <v-text-field
            v-model="usuario1"
            :counter="10"
            label="Usuario"
            required
          ></v-text-field>
        </v-flex>

        <v-flex
          xs12
          md4
          offset-xs8
        >
          <v-text-field
            v-model="pswd"
            label="Contraseña"
            required
          ></v-text-field>
        </v-flex>
                <v-flex
          xs12
          md4
          offset-xs8
        >
          <v-text-field
            v-model="cpswd"
            label="Confirmar contraseña"
            required
          ></v-text-field>
        </v-flex>
                <v-flex
          xs12
          md4
          offset-xs8
        >
          <v-text-field
            v-model="cdni"
            label="DNI"
            required
          ></v-text-field>
        </v-flex>
                <v-flex
          xs12
          md4
          offset-xs8
        >
          <v-text-field
            v-model="numTelefono"
            label="Telefono"
            required
          ></v-text-field>
          <v-btn   @click="guardar()" slot="activator" color="primary" dark class="mb-2">Registrarse</v-btn>    
        </v-flex>
      </v-layout>
    </v-container>
  </v-form>
</template>
<script>
import axios from "axios";
import router from "vue-router";
export default {
  data() {
    return {
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