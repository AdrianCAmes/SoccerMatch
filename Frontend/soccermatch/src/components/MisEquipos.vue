<template>
 <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Mis Equipos</v-toolbar-title>
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
                  <v-flex>
                    <v-text-field v-model="tdescripcion" label="Descripcion"></v-text-field>
                  </v-flex>
                  <v-flex>
                    <v-menu
                      v-model="menu"
                      :close-on-content-click="false"
                      :nudge-right="40"
                      lazy
                      transition="scale-transition"
                      offset-y
                      full-width
                      min-width="290px"
                    >
                      <template v-slot:activator="{ on }">
                        <v-text-field
                          v-model="dfechaJuego"
                          label="Fecha de Juego"
                          prepend-icon="event"
                          readonly
                          v-on="on"
                        ></v-text-field>
                      </template>
                      <v-date-picker v-model="dfechaJuego" @input="menu = false"></v-date-picker>
                    </v-menu>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-combobox
                      v-model="ndistrito"
                      :items="distritos"
                      label="Distritos"
                    ></v-combobox>
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

      <v-data-table :headers="headers" :items="equipos" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
          </td>
          <td>{{ props.item.nequipo }}</td>
          <td>{{ props.item.tdescripcion }}</td>
          <td>{{ props.item.numParticipantes }}</td>
          <td>{{ props.item.dfechaJuego }}</td>
          <td>{{ props.item.ndistrito }}</td >            
        </template>

        <template slot="no-data">
          <v-btn color="primary" @click="listar">Resetear</v-btn>
        </template>
      </v-data-table>

    </v-flex>
 </v-layout>
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
        { text: "Distrito", value: "ndistrito"}
        
      ],
      search: "",
      editedIndex: -1,

      distritos: [],

      //TODO:Model
      nequipo: "",
      tdescripcion:"",
      dfechaJuego:"",
      ndistrito:"",
      menu: false,

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
    this.setListaMisEquipos();
    this.setListaDistritos();
  },
  methods: {
    setListaMisEquipos(){
      let me =this;    
      axios.get("api/equipo/misequipos/"+localStorage.getItem("usuario"))//INSERTAR AQUIE EL IDUSUARIO  EN LUGAR DEL 2
          .then(function(response) {
              me.equipos = response.data;
            })
            .catch(function(error) {
              console.log(error);
            });
    },
    setListaDistritos() {
      let me = this;
      axios.get("api/distrito/names")
      .then(function(response) {
        me.distritos = response.data;
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

        var dFechaRegistro = new Date();
        var dia = dFechaRegistro.getDate();
        var mes = dFechaRegistro.getMonth();
        var anio = dFechaRegistro.getFullYear();
        var hora = dFechaRegistro.getHours();
        var minutos = dFechaRegistro.getMinutes();
        var segundos = dFechaRegistro.getSeconds();

        var f = dia+'-'+mes+'-'+anio+' '+hora+':'+minutos+':'+segundos;

        axios
          .post("api/equipo", {
            Tdescripcion: me.tdescripcion,
            Nequipo: me.nequipo,
            ndistrito: me.ndistrito,
            numParticipantes: 1,
            DfechaJuego: me.dfechaJuego,
            DfechaRegistro: f,
            idJugador: Number(localStorage.getItem('usuario')),
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
    }
  }
};
</script>