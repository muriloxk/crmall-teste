<template>
  <div id="app">
    <nav>
        <ul>  
            <li v-for="route in routes"  v-show="route.titulo">
                <router-link :to="route.path ? route.path : '/'" >{{route.titulo}}</router-link >
            </li>
        </ul>
    </nav>

    <router-view></router-view>

  </div>
</template>

<script>
  import { routes } from './routes';

  export default {
      data() {
        return {
          routes: routes.filter(route => route.menu == true),
        }
      }
  }
</script>

<style>

#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}



.lista-clientes{
  display: inline-block;
  border: 1px solid black;
}

.lista-clientes th{
    padding:10px;
    font-size:1.2rem;
}

.lista-clientes td{
  padding:10px;
  font-size:1rem;
}
</style>
