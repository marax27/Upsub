<script setup lang="ts">
import { onErrorCaptured, ref } from "vue";
import MainDashboard from "./components/MainDashboard.vue";

let errorMessage = ref<string | null>(null);

onErrorCaptured((e) => {
  errorMessage.value = e.message;
});
</script>

<template>
  <header class="navbar bg-primary">
    <section class="navbar-section">
      <a href="/">
        <img alt="Logo" class="logo ml-2" src="./assets/logo.svg" height="36" />
      </a>
      <span class="navbar-brand ml-2 mr-2">Welcome to Upsub</span>
    </section>
  </header>

  <main>
    <Suspense>
      <template #default>
        <MainDashboard />
      </template>
      <template #fallback>
        <div class="container">
          <div class="columns">
            <div v-if="errorMessage == null" class="column col-12">
              <div class="loading loading-lg"></div>
            </div>
            <div v-else class="column col-8 col-lg-12">
              <div class="toast toast-error">Error: {{ errorMessage }}</div>
            </div>
          </div>
        </div>
      </template>
    </Suspense>
  </main>

  <footer class="footer container">
    <span>&copy; 2020 Upsub. All rights reserved.</span>
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
  margin-bottom: 0.5rem;
}

.footer {
  position: relative;
  height: var(--footer-height);
  margin-top: 0.5rem;
  display: flex;
  align-items: center;
}
</style>
