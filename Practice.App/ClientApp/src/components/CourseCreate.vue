
<template>
    <div class="container">
        <div class="card">
            <div class="card-header">
                <h3>Add Course</h3>
            </div>
            <div class="card-body">
                <form v-on:submit.prevent="addItem">
                    <div class="form-group">
                        <label>Title:</label>
                        <input type="text" class="form-control" v-model="item.Title" />
                    </div>
                    <div class="form-group">
                        <input type="submit" class="btn btn-primary" value="Add Item" />
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
        methods: {
            addItem() {
                let uri = 'https://localhost:5001/api/course';
                this.axios.post(uri, this.item).then((response) => {
                    console.log(response.data);
                    this.$router.push({ name: 'CourseIndex' }); 
                });
            }
        }
    }
</script>