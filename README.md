# powerplant-coding-challenge


## Getting Started

Hello there, envjoy the solution proposed to the coding-challenge.
Please follow step by step every steps in order to lunch it correctly.

## Steps

**1. Clone the repository**
  ```bash
    git clone -b crysis90war https://github.com/crysis90war/powerplant-coding-challenge.git
  ```

**2. Go to the folder PowerplantCodingChallenge**
  ```bash
    cd powerplant-coding-challenge/src/PowerplantCodingChallenge/
  ```

**3. Build the docker image of the solution**
  ```bash
    docker build -f ".\PowerplantUIL\Dockerfile" --force-rm -t powerplant:latest .
  ```

**4. Run the image as a container on port 8888**
  ```bash
    docker run --rm -d --name Powerplant -p 8888:80/tcp powerplant:latest
  ```

### NB: In order to test, you have 2 options. A or B
Make sure the image is running.

**5a. Option A, run the cUrl command line**
  Run the following command.
  
  ```bash
    curl -X POST -H "Content-Type: application/json" -d @"../../example_payloads/payload1.json" http://localhost:8888/api/productionplan -o ../result.json
  ```
  Open, result.json file

**5b. Open index.html**
  - Open 2x the index.html file.
  - Choose a payload and submit.