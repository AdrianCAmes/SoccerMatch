<template>
 
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Equipos recomendados {{idEquipo}}</v-toolbar-title>
        <v-divider class="mx-2" inset vertical></v-divider>
        <v-spacer></v-spacer>
        <v-text-field
          class="text-xs-center"
          v-model="search"
          append-icon="search"
          label="Búsqueda"
          single-line
          hide-details
        ></v-text-field>
        <v-spacer></v-spacer>
        <v-dialog v-model="dialog" max-width="500px">
          <v-btn slot="activator" color="primary" dark class="mb-2">Nuevo</v-btn>
          <v-card>
            <v-card-title>
              <span class="headline">{{ formTitle }}</span>
            </v-card-title>

            <v-card-text>
              <v-container grid-list-md>               
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="nequipo" label="Nombre"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="tdescripcion" label="Descripcion"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12 >
                    <v-text-field v-model="dfechaJuego" label="Fecha de Juego"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="cdistrito" label="Distrito" ></v-text-field>
                  </v-flex>               
              </v-container>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" flat @click.native="close">Cancelar</v-btn>
              <v-btn color="blue darken-1" flat @click.native="guardar">Guardar</v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-toolbar>
<!-------------------------------------------------------------------------------------------------------------------------------------->

       <v-dialog v-model="verDetalleEquipo" max-width="800px">        
          <v-card>           
            <v-card-text>
                    
                  <v-data-table :headers="cabeceraDetalleEquipo" :items="lstaParticipantes" :search="search" class="elevation-1">
                      <template slot="items" slot-scope="props">        
                       <td>{{ props.item.nombreUsuario }}</td>
                       <td>{{ props.item.userUsuario }}</td>
                       <td>{{ props.item.numeroContacto }}</td>
                       </template>        
                   </v-data-table>      
           
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" flat @click.native="ocultarDetallesEquipo">Atras</v-btn>
              <!--v-btn color="blue darken-1" flat @click.native="guardar">Guardar</v-btn -->
            </v-card-actions>

          </v-card>
        </v-dialog>
<!-------------------------------------------------------------------------------------------------------------------------------------->
      <v-data-table :headers="headers" :items="equipos" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>          
          </td>
          <td>{{ props.item.nequipo }}</td>
          <td>{{ props.item.tdescripcion }}</td>
          <td>{{ props.item.numParticipantes }}</td>
          <td>{{ props.item.dfechaJuego }}</td>
          <td>{{ props.item.cdistrito }}</td >   
            <td>  
               <v-flex xs12 sm2 md2 lg2 xl2>
                      <v-btn @click="mostrarDetallesEquipo(props.item)" small fab dark color="teal">
                        <v-icon dark>list</v-icon>
                    </v-btn>
                </v-flex>       
            </td >  
        </template>

        <template slot="no-data">
          <v-btn color="primary" @click="listar">Resetear</v-btn>
        </template>
      </v-data-table>

    </v-flex>

</template>
<script>
import axios from "axios";
export default {
  data() {
    return {
      equipos: [],
      dialog: false,
      headers: [    
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Nombre", value: "nequipo", sortable: false },     
        { text: "Descripcion", value: "tdescripcion", sortable: false },  
        { text: "Numero de participantes", value: "numParticipantes" },  
        { text: "Fecha de juego", value: "dfechaJuego" },
        { text: "Distrito", value: "cdistrito"},
        { text: "VerDetalle", value: "detalle"}
        
      ],
        cabeceraDetalleEquipo: [    
        { text: "Nombre Jugador", value: "njugador", sortable: false },
        { text: "Usuario", value: "usuario", sortable: false },     
        { text: "Numero de Contacto", value: "numContacto", sortable: false },  
       
        
      ],
      search: "",
      editedIndex: -1,

      //TODO:Model
      cequipo : '',
      tdescripcion :  '',
      nequipo :  '',
      numParticipantes :  '',
      dfechaJuego :  '',
      cdistrito : '',
      

      //para la vista detalleEquipo
      verDetalleEquipo:0,
      lstaParticipantes:[],
      idEquipo:'',
    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nuevo Equipo" : "Actualizar Equipo";
    }
  },

  watch: {
    dialog(val) {
      val || this.close();
    }
  },

  created() {
    this.setListaEquiposRecomendados();    
  },
  methods: {
    setListaEquiposRecomendados(){
  let me =this;    
  axios.get("api/equipo/recomendados/"+localStorage.getItem("usuario"))//INSERTAR AQUIE EL IDUSUARIO  EN LUGAR DEL 2
       .then(function(response) {
          console.log(response);
          me.equipos = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
},
    listar() {
      let me = this;
      axios
        .get("api/equipo")
        .then(function(response) {
          console.log(response);
          me.equipos = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    editItem(item) {
      this.cequipo = item.cequipo;
      this.tdescripcion = item.tdescripcion;
      this.nequipo = item.nequipo;
      this.numParticipantes = item.numParticipantes;
      this.dfechaJuego = item.dfechaJuego;
      this.cdistrito = item.cdistrito;

      this.editedIndex = 1;
      this.dialog = true;
    },
    close() {
      this.dialog = false;
    },
    limpiar() {
      this.cequipo = "";
      this.tdescripcion = "";
      this.cdistrito = "";
      this.nequipo = "";
      this.numParticipantes = "";
      this.dfechaJuego = "";
    },
   guardar() {
      if (this.editedIndex > -1) {
        //Código para editar

        let me = this;
        axios 
          .put("api/equipo", {
            cequipo: me.cequipo,
            tdescripcion: me.tdescripcion,
            cdistrito: me.cdistrito,
            nequipo: me.nequipo,
            numParticipantes: me.numParticipantes,
            dfechaJuego: me.dfechaJuego
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
          .post("api/equipo", {
           tdescripcion: me.tdescripcion,
            cdistrito: me.cdistrito,
            nequipo: me.nequipo,
            numParticipantes: me.numParticipantes,
            dfechaJuego: me.dfechaJuego
          })
          .then(function(response) {
            me.close();
            me.listar();
            me.limpiar();
          })
          .catch(function(error) {
            console.log(error);
          });
      }
    },
    setearParticipantes(){
         let me = this;
      axios
      //http://localhost:5001/api/equipo/equipodetalle/3
        .get("/api/equipo/equipodetalle/"+me.idEquipo)
        .then(function(response) {
          console.log(response);
          me.lstaParticipantes = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },

    mostrarDetallesEquipo(data =[]){
     this.verDetalleEquipo=1;
     this.idEquipo=data["cequipo"];
     this.setearParticipantes();
    },
    ocultarDetallesEquipo(){
this.verDetalleEquipo=0;
    }
  }
};
</script>