<template>
  <div class="container">
    <div class="row">
      <div class="col-md-6">
        <div>
          <form @submit.prevent="selectCompany()">
            Companies:
            <select v-model="companyId">
              <option
                v-for="com in companies"
                :key="com.id"
                class="selectable"
                :value="com.id"
              >
                {{ com.name }}
              </option>
            </select>
            <button type="submit">Submit</button>
          </form>
        </div>
      </div>
      <div class="col-md-6">
        Contractors:
        <ul>
          <li v-for="con in contractors" :key="con.id">{{ con.name }}</li>
        </ul>
      </div>
    </div>
    <div class="row">
      <div class="col-3"></div>
      <div class="col-6">
        <h6>Contractors currently working for selected company:</h6>
        <ul>
          <li v-for="scc in selectedCompanyContractors" :key="scc.id">
            <!-- The job association goes here -->
            {{ scc.name }} - {{ scc.type }} -${{ scc.rate }}
          </li>
        </ul>
      </div>
      <div class="col-3"></div>
    </div>
  </div>
</template>


<script>
import { computed, onMounted, ref } from '@vue/runtime-core'
import { companiesService } from "../services/CompaniesService.js"
import { contractorsService } from "../services/ContractorsService.js"
import { AppState } from '../AppState.js'
import { logger } from '../utils/Logger.js'
export default {
  setup() {
    const companyId = ref(0)
    onMounted(async () => {
      await companiesService.getCompanies()
      await contractorsService.getContractors()
    })
    return {
      companyId,
      companies: computed(() => AppState.companies),
      contractors: computed(() => AppState.contractors),
      selectedCompanyContractors: computed(() => AppState.selectedCompanyContractors),

      async selectCompany() {
        logger.log("value", companyId)
        AppState.selectedCompany = companyId
        await companiesService.getContractorsByCompanyId(companyId)
      }
    }
  }
}
</script>


<style lang="scss" scoped>
</style>