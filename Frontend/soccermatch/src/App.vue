<template>
  <v-app id="app">
    <v-navigation-drawer
      fixed
      :clipped="$vuetify.breakpoint.mdAndUp"
      app
      v-model="drawer"
    >
      <v-list dense>

        <template>

          <v-list-group>
            <v-list-tile slot="activator">
              <v-list-tile-content>
                <v-list-tile-title>
                  Equipos
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>
           
            <v-list-tile :to="{ name: 'equipoRecomendados'}">
              <v-list-tile-action>
                <v-icon large color="teal darken-2">supervisor_account</v-icon>
              </v-list-tile-action>
              
              <v-list-tile-content>
                <v-list-tile-title>
                  Equipos Recomendados
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

            <v-list-tile :to="{ name: 'misEquipos'}">
              <v-list-tile-action>
                <v-icon large color="teal darken-2">group</v-icon>
              </v-list-tile-action>
              
              <v-list-tile-content>
                <v-list-tile-title>
                  Mis Equipos
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

          </v-list-group>
        </template>
        
        <template>
          <v-list-tile :to="{name:'home'}">
            <v-list-tile-action>
              <v-icon large color="blue-grey darken-2">keyboard_backspace</v-icon>
            </v-list-tile-action>

            <v-list-tile-title>
              Cerrar Sesión
            </v-list-tile-title>
          </v-list-tile>
        </template>
       
        
      </v-list>
    </v-navigation-drawer>
    <v-toolbar
      color="blue darken-3"
      dark
      app
      :clipped-left="$vuetify.breakpoint.mdAndUp"
      fixed
    >
      <v-toolbar-title style="width: 300px" class="ml-0 pl-3">
        <v-toolbar-side-icon @click.stop="drawer = !drawer"></v-toolbar-side-icon>
        <span class="hidden-sm-and-down">SoccerMatch</span>
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn icon>
        <v-icon>apps</v-icon>
      </v-btn>
    </v-toolbar>
    <v-content>
      <v-container fluid fill-height>
        <v-slide-y-transition mode="out-in">
          <router-view/>
        </v-slide-y-transition>
      </v-container>
    </v-content>
    <v-footer dark height="auto">
      <v-layout justify-center>
        <v-flex text-xs-center>
          <v-card flat tile color="primary" class="white--text">
            <v-card-text class="white--text pt-0">
             HAMP &copy;2019
            </v-card-text>
          </v-card>
        </v-flex>
      </v-layout>
    </v-footer>

  </v-app>
</template>


<script>

export default {
  name: 'App',
  data () {
    return {
      drawer: false,
     }
  }
}
</script>

