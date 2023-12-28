![image](https://github.com/Woselko/NetRaspApp/assets/76818798/64573a48-579f-4c62-84dc-a63e828d5e99)
![image](https://github.com/Woselko/NetRaspApp/assets/76818798/db040443-4f3e-4ccd-a1bb-a386aae79e25)
![image](https://github.com/Woselko/NetRaspApp/assets/76818798/0bb09a90-4b24-45c6-9a9a-9be6eaaf841e)


## How to build, publish and deploy .NET application on Raspberry Pi 5

### Prerequisites:

-	VS Code installed on your PC or laptop
-	Operating system is installed on your Raspberry (https://www.raspberrypi.com/software/)
You can also use RPI-imager to install system by command “sudo apt install rpi-imager”
-	Your PC or laptop and your Raspberry Pi are connected to same WI-FI network
  
## Setting up your SSH connection (Passwordless)( https://danidudas.medium.com/how-to-connect-to-raspberry-pi-via-ssh-without-password-using-ssh-keys-3abd782688a)

1.	You need to know your Raspberry IP address.  If it is connected you can find it while hovering WIFI icon in top right corner. 
You can also use command “hostname -I” in Raspberry terminal.

![image](https://github.com/Woselko/NetRaspApp/assets/76818798/1e458639-d31f-4e54-9739-99dd6b6c1c53)

2.	Enable SSH server in raspberry
Run command “sudo raspi-config” select “Interface Options” and enable access using SSH

3.	Enable SSH server in Windows
Open “Settings” > “Apps” > “Apps & Features” > “Optional Features.
Select “Add Features” and “OpenSSH Server” and “Install” (admin rights required).
Set the startup type for “OpenSSH Authentication Agent” and “OpenSSH Server” to “Automatic” in the Windows “Services” app.

4.	Now you should be able to connect via windows CMD to your raspberry
Use command in windows cmd “ssh <userName>@<IP>”. You’ll be asked for password.

5.	Generate an ssh key pair (private-public) on your local computer
First, check if you already have one. Default all the ssh keys are located in ~/.ssh folder on your computer. If you don’t have this folder or it’s empty you don’t have. To generate a new rsa key pair go to Terminal and simply type and follow the steps ssh-keygen
~/.ssh/id_rsa — This is your private key. NEVER share this file with anybody and DO NOT copy this file to external computers/servers.
~/.ssh/id_rsa.pub — This is the public key. The content of this file can be shared and the content of this file we will need to copy to the raspberry pi.

6.	ssh-keygen on Raspberry Pi
Now look inside your .ssh directory: “ls ~/.ssh” and you should see the files id_rsa and id_rsa.pub: authorized_keys  id_rsa  id_rsa.pub  known_hosts

7.	Copy public key to Raspberry Pi
vim ~/.ssh/authorized_keys
// paste in this the content of the ~/.ssh/id_rsa.pub from your local computer
run command “ssh-copy-id <USERNAME>@<IP-ADDRESS>”
Now try to connect once again from your local PC via SSH, connection should be passwordless

## Install  DOTNET on Raspberry device (https://learn.microsoft.com/en-us/dotnet/iot/deployment)
1.	Run command
curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel STS

2.	Add .NET as a path by commands:

echo 'export DOTNET_ROOT=$HOME/.dotnet' >> ~/.bashrc

echo 'export PATH=$PATH:$HOME/.dotnet' >> ~/.bashrc

source ~/.bashrc

3.	Verify .NET installation by command “dotnet --version”

## Create .Net Application
Run command “mkdir  NetRasp“ that will create folder in your RaspBerry folder: /home/woselko/NetRasp
Run command “dotnet new console -n NetRaspApp” that will create a console app

## Install VS Remote Debugger(https://learn.microsoft.com/en-us/dotnet/iot/debugging?tabs=self-contained&pivots=vscode)
1.	Run command “curl -sSL https://aka.ms/getvsdbgsh | /bin/sh /dev/stdin -v latest -l ~/vsdbg”

## Open your app in VS Code editor
Install below extensions to help ssh connection via vs code
![image](https://github.com/Woselko/NetRaspApp/assets/76818798/7cde105e-1c97-46bf-8e72-c413478c42a6)

Type in vs code Ctrl+Shift+P to open Command Pallete and run below command
![image](https://github.com/Woselko/NetRaspApp/assets/76818798/2397ab81-2bfd-41e2-bb25-4956bccdd5d6)

+Add New Connection Host  and type your Raspberry creds <username>@<IPAdress>
![image](https://github.com/Woselko/NetRaspApp/assets/76818798/a48ffdcf-ac4f-4812-be84-0db5c5fdd05a)

And Connect
Select Open Folder

![image](https://github.com/Woselko/NetRaspApp/assets/76818798/1f28975e-53b5-4276-8c65-51cb5d4c43fa)

Open your main app folder

![image](https://github.com/Woselko/NetRaspApp/assets/76818798/b5b6f45b-9991-44a2-831d-6bb69eb6da8e)

After Successful opening you’ll be asked for adding .net vs code assets, it will be very helpful during build, publish and deploy app.

![image](https://github.com/Woselko/NetRaspApp/assets/76818798/307aa891-c043-4321-9869-444d8999021e)

Check .vscode/tasks.json to see how build, publish, deploy task  is performed, you can you use those patters Check .vscode/launch.json to see how launch and debugger is attached
**REMEMBER** to change your credentials and check paths
After all you should be able to run your app and breakpoints should be hitted.

![image](https://github.com/Woselko/NetRaspApp/assets/76818798/4f4ce26e-4a7b-44d1-b396-fbd3af66ce37)

After successful RUN, application should be build, published and deployed to below location

![image](https://github.com/Woselko/NetRaspApp/assets/76818798/242b2965-d2f4-46c6-94ac-553474cc7c9e)
