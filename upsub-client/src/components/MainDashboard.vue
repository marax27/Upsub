<script lang="ts">
import { defineComponent } from "vue";

type MockupTab = { id: number; loaded: boolean };

export default defineComponent({
  data() {
    return {
      tabs: [
        { id: 1, loaded: false },
        { id: 2, loaded: false },
        { id: 3, loaded: false },
      ] as MockupTab[],
    };
  },
  mounted() {
    this.tabs.forEach((value, index) => {
      setTimeout(() => {
        this.tabs[index].loaded = true;
      }, index * 1000);
    });
  },
});
</script>

<template>
  <div class="container">
    <div class="columns">
      <div class="column col-12">
        <div class="card">
          <div class="card-header">
            <div class="card-title h5">
              Space for some headings, summaries, buttons.
            </div>
          </div>
        </div>
      </div>

      <div v-for="tab in tabs" :key="tab.id" class="column col-6 col-xl-12">
        <div class="card">
          <div class="card-header">
            <div class="card-title h5">Title</div>
            <div class="card-subtitle text-gray">Subtitle</div>
          </div>
          <div class="card-body">
            <div v-if="tab.loaded">
              <span>Tab loaded successfully.</span>
            </div>
            <span v-else>Loading...</span>
          </div>
          <div class="card-footer">
            <button class="btn btn-primary">...</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped></style>
