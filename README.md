# Requirements
* Hugo v0.87+

# Setup
### Install
    git clone --recursive git@github.com:potato-diet/potatodiet.ca.git

If this website is to be setup at a location other than https://potatodiet.ca, remember to update ```baseURL``` in config.toml.

### Development
    hugo server

The development server is located at http://localhost:1313 and will auto-refresh when any of the markdown files are modified.

### Production
    hugo

The compiled output is available in ./public.
