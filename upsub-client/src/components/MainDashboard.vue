<script setup lang="ts">
defineProps<{
  msg: string;
}>();
</script>

<template>
  <div class="container">
    <div class="columns">
      <div
        v-for="i in [1, 2, 3, 4, 5, 6]"
        :key="i"
        class="column col-6 col-lg-12"
      >
        <div class="card">
          <div class="card-header">
            <div class="card-title h5">Title</div>
            <div class="card-subtitle text-gray">Subtitle</div>
          </div>
          <div class="card-body">
            Lorem ipsum dolor sit amet consectetur adipisicing elit. Numquam,
            ducimus minus in neque, velit earum ipsum totam error debitis
            aliquam reiciendis corrupti, cumque vero voluptas quia magni dolorem
            blanditiis! Saepe.
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
