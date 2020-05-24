<!--<template>
  <div id="app">
    <img alt="Vue logo" src="./assets/logo.png">
    <HelloWorld msg="Welcome to Your Vue.js App"/>
  </div>
</template>

<script>
import HelloWorld from './components/HelloWorld.vue'

export default {
  name: 'App',
  components: {
    HelloWorld
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>-->

<template>
    <div id="app" class="container">
        <nav class="navbar navbar-expand-sm bg-light">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <router-link :to="{ name: 'CourseCreate' }" class="nav-link">Add Item</router-link>
                </li>
                <li class="nav-item">
                    <router-link :to="{ name: 'CourseIndex' }" class="nav-link">All Items</router-link>
                </li>
            </ul>
        </nav>
        <transition name="fade">
            <div class="gap">
                <router-view></router-view>
            </div>
        </transition>
    </div>
</template>

<script>

    export default {
    }
</script>

<style>
    .fade-enter-active, .fade-leave-active {
        transition: opacity .5s
    }

    .fade-enter, .fade-leave-active {
        opacity: 0
    }

    .gap {
        margin-top: 50px;
    }
</style>