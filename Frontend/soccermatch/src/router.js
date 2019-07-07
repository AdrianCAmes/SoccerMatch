import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import Usuario from './components/Usuario.vue'
import Register from './components/Register.vue'
import EquiposRecomendados from './components/EquiposRecomendados.vue'
Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/usuarios',
      name: 'usuarios',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: Usuario
    },
    {
      path:'/register',
      name:'register',
      component:Register
    },
    {
      path:'/equipo',
      name:'equipo',
      component:EquiposRecomendados
    }
  
  ]
})
