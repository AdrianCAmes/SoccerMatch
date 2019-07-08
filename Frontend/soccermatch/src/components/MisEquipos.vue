<template>
 <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Mis Equipos </v-toolbar-title>
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
<!------------------------------------------------------------------------------------------>

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
                        <td>  
               <v-flex xs12 sm2 md2 lg2 xl2>
                      <v-btn @click="pagarAlquiler(props.item)" small fab dark color="teal">
                        <v-icon dark>money</v-icon>
                    </v-btn>
                </v-flex>       
            </td >    
                       </template>        
                   </v-data-table>   
                    </v-card-text>  
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" flat @click.native="ocultarDetallesEquipo">Atras</v-btn>
              <v-btn color="blue darken-1" flat @click.native="setMostrarFrmAlquilerTrue">Nuevo Alquiler</v-btn>
            </v-card-actions>

          </v-card>
        </v-dialog>
        <!------------------------------------------------------------------------------------------------------>
        <v-dialog v-model="mostrarFrmCanchas" max-width="1000px">
                <v-card>
                    <v-card-title>
                        <span class="headline">Seleccione una cancha</span>
                    </v-card-title>
                    <v-card-text>
                        <v-container grid-list-md>
                            <v-layout wrap>
                                <v-flex xs12 sm12 md12 lg12 xl12>
                                    <template>
                                        <v-data-table :headers="cabeceraCancha" :items="canchaFrm" class="elevation-1">
                                            <template slot="items" slot-scope="props">
                                              <td class="justify-center layout px-0">
                                                <v-icon small class="mr-2" @click="agregarCancha(props.item)">
                                                    add
                                                </v-icon>
                                              </td>
                                              <td>{{ props.item.ccancha }}</td>
                                              <td>{{ props.item.ncancha }}</td>
                                              <td>{{ props.item.mprecioHora }}</td>
                                              <td>{{ props.item.ncalle }}</td>
                                              <td>{{ props.item.ndistrito }}</td>
                                            </template>
                                            <template slot="no-data">
                                                <h3>No hay canchas para mostrar.</h3>
                                            </template>
                                        </v-data-table>
                                    </template>
                                </v-flex>
                            </v-layout>
                        </v-container>
                    </v-card-text>
                    <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn @click="setFrmCanchasFalse()" color="blue darken" flat>
                            Cancelar
                        </v-btn>
                    </v-card-actions>
                </v-card>
            </v-dialog>

        <!------------------------------------------------------------------------------------------------------>
        <v-dialog v-model="dialog" max-width="800px">
          <v-btn slot="activator" color="primary" dark class="mb-2" v-if="mostrarFrmAlquiler == false">Nuevo</v-btn>
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

      <v-data-table :headers="headers" :items="equipos" :search="search" class="elevation-1" v-if="mostrarFrmAlquiler == false">
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
      
        <v-container grid-list-sm class="pa-4 white" v-if="mostrarFrmAlquiler == true" max-width="800px">
          
              <span class="headline">Nuevo Alquiler</span>
                <v-flex>
                  <td>Código de Equipo: {{this.alquilerEquipo}}</td>
                </v-flex>
                <v-layout column>
                    <v-menu
                      v-model="menu2"
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
                          v-model="alquilerFechaInicio"
                          label="Fecha del alquiler"
                          prepend-icon="event"
                          readonly
                          v-on="on"
                        ></v-text-field>
                      </template>
                      <v-date-picker v-model="alquilerFechaInicio" @input="menu2 = false"></v-date-picker>
                    </v-menu>

                      <v-menu
                        ref="menu"
                        v-model="menu3"
                        :close-on-content-click="false"
                        :nudge-right="40"
                        :return-value.sync="alquilerHoraInicio"
                        lazy
                        transition="scale-transition"
                        offset-y
                        full-width
                        max-width="290px"
                        min-width="290px"
                      >
                        <template v-slot:activator="{ on }">
                          <v-text-field
                            v-model="alquilerHoraInicio"
                            label="Hora de Alquiler"
                            prepend-icon="access_time"
                            readonly
                            v-on="on"
                          ></v-text-field>
                        </template>
                        <v-time-picker
                          v-if="menu3"
                          v-model="alquilerHoraInicio"
                          format="24hr"
                          full-width
                          @click:minute="$refs.menu.save(alquilerHoraInicio)"
                        ></v-time-picker> 
                      </v-menu>

                        <v-text-field v-model="alquilerHoras" label="Horas de Reserva">
                        </v-text-field>

                    <v-btn @click="setFrmCanchasTrue()" small fab dark color="teal">
                        <v-icon dark>list</v-icon>
                    </v-btn>
                    
                    
                    <v-data-table :headers="cabeceraCancha" :items="canchas" hide-actions class="elevation-1">
                        <template slot="items" slot-scope="props">
                          <td class="justify-center layout px-0">
                            <v-icon small class="mr-2" @click="eliminarCancha()">
                              delete
                            </v-icon>
                          </td>
                          <td>{{ props.item.ccancha }}</td>
                          <td>{{ props.item.ncancha }}</td>
                          <td>{{ props.item.mprecioHora }}</td>
                          <td>{{ props.item.ncalle }}</td>
                          <td>{{ props.item.ndistrito }}</td>
                        </template>
                        <template slot="no-data">
                            <h3>No hay canchas que mostrar.</h3>
                        </template>
                    </v-data-table>

                    <v-btn @click="setCancelarAlquiler()" color="blue darken-1" flat>Cancelar</v-btn>
                    <v-btn @click="guardarAlquiler()" color="success">Guardar</v-btn>
            </v-layout>
        </v-container>


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
        { text: "Participantes", value: "Participantes", sortable: false },  
        { text: "Horas", value: "horas", sortable: false }, 
      ],

      cabeceraCancha:[
        { text: "Opcion", value: "opcion", sortable: false },
        { text: "ID", value: "ccancha", sortable: false },
        { text: "Nombre", value: "ncancha", sortable: false },     
        { text: "Precio por hora", value: "Direccion", sortable: false },
        { text: "Calle", value: "Calle", sortable: false },  
        { text: "Distrito", value: "Distrito", sortable: false },   
      ],


      search: "",
      editedIndex: -1,

      distritos: [],
      canchas: [],
      canchaFrm:[],

      //TODO:Model
      nequipo: "",
      tdescripcion:"",
      dfechaJuego:"",
      ndistrito:"",
      numParticipantes: '',
      menu: false,
      menu2: false,
      menu3: false,

      mostrarFrmAlquiler: false,
      mostrarFrmCanchas: false,

     //para la vista detalleEquipo
      verDetalleEquipo:0,
      lstaParticipantes:[],
      participantes:[],
      idEquipo:'',
      lstaAlquilerDelEquipo:[],

      //para frm alquiler
      alquilerEquipo: '',
      alquilerCancha: '',
      alquilerFechaInicio: '',
      alquilerHoraInicio: '',
      alquilerRegistro: '',
      alquilerHoras:'',
      alquilerDescuento: 0,
      alquilerTotal: '',
      alquilerPagado: false,

      tempNumParticipantes:0,
      btn_desactivado:true,
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
    this.setListaCanchas();
  },
  methods: {
    validarFecha(){
         let me =this;    
      axios.get("api/equipo/misequipos/"+localStorage.getItem("usuario"))//INSERTAR AQUIE EL IDUSUARIO  EN LUGAR DEL 2
          .then(function(response) {
              me.equipos = response.data;
            })
            .catch(function(error) {
              console.log(error);
            });
    },
    pagarAlquiler(){

     },
    
    agregarCancha(data = []) {
      this.canchas = [];
      this.canchas.push({
        ccancha: data['ccancha'],
        ncancha: data['ncancha'],
        mprecioHora: data['mprecioHora'],
        ncalle: data['ncalle'],
        ndistrito: data['ndistrito']
      });
      this.setFrmCanchasFalse();
    },

    eliminarCancha() {
      this.canchas = [];
    },

    AlquilarFuncion(){
       tempNumParticipantes
    },
    setFrmCanchasTrue(){
      this.mostrarFrmCanchas = true;
    },
    setFrmCanchasFalse(){
      this.mostrarFrmCanchas = false;
    },
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
    setListaCanchas() {
      let me = this;
      axios.get("api/cancha")
      .then(function(response) {
        me.canchaFrm = response.data;
      }) 
      .catch(function(error) {
        console.log(error);
      });
    },
    setMostrarFrmAlquilerTrue() {let me = this;

      var dFechaRegistro = new Date();
      var dia = dFechaRegistro.getDate();
      var mes = dFechaRegistro.getMonth();
      var anio = dFechaRegistro.getFullYear();
      var hora = dFechaRegistro.getHours();
      var minutos = dFechaRegistro.getMinutes();
      var segundos = dFechaRegistro.getSeconds();

      var f = dia+'-'+mes+'-'+anio+' '+hora+':'+minutos+':'+segundos;
      
      me.alquilerEquipo = localStorage.getItem("equipo"),
      me.alquilerRegistro = f,
      
      this.ocultarDetallesEquipo();
      this.mostrarFrmAlquiler = true;
    },
    setMostrarFrmAlquilerFalse() {
      this.limpiar();
      this.mostrarFrmAlquiler = false;
    },
    setCancelarAlquiler() {
      this.setMostrarFrmAlquilerFalse();
      localStorage.removeItem("equipo");
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
            me.setListaMisEquipos();
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
            me.setListaMisEquipos();
            me.limpiar();
            alert("!Registro exitoso!");
          })
          .catch(function(error) {
            console.log(error);
          });
      }
      
    },
    guardarAlquiler(){
      let me = this;

      var dFechaRegistro = new Date();
      var dia = dFechaRegistro.getDate();
      var mes = dFechaRegistro.getMonth();
      var anio = dFechaRegistro.getFullYear();
      var hora = dFechaRegistro.getHours();
      var minutos = dFechaRegistro.getMinutes();
      var segundos = dFechaRegistro.getSeconds();
      
      var f = dia+'-'+mes+'-'+anio+' '+hora+':'+minutos+':'+segundos;

      var dFechaInicio = new Date();
      dFechaInicio = me.alquilerFechaInicio+' '+me.alquilerHoraInicio;

      axios
      .post("/api/alquiler", {
        cequipo: me.alquilerEquipo,
        canchas: me.canchas,
        dfechaInicio: dFechaInicio,
        dfechaRegistro: f,
        numhoras: me.alquilerHoras,
        participantes: me.participantes,
      }).then(
        me.setMostrarFrmAlquilerFalse(),
        alert("!Registro exitoso!"),
        me.alquilerEquipo = '',
        me.alquilerCancha = '',
        me.alquilerFechaInicio = '',
        me.alquilerHoraInicio = '',
        me.alquilerRegistro= '',
        me.alquilerHoras = '',
        me.alquilerDescuento = '',
        me.alquilerTotal = '',
        me.alquilerPagado = '',
      )

      

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
    getAllParticipantes(){
         let me = this;
      axios
      
        .get("/api/equipo/usuarios/"+me.idEquipo)
        .then(function(response) {
          console.log(response);
          me.participantes = response.data;
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
      localStorage.removeItem("equipo");
       this.tempNumParticipantes=data["numParticipantesActual"];
       var participantesMaximo=data["numParticipantes"];
       if (this.tempNumParticipantes>=participantesMaximo) this.btn_desactivado=false;
       else{this.btn_desactivado=true;}
      this.verDetalleEquipo=1;
      this.idEquipo=data["cequipo"];
      localStorage.setItem("equipo", this.idEquipo);
      this.setearParticipantes();
      this.setearLstaAlquileresDelEquipo();
      this.getAllParticipantes();
    },
    ocultarDetallesEquipo(){
      this.verDetalleEquipo=0;
    },
  }
};
</script>