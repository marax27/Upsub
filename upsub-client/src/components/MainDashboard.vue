<script lang="ts">
import { dashboardFeedHubFactoryKey } from "@/injection";
import type DashboardFeedHubFactory from "@/real-time/DashboardFeedHub";
import { defineComponent, inject } from "vue";
import { Chart } from "highcharts-vue";

type MockupTab = { id: number; loaded: boolean; options: unknown };

function createPlotOptions(series: unknown[]): any {
  return {
    title: { text: "Plot title" },
    subtitle: { text: "Plot subtitle" },
    legend: { layout: "horizontal" },
    series,
  };
}

export default defineComponent({
  components: {
    Chart,
  },
  data() {
    return {
      tabs: [
        { id: 1, loaded: false, options: [] },
        { id: 2, loaded: false, options: [] },
        { id: 3, loaded: false, options: [] },
      ] as MockupTab[],
    };
  },
  async setup() {
    const factory = inject<DashboardFeedHubFactory>(dashboardFeedHubFactoryKey);
    if (factory == undefined) {
      throw new Error("Hub Factory is undefined.");
    }

    return {
      hub: await factory.create(),
    };
  },
  mounted() {
    this.hub.on("NewData", (data: unknown[]) => {
      this.tabs[0].options = createPlotOptions(data);
    });

    this.tabs.forEach((value, index) => {
      setTimeout(() => {
        this.tabs[index].loaded = true;
      }, index * 1000);
    });
  },
});
</script>

<template>
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
            <Chart :options="tab.options"></Chart>
          </div>
          <span v-else>Loading...</span>
        </div>
        <div class="card-footer">
          <button class="btn btn-primary">...</button>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped></style>
