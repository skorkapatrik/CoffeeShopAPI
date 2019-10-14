package hu.unideb.coffeeshopapi;

import hu.unideb.coffeeshopapi.domain.Manufacturer;
import hu.unideb.coffeeshopapi.repository.ManufacturerRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

@Component
public class Bootstrap implements CommandLineRunner {

    @Autowired
    ManufacturerRepository manufacturerRepository;

    @Override
    public void run(String... args) throws Exception {



                Manufacturer manufacturer1=new Manufacturer("Café de Ponto","Brazil","Sao Paulo","551568376921");
                Manufacturer manufacturer2=new Manufacturer("Mocha Java","Indonesia","Jakarta","62696317294");
                Manufacturer manufacturer3=new Manufacturer("Aroma","Argentina","Buenos Aires","54146397852");
                Manufacturer manufacturer4=new Manufacturer("Ilily","Italy","Trieste","39567238941");
                Manufacturer manufacturer5=new Manufacturer("Hunger beans","Ethiopia","Addis Ababa","2512358465");


                manufacturerRepository.save(manufacturer1);
                manufacturerRepository.save(manufacturer2);
                manufacturerRepository.save(manufacturer3);
                manufacturerRepository.save(manufacturer4);
                manufacturerRepository.save(manufacturer5);
    }
}
