package hu.unideb.coffeeshopapi.repository;

import hu.unideb.coffeeshopapi.domain.Manufacturer;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface ManufacturerRepository extends JpaRepository<Manufacturer,Long> {

}
