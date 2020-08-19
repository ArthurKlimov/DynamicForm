export default SubmitComponent = {
  data() {
    return {
        submission: {
          name: '',
          occupation: 'Full-stack',
          like: true,
          favouriteFood: "Burgers"
        }
    }
  },
  methods: {
    submit: function() {
      let submission = this.submission;

      axios({
          method: 'post',
          url: 'https://localhost:44344/api/v1/submissions',
          contentType: 'application/json',
          data: submission,
          responseType: 'json'
      })
        .then(function (response) {
          console.log(response);
        })
        .catch(function (error) {
          console.log(error);
        });
  }
  },
  template: `
    <div class="container">
              <div class="row">
                  <div class="col-12">
                      <ul class="nav mt-4">
                          <li class="nav-item">
                            <a class="nav-link active pl-0 text-dark" href="#">Submit</a>
                          </li>
                          <li class="nav-item">
                            <a class="nav-link text-dark" href="#">Search</a>
                          </li>
                        </ul>
                  </div>
              </div>
              <div class="row mt-4">
                  <div class="col-md-5 col-sm-12 col-12">
                      <form class="rounded border p-4"
                            @submit.prevent="submit"
                      >
                          <div class="form-group">
                            <input type="text" 
                                    class="form-control"
                                    placeholder="Your name"
                                    v-model="submission.name">
                          </div>
                          <div class="form-group">
                              <select class="form-control"
                                      v-model="submission.occupation"
                              >
                                <option value="Full-stack">Full-stack</option>
                                <option value="Back-end">Back-end</option>
                                <option value="Front-end">Front-end</option>
                                <option value="I don't know">I don't know</option>
                              </select>
                          </div>
                          <div class="form-check">
                              <input class="form-check-input" 
                                      type="checkbox"
                                      v-model="submission.like"
                              >
                              <label class="form-check-label">
                                Do you like it?
                              </label>
                          </div>
                          <div class="form-check mt-2">
                              <input class="form-check-input" 
                                      type="radio" 
                                      value="Pizza"
                                      name="favouriteFood"
                                      v-model="submission.favouriteFood" 
                                      checked
                              >
                              <label class="form-check-label">
                                Pizza
                              </label>
                          </div>
                          <div class="form-check">
                              <input class="form-check-input" 
                                      type="radio" 
                                      value="Burgers" 
                                      name="favouriteFood" 
                                      v-model="submission.favouriteFood" 
                              >
                              <label class="form-check-label">
                                Burgers
                              </label>
                          </div>
                          <div class="form-check">
                              <input class="form-check-input" 
                                      type="radio" 
                                      value="Pizza & Burgers"
                                      name="favouriteFood" 
                                      v-model="submission.favouriteFood"  
                              >
                              <label class="form-check-label">
                                  Pizza & Burgers
                              </label>
                          </div>
                          <button type="submit" 
                                  class="btn btn-dark mt-4"
                          >
                              Submit
                          </button>
                        </form>
                  </div>
              </div>
          </div>
      </div>
    `
}