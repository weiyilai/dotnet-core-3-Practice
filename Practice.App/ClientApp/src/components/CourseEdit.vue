
<template>
    <div class="container">
        <div class="card">
            <div class="card-header">
                <h3>Edit Course</h3>
            </div>
            <div class="card-body">
                <form v-on:submit.prevent="updateItem">
                    <div class="form-group">
                        <label>Title:</label>
                        <input type="text" class="form-control" v-model="item.Title" />
                    </div>
                    <div class="form-group">
                        <label>Credits:</label>
                        <input type="text" class="form-control" v-model.number="item.Credits" />
                    </div>
                    <div class="form-group">
                        <input type="submit" class="btn btn-primary" value="Update Item" />
                    </div>
                </form>
            </div>
        </div>
    </div>
</template>
<script>
    export default {
        data() {
            return {
                item: {}
            }
        },

        created: function () {
            this.getItem();
        },

        methods: {
            getItem() {
                let uri = 'https://localhost:5001/api/course/' + this.$route.params.id;
                this.axios.get(uri).then((response) => {
                    this.item = response.data;
                });
            },
            updateItem() {
                //let uri = 'https://localhost:5001/api/course/' + this.$route.params.id;
                this.axios({
                    method: 'put',
                    baseURL: 'https://localhost:5001',
                    url: '/api/course/' + this.$route.params.id,
                    'Content-Type': 'application/json',
                    data: this.item
                })
                    .then((result) => { console.log(result); this.$router.push({ name: 'CourseIndex' }); })
                    .catch((err) => { console.error(err) });
            }
        }
    }
</script>