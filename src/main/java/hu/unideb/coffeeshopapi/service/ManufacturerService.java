package hu.unideb.coffeeshopapi.service;

import hu.unideb.coffeeshopapi.domain.Manufacturer;
import hu.unideb.coffeeshopapi.repository.ManufacturerRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ManufacturerService {

    @Autowired
    ManufacturerRepository manufacturerRepository;

    public List<Manufacturer> getAllManufacturer(){
        return manufacturerRepository.findAll();
    }

    public Manufacturer getManufacturerById(Long id){
        return manufacturerRepository.getOne(id);
    }

    public Manufacturer saveManufacturer(Manufacturer manufacturer){
        return manufacturerRepository.save(manufacturer);
    }
}
