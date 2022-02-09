# powerplant-coding-challenge

## Getting Started

In order to be able to properly test my solution.
You have to follow all the steps listed below.

## Steps

**1. Clone the repository**

  ```bash
    git clone -b crysis90war https://github.com/crysis90war/powerplant-coding-challenge.git
  ```

**2. Go to the folder PowerplantCodingChallenge**

  ```bash
    cd powerplant-coding-challenge/PowerplantCodingChallenge/
  ```

**3. Build the docker image of the solution**

  ```bash
    docker build -f ".\Powerplant\Dockerfile" --force-rm -t powerplant:latest .
  ```

**4. Run the image as a container on port 8888**

  ```bash
    docker run --rm -d --name Powerplant -p 8888:80/tcp powerplant:latest
  ```

### NB: To test, you have two options (5a or 5b).

Make sure the image is running.

**5a. Option A. Run the cUrl command line**

  Run the following command.
  
  ```bash
    curl -X POST -H "Content-Type: application/json" -d @"../example_payloads/payload1.json" http://localhost:8888/api/productionplan -o ../response.json
  ```

  Open, response.json file

**5b.Option B. Open index.html**

  - Open the file 2 times side by side,
  - Choose a payload and submit.