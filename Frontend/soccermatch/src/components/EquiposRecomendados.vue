<template>
 <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Equipos recomendados  </v-toolbar-title>
        
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
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="numParticipantes" label="Numero de Participantes Para Jugar"></v-text-field>
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
<!-------------------------------------------------------------------------------------------------------------------------------------->

       <v-dialog v-model="verDetalleEquipo" max-width="800px">        
          <v-card>        
                <v-card-title>
              <span class="headline">Detalles del Equipo</span>
            </v-card-title>   
            <v-card-text>
                    <h4>PARTICIPANTES</h4>
                  <v-data-table :headers="cabeceraDetalleEquipo_PARTICIPANTES" :items="lstaParticipantes" :search="search" class="elevation-1">
                      <template slot="items" slot-scope="props">        
                       <td>{{ props.item.nombreUsuario }}</td>
                       <td>{{ props.item.userUsuario }}</td>
                       <td>{{ props.item.numeroContacto }}</td>
                       </template>        
                   </v-data-table>                
            </v-card-text>

              <v-card-text>
                   <v-spacer></v-spacer> <h4>Alquiler</h4>
                  <v-data-table :headers="cabeceraDetalleEquipo_Alquiler" :items="lstaAlquilerDelEquipo" :search="search" class="elevation-1">
                      <template slot="items" slot-scope="props">        
                       <td>{{ props.item.ncancha }}</td>
                       <td>{{ props.item.fInicio }}</td>
                       <td>{{ props.item.tdireccion }}</td>
                       <td>{{ props.item.ndistrito }}</td>
                       <td>{{ props.item.numparticipantes }}</td>
                       <td>{{ props.item.numhoras }}</td>
                       </template>        
                   </v-data-table>   
                    </v-card-text>  
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" flat @click.native="ocultarDetallesEquipo">Atras</v-btn>
              <v-btn color="blue darken-1" flat @click.native="unirJugador">Unirse</v-btn>
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
          <td>{{ props.item.numParticipantesActual }}</td>
          <td>{{ props.item.numParticipantes }}</td>     
          <td>{{ props.item.dfechaJuego }}</td>
          <td>{{ props.item.ndistrito }}</td >
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
 </v-layout>
</template>
<script>
import axios from "axios";
import router from "vue-router"
export default {
  data() {
    return {
      equipos: [],

      dialog: false,
     headers: [    
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Nombre", value: "nequipo", sortable: false },     
        { text: "Descripcion", value: "tdescripcion", sortable: false },  
        { text: "Participantes Actualmente", value: "Participantes_A", sortable: false },  
         { text: "Participantes Esperados", value: "Participantes_E", sortable: false },         
        { text: "Fecha de juego", value: "dfechaJuego" },
        { text: "Distrito", value: "ndistrito"}        
      ],
        cabeceraDetalleEquipo_PARTICIPANTES: [    
        { text: "Nombre Jugador", value: "njugador", sortable: false },
        { text: "Usuario", value: "usuario", sortable: false },     
        { text: "Numero de Contacto", value: "numContacto", sortable: false },     
        
      ],
       
      cabeceraDetalleEquipo_Alquiler:[
        { text: "Cancha", value: "Cancha", sortable: false },
        { text: "Fecha de Inicio", value: "Fecha", sortable: false },     
        { text: "Direccion de cancha", value: "Direccion", sortable: false },  
        { text: "Distrito", value: "Distrito", sortable: false },  
        { text: "Participantes", value: "Distrito", sortable: false },       
        { text: "Horas", value: "horas", sortable: false }, 
      ],
      search: "",
      editedIndex: -1,

      //TODO:Model
      cequipo : '',
      tdescripcion :  '',
      nequipo :  '',
      numParticipantes :  '',
      dfechaJuego :  '',
      ndistrito: '',
      menu: false,

      distritos: [],
      cdistrito:'',

      //para la vista detalleEquipo
      verDetalleEquipo:0,
      lstaParticipantes:[],
      idEquipo:'',
      lstaAlquilerDelEquipo:[],


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
    this.setListaDistritos();
  },
  methods: {
    GuardarAlquiler(){

    },
    setListaEquiposRecomendados(){
  let me =this;    
  axios.get("api/equipo/recomendados/"+localStorage.getItem("usuario"))//INSERTAR AQUIE EL IDUSUARIO  EN LUGAR DEL 2
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
      this.ndistrito = "";
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
            ndistrito: me.ndistrito,
            nequipo: me.nequipo,
            numParticipantes: me.numParticipantes,
            dfechaJuego: me.dfechaJuego
          })
          .then(function(response) {
            me.close();
            me.setListaEquiposRecomendados();
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
            numParticipantes: me.numParticipantes,
            DfechaJuego: me.dfechaJuego,
            DfechaRegistro: f,
            idJugador: Number(localStorage.getItem('usuario')),
          })
          .then(function(response) {
            me.close();
            me.setListaEquiposRecomendados();
            me.limpiar();
            me.$router.push('/equipo/misequipos');
          })
          .catch(function(error) {
            console.log(error);
          });
      }
    },
    setearParticipantes(){
         let me = this;
      axios
      
        .get("/api/equipo/equipodetalle/"+me.idEquipo)
        .then(function(response) {
          console.log(response);
          me.lstaParticipantes = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
     setearLstaAlquileresDelEquipo(){
         let me = this;
      axios
      
        .get("/api/alquiler/alquilerdetalle/"+me.idEquipo)
        .then(function(response) {
          console.log(response);
          me.lstaAlquilerDelEquipo = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    mostrarDetallesEquipo(data =[]){
     this.verDetalleEquipo=1;
     this.idEquipo=data["cequipo"];
     localStorage.setItem("equipo", this.idEquipo);
     this.setearParticipantes();
     this.setearLstaAlquileresDelEquipo();
    },
    ocultarDetallesEquipo(){
      this.verDetalleEquipo=0;
      localStorage.removeItem("equipo");
    },
    unirJugador(){
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
        .post("api/participante", {
          cjugador: Number(localStorage.getItem('usuario')),
          cequipo: Number(localStorage.getItem("equipo")),
          fesadministrador: false,
          dfechaunion: f,
        })
        .then(function(response) {
          me.close();
          me.setListaEquiposRecomendados();
          me.limpiar();
          localStorage.removeItem("equipo"),
          me.$router.push('/equipo/misequipos');
          alert("Usted se unió exitosamente al grupo :)");
        })
        .catch(function(error) {
            console.log(error);
        });
    }
  }
};
</script>