<script setup lang="ts">
import MainDashboard from "./components/MainDashboard.vue";
</script>

<template>
  <header class="navbar bg-primary">
    <section class="navbar-section">
      <a href="/">
        <img alt="Vue logo" class="logo" src="./assets/logo.svg" height="36" />
      </a>
      <span class="navbar-brand ml-2 mr-2">Welcome to Upsub</span>
    </section>
  </header>

  <main>
    <MainDashboard msg="You did it!" />
  </main>

  <footer class="footer bg-dark">
    <span class="ml-2">&copy; 2020 Upsub. All rights reserved.</span>
  </footer>
</template>

<style>
@import "./assets/base.css";

#app {
  margin: 0 auto;

  font-weight: normal;
}

header.navbar {
  padding: 0.25rem;
  line-height: 1.5;
  border-bottom: solid 1px var(--color-border);
}

main {
  margin-bottom: calc(0.5rem + var(--footer-height));
}

.footer {
  position: fixed;
  height: var(--footer-height);
  left: 0;
  bottom: 0;
  right: 0;

  display: flex;
  align-items: center;
}
</style>
