export{};
  name();

async function name():Promise<void> {
    try{
        const response = await fetch("http://localhost:5281/spotify/login");
        console.log(response);
    }
    catch{

    }
}
